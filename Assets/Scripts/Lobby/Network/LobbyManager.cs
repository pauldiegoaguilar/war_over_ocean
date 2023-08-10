using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Unity.Netcode;
using Unity.Netcode.Transports.UTP;
using Unity.Services.Authentication;
using Unity.Services.Core;
using Unity.Services.Lobbies;
using Unity.Services.Lobbies.Models;
using Unity.Services.Relay;
using Unity.Services.Relay.Models;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LobbyManager : MonoBehaviour
{

    public static LobbyManager Instance { get; private set; }

    private string _lobbyId;

    private RelayHostData _hostData;
    private RelayJoinData _joinData;

    private void Awake()
    { 
        Instance = this;

        DontDestroyOnLoad(gameObject);
    }

    async void Start()
    {
        if (UnityServices.State != ServicesInitializationState.Initialized)
        {
            // Initialize Unity Services
            await UnityServices.InitializeAsync();

            // Setup events listeners
            SetupEvents();

            // Unity Login
            await SingInAnonymouslyAsync();
        }
    }


    #region UnityLogin

    private void SetupEvents()
    {
        AuthenticationService.Instance.SignedIn += () =>
        {
            // Shows how to get a playerID
            Debug.Log(message: $"PlayerID: {AuthenticationService.Instance.PlayerId}");

            // Shows how to get an access token
            Debug.Log(message: $"Access Token: {AuthenticationService.Instance.AccessToken}");
        };

        AuthenticationService.Instance.SignInFailed += (err) =>
        {
            Debug.Log(err);
        };

        AuthenticationService.Instance.SignedOut += () =>
        {
            Debug.Log(message: "Player signed out.");
        };
    }

    async Task SingInAnonymouslyAsync()
    {
        try
        {
            await AuthenticationService.Instance.SignInAnonymouslyAsync();
            Debug.Log(message: "Sign in anonymously succeeded!");
        }catch (Exception e)
        {
            // Notify the player with the proper error message
            Debug.LogException(e);
        }
    }

    #endregion



    #region Lobby

    public async void FindMatch()
    {
        Debug.Log(message: "Looking for a lobby...");

        try
        {
            // Looking for a Lobby

            // Add options to the matchmaking (mode, rank, etc..)
            QuickJoinLobbyOptions options = new QuickJoinLobbyOptions();

            // Quick-Join a random lobby
            Lobby lobby = await Lobbies.Instance.QuickJoinLobbyAsync(options);

            Debug.Log(message: "Joined Lobby: " + lobby.Id);
            Debug.Log(message: "Lobby Players: " + lobby.Players.Count);

            // Retrieve the Relay code previously set in the create match
            string joinCode = lobby.Data["joinCode"].Value;

            Debug.Log(message: "Received Code: " + joinCode);

            JoinAllocation allocation = await Relay.Instance.JoinAllocationAsync(joinCode);

            // Create Object
            _joinData = new RelayJoinData
            {
                Key = allocation.Key,
                Port = (ushort) allocation.RelayServer.Port,
                AllocationID = allocation.AllocationId,
                AllocationIDBytes = allocation.AllocationIdBytes,
                ConnectionData = allocation.ConnectionData,
                HostConnectionData = allocation.HostConnectionData,
                IPv4Address = allocation.RelayServer.IpV4
            };

            // Set Transportt data
            NetworkManager.Singleton.GetComponent<UnityTransport>().SetRelayServerData(
                _joinData.IPv4Address,
                _joinData.Port,
                _joinData.AllocationIDBytes,
                _joinData.Key,
                connectionDataBytes: _joinData.ConnectionData,
                _joinData.HostConnectionData);

            // Finally start the client
            NetworkManager.Singleton.StartClient();


        }catch (LobbyServiceException e)
        {
            Debug.Log(message: "Cannot find a lobby: " + e);
            //CreateMatch(); // Creates a lobby if there is no lobby, but now just print in console that it couldn't find a lobby and the error msg
        }
    }

    public async void CreateMatch()
    {
        Debug.Log(message: "Creating a new lobby...");

        // External Connections
        int maxConnections = 1;

        try
        {
            // Create RELAY object
            Allocation allocation = await Relay.Instance.CreateAllocationAsync(maxConnections);
            _hostData = new RelayHostData
            {
                Key = allocation.Key,
                Port = (ushort) allocation.RelayServer.Port,
                AllocationID = allocation.AllocationId,
                AllocationIDBytes = allocation.AllocationIdBytes,
                ConnectionData = allocation.ConnectionData,
                IPv4Address = allocation.RelayServer.IpV4
            };

            // Retrieve JoinCode
            _hostData.JoinCode = await Relay.Instance.GetJoinCodeAsync(allocation.AllocationId);


            string lobbyName = "game_lobby";
            int maxPlayers = 2;
            CreateLobbyOptions options = new CreateLobbyOptions();
            options.IsPrivate = false;

            // Put the JoinCode in the lobby data, visible by every member
            options.Data = new Dictionary<string, DataObject>()
            {
                {
                    "joinCode", new DataObject(
                        visibility: DataObject.VisibilityOptions.Member,
                        value: _hostData.JoinCode)
                },
            };


            var lobby = await Lobbies.Instance.CreateLobbyAsync(lobbyName, maxPlayers, options);

            // Save Lobby ID for later uses
            _lobbyId = lobby.Id;

            Debug.Log(message: "Created lobby: " + lobby.Id);

            // Heartbeat the lobby every 15 seconds. 
            StartCoroutine(HeartbeatLobbyCoroutine(lobby.Id, 15));

            // Now that RELAY and LOBBY are set...

            // Set Transform data
            NetworkManager.Singleton.GetComponent<UnityTransport>().SetRelayServerData(
                _hostData.IPv4Address,
                _hostData.Port,
                _hostData.AllocationIDBytes,
                _hostData.Key,
                _hostData.ConnectionData);

            // Finally start host
            NetworkManager.Singleton.StartHost();
            NetworkManager.Singleton.SceneManager.LoadScene("WaitingForPlayer", LoadSceneMode.Single);

        }
        catch (LobbyServiceException e)
        {
            Debug.Log(e);
        }
    }

    IEnumerator HeartbeatLobbyCoroutine(string lobbyId, float waitTimeSeconds)
    {
        var delay = new WaitForSecondsRealtime(waitTimeSeconds);
        while (true)
        {
            Lobbies.Instance.SendHeartbeatPingAsync(lobbyId);
            Debug.Log(message: "Lobby Heartbit");
            yield return delay;
        }
    }

    private void OnDestroy()
    {
        // We need to delete the lobby when we're not using it
        Lobbies.Instance.DeleteLobbyAsync(_lobbyId);
    }

    #endregion




    public struct RelayHostData
    {
        public string JoinCode;
        public string IPv4Address;
        public ushort Port;
        public Guid AllocationID;
        public byte[] AllocationIDBytes;
        public byte[] ConnectionData;
        public byte[] Key;
    }

    public struct RelayJoinData
    {
        public string JoinCode;
        public string IPv4Address;
        public ushort Port;
        public Guid AllocationID;
        public byte[] AllocationIDBytes;
        public byte[] ConnectionData;
        public byte[] HostConnectionData;
        public byte[] Key;
    }

}

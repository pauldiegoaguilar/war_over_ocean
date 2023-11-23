using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [Header("Login UI")]
    [SerializeField] private GameObject LoginUI;
    [SerializeField] private TMP_InputField username;
    [SerializeField] private TMP_InputField password;
    [SerializeField] private Button connectButton;
    [SerializeField] private TMP_Text connectButtonText;

    [Header("Menu UI")]
    [SerializeField] private GameObject WelcomeMsg;
    [SerializeField] private GameObject nextButton;
    [SerializeField] private GameObject intruction;

    [Header("Login Data Sample")]
    public string validUsername = "zikario123";
    public string validPassword = "zikario123";

    private void Awake()
    {

        password.contentType = TMP_InputField.ContentType.Password;
        password.ForceLabelUpdate();

        connectButton.onClick.AddListener(() =>
        {
            connectButtonText.text = "CONNECTING...";
            StartCoroutine(Login(username.text, password.text));
        });
    }

    IEnumerator Login(string userVal, string passVal)
    {
        yield return new WaitForSeconds(1);

        WWWForm form = new WWWForm();
        form.AddField("userPOST", userVal);
        form.AddField("passPOST", passVal);

        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/atomic-studios-woo/includes/gameFiles/login.php", form))
        {
            yield return www.SendWebRequest();

            if (www.result == UnityWebRequest.Result.ConnectionError || www.result == UnityWebRequest.Result.ProtocolError)
            {
                Debug.Log(www.error);
                connectButtonText.text = "CONNECTION ERROR";
                yield return new WaitForSeconds(2);
                connectButtonText.text = "CONNECT";
            }
            else
            {
                if (Convert.ToInt32(www.downloadHandler.text) > 0)
                {
                    Debug.Log("Form upload complete!");
                    nextButton.SetActive(true);
                    intruction.SetActive(true);
                    connectButtonText.text = "CONNECT";
                    LoginUI.SetActive(false);
                    WelcomeMsg.SetActive(true);
                }
                else
                {
                    connectButtonText.text = "INVALID DATA";
                    yield return new WaitForSeconds(2);
                    connectButtonText.text = "CONNECT";
                }
            }
        }
    }


    public void BackgroundButton()
    {
        SceneManager.LoadScene("Loading");
        //Debug.Log(message: "nueva escena");
    }
}

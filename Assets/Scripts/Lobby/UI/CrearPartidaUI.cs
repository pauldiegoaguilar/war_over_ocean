using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CrearPartidaUI : MonoBehaviour
{
    public static CrearPartidaUI Instance { get; private set; }

    [SerializeField] private Button crearPartidaBtn;
    [SerializeField] private Button atrasBtn;

    private void Awake()
    {
        Instance = this;

        crearPartidaBtn.onClick.AddListener(() =>
        {
            LobbyManager.Instance.CreateMatch();
        });

        atrasBtn.onClick.AddListener(() =>
        {
            Hide();
            MainUI.Instance.Show();
        });


        Hide();
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }
}
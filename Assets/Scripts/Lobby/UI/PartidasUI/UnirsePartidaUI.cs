using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UnirsePartidaUI : MonoBehaviour
{
    public static UnirsePartidaUI Instance { get; private set; }

    [SerializeField] private Button partidaRapidaBtn;
    [SerializeField] private Button partidaPrivadaBtn;
    [SerializeField] private TMP_InputField codePartida;
    [SerializeField] private Button atrasBtn;

    private void Awake()
    {
        Instance = this;

        partidaRapidaBtn.onClick.AddListener(() =>
        {
            LobbyManager.Instance.FindMatch();
        });

        // falta hacer que pueda crear partidas privadas

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

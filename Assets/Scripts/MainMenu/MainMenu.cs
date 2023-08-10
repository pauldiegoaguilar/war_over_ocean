using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
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
        connectButton.onClick.AddListener(() =>
        {
            connectButtonText.text = "CONNECTING...";
            StartCoroutine(Login());
        });
    }

    IEnumerator Login()
    {
        yield return new WaitForSeconds(3);

        // Lo cambiare por el login real
        if (username.text == validUsername && password.text == validPassword)
        {
            nextButton.SetActive(true);
            intruction.SetActive(true);
            connectButtonText.text = "CONNECT";
            LoginUI.SetActive(false);
            WelcomeMsg.SetActive(true);
        }
        else
        {
            connectButtonText.text = "CONNECT";
        }
    }


    public void BackgroundButton()
    {
        SceneManager.LoadScene("Loading");
        //Debug.Log(message: "nueva escena");
    }
}

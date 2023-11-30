using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GeneralUI : MonoBehaviour
{
    public static GeneralUI Instance { get; private set; }

    //[SerializeField] private Button partidasButton;
    [SerializeField] private Button salirBtn;

    private void Awake()
    {
        Instance = this;

        /*partidasButton.onClick.AddListener(() =>
        {
            Hide();
            PartidasUI.Instance.Show();
        });*/

        salirBtn.onClick.AddListener(() =>
        {
            // va al MainMenu
            Debug.Log("Va al MainMenu");
        });
    }

    /*public void Hide()
    {
        gameObject.SetActive(false);
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }*/
}

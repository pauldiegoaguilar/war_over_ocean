using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainUI : MonoBehaviour
{
    public static MainUI Instance { get; private set; }

    [SerializeField] private Button unirsePartidaUIBtn;
    [SerializeField] private Button crearPartidaUIBtn;
    [SerializeField] private Button atrasBtn;

    private void Awake()
    {
        Instance = this;

        unirsePartidaUIBtn.onClick.AddListener(() =>
        {
            Hide();
            UnirsePartidaUI.Instance.Show();
        });

        crearPartidaUIBtn.onClick.AddListener(() =>
        {
            Hide();
            CrearPartidaUI.Instance.Show();
        });

        atrasBtn.onClick.AddListener(() =>
        {
            GeneralBack.Instance.Hide();
            PartidasUI.Instance.Hide();
            //GeneralUI.Instance.Show();
        });
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NovedadesUI : MonoBehaviour
{
    public static NovedadesUI Instance { get; private set; }

    private void Awake()
    {
        Instance = this;

        //Hide();
        gameObject.SetActive(false);
    }

    public void Hide()
    {
        CaptainController.Instance.TurnON();
        gameObject.SetActive(false);

    }

    public void Show()
    {
        gameObject.SetActive(true);
    }
}

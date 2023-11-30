using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class INovedades : MonoBehaviour, IInteractable
{
    public string GetDescription()
    {
        return ("Novedades");
    }

    public void Interact()
    {
        NovedadesUI.Instance.Show();
        GeneralBack.Instance.Show();
    }
}

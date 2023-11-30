using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ITienda : MonoBehaviour, IInteractable
{
    public string GetDescription()
    {
        return ("Tienda");
    }

    public void Interact()
    {
        PartidasUI.Instance.Show();
        GeneralBack.Instance.Show();
    }
}

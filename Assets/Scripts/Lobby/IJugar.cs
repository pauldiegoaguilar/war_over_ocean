using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IJugar : MonoBehaviour, IInteractable
{
    public string GetDescription()
    {
        return ("Jugar");
    }

    public void Interact()
    {
        PartidasUI.Instance.Show();
        GeneralBack.Instance.Show();
    }
}

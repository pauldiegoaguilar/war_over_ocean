using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Casilla : MonoBehaviour
{
    public int Ncas = 0;
    public bool bomb = false;

    void OnMouseDown(){
        Debug.Log("casilla bombardeada");
        GetComponent<Collider>().enabled = false;
        bomb = true;
    }
}

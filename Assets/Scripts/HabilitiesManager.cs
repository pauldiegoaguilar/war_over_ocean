using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HabilitiesManager : MonoBehaviour
{
    public GameObject misil;
    public BoxCollider collider;

    /*void Update(){
        if(Input.GetKeyUp(KeyCode.Q)){
            crearMisil();
        }
    }*/

    public void OnButtonPress(){
        crearMisil();
    }

    void crearMisil(){
        Instantiate(misil, transform.position, transform.rotation);

        collider = GameObject.Find("Collider").GetComponent<BoxCollider>();

        collider.enabled = true;

    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HabilitiesManager : MonoBehaviour
{
    public GameObject misil;

    void Update(){
        /*if(Input.GetKeyUp(KeyCode.Q)){
            crearMisil();
        }*/
    }

    public void OnButtonPress(){
        crearMisil();
    }

    void crearMisil(){
        Instantiate(misil, transform.position, transform.rotation);

        GameObject.Find("Collider").GetComponent<BoxCollider>().enabled = true;
    }
}
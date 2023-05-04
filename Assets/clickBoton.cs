using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clickBoton : MonoBehaviour
{
    public GameObject barcos;
    
    public void clickRegenerar(){
        //Debug.Log("Boton clickeado");
        barcos.GetComponent<clickBarco>().enabled = true;
    }
}

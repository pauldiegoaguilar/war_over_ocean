using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class verifBarco : MonoBehaviour
{
    public GameObject ships;
    public Material materialNormal;
    public Material materialDestruido;
    public Material materialEscudo;
    private int cantBarco;
    public GameObject contadorScript;
    void Start()
    {

    }
    void Update()
    {
        foreach(Transform ship in ships.transform){
            switch(ship.tag){
                case("normal"):
                    ship.GetComponent<Renderer>().material = materialNormal;
                    break;
                case("destruido"):
                    ship.GetComponent<Renderer>().material = materialDestruido;
                    break;
                case("escudo"):
                    ship.GetComponent<Renderer>().material = materialEscudo;
                    if(ship.Find("contador(Clone)") == null){
                        Instantiate(contadorScript.GetComponent<contador>(), ship);
                    }
                    break;
                default:
                    break;
            }
        }
    }
}

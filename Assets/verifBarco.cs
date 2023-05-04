using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class verifBarco : MonoBehaviour
{
    public GameObject ships;
    public Material materialNormal;
    public Material materialDestruido;
    public Material materialEscudo;
    public float duracionEscudo = 60f;
    private float tiempoActual;
    private string[] verifEscudo;
    private int autoIncrementar;
    void Start()
    {
        autoIncrementar = 0;
        foreach(Transform ship in ships.transform){
            verifEscudo[autoIncrementar] = ship.name;
            autoIncrementar++;
        }
    }

    // Update is called once per frame
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
                    StartCoroutine(ContarTiempo(ship.transform));
                    break;
                default:
                    break;
            }
        }
    }
    IEnumerator ContarTiempo(Transform ship)
    {
        tiempoActual = duracionEscudo;
        

        while(tiempoActual > 0f)
        {
            Debug.Log(ship.tag);
            yield return new WaitForSeconds(1f);
            tiempoActual--;
            Debug.Log("Tiempo restante del escudo: " + tiempoActual);
        }

        Debug.Log("Tiempo terminado");
    }
}

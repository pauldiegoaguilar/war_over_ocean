using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class destruirTodo : MonoBehaviour
{
    public GameObject ships;
    public void destruir(){
        /*Debug.Log("Boton funcionando correctamente");
        Debug.Log(ships.transform.childCount);*/
        foreach(Transform ship in ships.transform){
            switch(ship.tag){
                case("normal"):
                    Debug.Log($"El barco llamado {ship.name} se destruyo");
                    ship.tag = "destruido";
                    break;
                case("destruido"):
                    Debug.Log($"El barco llamado {ship.name} ya esta destruido");
                    break;
                case("escudo"):
                    Debug.Log($"El barco llamado {ship.name} no se puede destruir");
                    break;
                default:
                    break;
            }
        }
    }
}

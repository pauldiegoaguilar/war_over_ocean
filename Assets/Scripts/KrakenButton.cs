using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KrakenButton : MonoBehaviour
{
    private Button hability;
    public GameObject ships; //Adjunto GameObject que almacena los G.O de los barcos
    private int shipIndex;
    private int cellIndex;

    private void Start(){
        hability = GetComponent<Button>(); //Hago referencia al G.O al que se le adjunta el script, en este caso un boton
        shipIndex = 0;
        cellIndex = 0;
    }

    // hacer que evalue si tiene escudo el barco (no las partes, el barco) y que en caso detecte un barco con escudo se
    // lo saltee pero que guarde su posicion para que al final lo intente destruir. 


    public void OnPress(){
        
        //hability.interactable = false;

        if(shipIndex < 6){

            Transform ship = ships.transform.GetChild(shipIndex); //Almaceno barco
            int partsA = ship.transform.childCount;

            if(cellIndex < partsA){
                
                if(ship.gameObject.tag != "destruido"){ //Si el barco no esta destruido...
                 
                    Transform shipPart = ship.transform.GetChild(cellIndex); //Almaceno "casilla"

                    if(shipPart.gameObject.tag != "destruido"){ //Si esta parte no fue bombardeada...
                      
                        shipPart.gameObject.tag = "destruido"; //Cambio nombre de etiqueta, indicando que la parte fue destruida
                        ++cellIndex;
                        return;
                    }
                    else{
                        Debug.Log("siguiente");
                        ++cellIndex;
                        OnPress();
                        return;
                    }
                }     
            }
         
            ++shipIndex;
            cellIndex = 0;
            ship.gameObject.tag = "destruido";
            return;
            
        }
    }
}

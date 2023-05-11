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

    public void OnPress(){
        
        if(shipIndex < 6){

            Transform ship = ships.transform.GetChild(shipIndex); //Almaceno barco
            int partsA = ship.transform.childCount;
        

            if(cellIndex < partsA){
                
                if(ship.gameObject.tag != "destruido"){ //Si el barco no esta destruido...
                    Debug.Log(cellIndex);
                    Transform shipPart = ship.transform.GetChild(cellIndex); //Almaceno "casilla"
                    Debug.Log(shipPart.gameObject.name);

                    if(shipPart.gameObject.tag != "destruido"){ //Si esta parte no fue bombardeada...

                        shipPart.gameObject.tag = "destruido"; //Cambio nombre de etiqueta, indicando que la parte fue destruida
                        
                    }
                    else{
                        cellIndex = cellIndex + 1;
                        Debug.Log(cellIndex);
                        OnPress();
                    }

                }
                cellIndex = cellIndex + 1;
                Debug.Log(cellIndex);
                return;     
            }

            ++shipIndex;
            cellIndex = 0;
            ship.gameObject.tag = "destruido";
            return;
            
        }
    }
}

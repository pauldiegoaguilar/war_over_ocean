using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class habilidad_1 : MonoBehaviour
{   
    public Temporizador temp;
    public main_controller main;
    bool press = true;
    

    private void OnMouseDown(){
        if(press){
            press = false;
            temp.AgregarT();
            main.turno_controller();
        }
    }
}


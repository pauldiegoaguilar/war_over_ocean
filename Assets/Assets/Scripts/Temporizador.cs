using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Temporizador : MonoBehaviour
{
    [SerializeField] public int segundos;
    [SerializeField] public int minutos;
    [SerializeField] Text mostrar;

    private int textMin;
    private int textSeg;

    private float tiempo;
    public bool turno;

    void show(){
        textMin = Mathf.FloorToInt(tiempo / 60);
        textSeg = Mathf.FloorToInt(tiempo % 60);
        mostrar.text = string.Format("{00:00}:{01:00}", textMin, textSeg);
    }
    
    void Awake(){
        tiempo = segundos + minutos * 60;
        turno = false;

        show();
    }

    public void AgregarT(){
        tiempo = tiempo + 5;
        show();
    }

    // Update is called once per frame
    void Update()
    {
        if(turno){
            
            tiempo -= Time.deltaTime;

            if(tiempo < 1){
                turno = false;
                //acabar_partida()
            }

            show();
        }

    }
}

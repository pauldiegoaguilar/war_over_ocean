using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class main_controller : MonoBehaviour
{
    [SerializeField] Temporizador t1;
    [SerializeField] Temporizador t2;

    // Start is called before the first frame update
    void Start()
    {
        t1.turno = true;
    }

    // Update is called once per frame
    public void turno_controller(){
        t1.turno = !t1.turno;
        t2.turno = !t2.turno;
    }
}

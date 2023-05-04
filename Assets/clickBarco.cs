using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clickBarco : MonoBehaviour
{
    public GameObject barcos;
    int cantBarcos;
    private GameObject[] barco;
    void Start()
    {
        cantBarcos = barcos.transform.childCount;
        barco = new GameObject[cantBarcos];
        for (int i = 0; i < cantBarcos; i++)
        {
            barco[i] = barcos.transform.GetChild(i).gameObject;
            //Debug.Log(barco[i].tag);
        }

    }
    void Update()
    {
        for(int i = 0; )
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.IsChildOf(transform))
                {
                    //Debug.Log("Objeto clickeado: " + hit.transform.name);
                    if (hit.transform.CompareTag("destruido"))
                    {
                        Debug.Log("este barco esta destruido");
                    }
                }
            }
        }
    }

}

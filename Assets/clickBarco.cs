using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clickBarco : MonoBehaviour
{

    public GameObject barcos;
    public GameObject boton;
    int cantBarcos;
    private GameObject[] barco;

    public Material texturaNormal;

    public Material texturaDestruida;
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
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.IsChildOf(transform))
                {
                    if (hit.transform.CompareTag("destruido"))
                    {
                        Debug.Log("este barco se reparo");
                        hit.transform.tag = "normal";
                        hit.transform.GetComponent<Renderer>().material = texturaNormal;
                        barcos.GetComponent<clickBarco>().enabled = false;
                        boton.gameObject.SetActive(false);

                    }
                    else if (hit.transform.CompareTag("normal"))
                    {
                        Debug.Log("Este barco no esta destruido");
                    }
                }
            }
        }
    }
}

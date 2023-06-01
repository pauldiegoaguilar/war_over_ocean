using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class regenerar : MonoBehaviour
{
    public GameObject ships;
    public bool verificacion;

    private void Update()
    {
        // Detectar clic del mouse
        if (Input.GetMouseButtonDown(0) && verificacion == true)
        {
            // Obtener el objeto clickeado
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                GameObject objetoClickeado = hit.collider.gameObject;
                Debug.Log(objetoClickeado.name);
                if(objetoClickeado.tag == "destruido" && objetoClickeado.transform.IsChildOf(ships.transform)){
                    objetoClickeado.tag = "normal";
                    verificacion = false;
                    Destroy(gameObject);    
                }    
            }
        }
    }
    public void regenerarVerif(){
        Debug.Log("boton funcionando");
        verificacion = true;
    }

}

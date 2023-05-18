using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class contador : MonoBehaviour
{
    float duracionEscudo;
    void Start()
    {
        if(transform.parent != null && transform.parent.tag == "escudo"){
            StartCoroutine(ContarTiempo());
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
    IEnumerator ContarTiempo()
    {
        duracionEscudo = 7f;
        

        while(duracionEscudo > 0f)
        {
            yield return new WaitForSeconds(1f);
            duracionEscudo--;
            Debug.Log("Tiempo restante del escudo: " + duracionEscudo);
            
        }
        transform.parent.tag = "normal";
        Debug.Log("Tiempo terminado");
        Destroy(gameObject);
    }
}

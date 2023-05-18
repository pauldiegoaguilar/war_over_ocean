using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrearPanel : MonoBehaviour
{
    public GameObject casilla;
    private int counter = 1;
    
    // Start is called before the first frame update
    void Start()
    {
        for(int r=0; r<10; r++)
        {
           for(int c=0; c<10; c++)
           {
                GameObject cas = Instantiate(casilla, new Vector3(c,0f,r), Quaternion.identity, gameObject.transform);
                cas.GetComponent<Casilla>().Ncas += counter;

                ++counter;
           }     
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

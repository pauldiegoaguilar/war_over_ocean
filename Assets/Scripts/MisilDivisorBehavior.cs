using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class MisilDivisorBehavior : MonoBehaviour {

    public Transform target;
    private GameObject _button;
    Vector3 direction;
    float speed = 20f;
    float rotationSpedd = 4f;

    void Start() {
        target = GameObject.Find("Barco 2").transform;
        _button = GameObject.Find("Button");
        transform.GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * 14f, ForceMode.VelocityChange);
    }

    void Update() {
        // Movement
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    
        // Rotation
        if(target != null){
            direction = target.position - transform.position;

            direction = direction.normalized;
            var rot = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, rot, rotationSpedd * Time.deltaTime);
        }
    }

    void OnTriggerEnter(Collider col) {
        /*if(col.CompareTag("Player")){
            Destroy(gameObject);
        }*/

        if(col.CompareTag("Collider")){

            Debug.Log("Me dividi epicamente");
            /*for (int i = 0; i < 9; i++) {
                GameObject divMisil = GameObject.Instantiate(gameObject, transform.position, transform.rotation);
                divMisil.transform.GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * 10f, ForceMode.Impulse);
            }*/
            _button.SetActive(false);
            Destroy(gameObject);
            // Crea 9 más y optiene las pocisiones de cada bloque que rodea al elegido al principio para ir ahi.
        }
    }

}

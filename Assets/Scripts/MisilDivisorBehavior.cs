using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class MisilDivisorBehavior : MonoBehaviour
{

    public Transform target;
    private GameObject _boton;
    Vector3 direction;
    float speed = 20f;
    float rotationSpedd = 5f;

    void Start() {
        target = GameObject.Find("Barco 2").transform;
        _boton = GameObject.Find("Button");
        //transform.GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * 7f, ForceMode.Impulse);
        transform.GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * 15f, ForceMode.VelocityChange);
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
        if(col.CompareTag("collider")){

            Debug.Log("Me dividi epicamente"); //divide();
            
            _boton.SetActive(false);
            Destroy(gameObject);
        }
    }

}

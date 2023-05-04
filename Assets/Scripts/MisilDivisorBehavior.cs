using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class MisilDivisorBehavior : MonoBehaviour
{

    public Transform target;
    Vector3 direction;
    float speed = 20;
    float rotationSpedd = 5;

    void Start() {
        target = GameObject.Find("Barco 2").transform;
        transform.GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * 7f, ForceMode.Impulse);
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
        if(col.CompareTag("Player")){
            Destroy(gameObject);
        }
    }

}

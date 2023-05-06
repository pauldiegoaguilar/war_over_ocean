using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterController : MonoBehaviour
{
    private CharacterController _characterController;
    public float speed = 5f;


    void Start() {
        _characterController = GetComponent<CharacterController>();

    }

    void Update() {
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        _characterController.Move(move * speed * Time.deltaTime);     
    }




}

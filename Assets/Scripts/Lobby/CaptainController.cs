using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CaptainController : MonoBehaviour
{
    public Camera captainCamera;
    public float lookSpeed = 2f;
    public float lookXLimit = 45f;
    float rotationX = 0;
    public bool canMove = true;
    bool Epressed = false;
    bool altPressed = false;

    public float interactionDistance = 2f;
    public GameObject interactionUI;
    public TextMeshProUGUI interactionText;
    public GameObject crosshair;


    public static CaptainController Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        CameraRotation();
        InteractionRay();
        MouseON();
    }

    void CameraRotation()
    {
        // Camera Rotation
        if (canMove) {
            rotationX += -Input.GetAxis("Mouse Y") * lookSpeed;
            rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);
            captainCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
            transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * lookSpeed, 0);
        }
    }

    void InteractionRay()
    {
        if (canMove)
        {
            Ray ray = captainCamera.ViewportPointToRay(Vector3.one / 2f);
            RaycastHit hit;

            bool hitSomething = false;

            if (Physics.Raycast(ray, out hit, interactionDistance))
            {
                IInteractable interactable = hit.collider.GetComponent<IInteractable>();

                if(interactable != null)
                {
                    hitSomething = true;
                    interactionText.text = interactable.GetDescription();

                    if(Input.GetKeyDown(KeyCode.E))
                    {
                        interactable.Interact();
                        Epressed = true;
                    }
                }
            }

            interactionUI.SetActive(hitSomething);

            if (Epressed)
            {
                canMove = false;
                Cursor.lockState = CursorLockMode.None;
                interactionUI.SetActive(false);
                Cursor.visible = true;
                crosshair.SetActive(false);
            }
        }
    }

    void MouseON()
    {
        if (Epressed)
            return;

        if (Input.GetKeyDown(KeyCode.LeftAlt) && !altPressed)
        {
            TurnOFF();
            altPressed = true;
        }
        else if(Input.GetKeyDown(KeyCode.LeftAlt) && altPressed)
        {
            TurnON();
            altPressed = false;
        }
    }

    public void TurnON()
    {
        canMove = true;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Epressed = false;
        crosshair.SetActive(true);
    }

    void TurnOFF()
    {
        canMove = false;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}

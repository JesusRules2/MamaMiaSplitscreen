// using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraController : MonoBehaviour
{
    //[SyncVar]
    public GameObject camObject;
    
    private Camera myCamera;
    public FreeCameraLook cameraLook;
     StateManager states;
    Vector2 viewInput = Vector2.zero;

    private void Awake()
    {
       camObject.SetActive(false);
    }
    void Start() {
        states = GetComponent<StateManager>();
        camObject.SetActive(true);
    }

    void Update() {
        // Adjust camera speed when aiming
        if (cameraLook != null) {
            if (states.aiming) {
                cameraLook.turnSpeed = 6f;
            }
            else if (states.aiming == false) {
                cameraLook.turnSpeed = 14.5f;
            }
        }

        cameraLook.viewInput2 = viewInput;
    }

    public void OnView(InputAction.CallbackContext context) {
        viewInput = context.ReadValue<Vector2>();
    }
}

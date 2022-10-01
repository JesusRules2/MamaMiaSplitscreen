using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// using Mirror;
using UnityEngine.InputSystem;

public class InputHandler : MonoBehaviour
{
  //  [SyncVar]
    public float horizontal;
    //[SyncVar]
    public float vertical;
    //[SyncVar]
    public float mouse1;
    //[SyncVar]
    public float mouse2;
    //[SyncVar]
    public float fire3;
    //[SyncVar]
    public float middleMouse;
    //[SyncVar]
    public float mouseX;
    //[SyncVar]
    public float mouseY;
     public float sprint;
    public float walk;
    bool bFireHeldDown;

   
    public FreeCameraLook camProperties;
    public Transform camPivot;
    public Transform camTrans;
    PlayerMovement playerMovement;

    CrosshairManager crosshairManager;
    ShakeCamera shakeCam;
    //[SyncVar]
    StateManager states;

    //[SyncVar]
    public float normalFov = 60;
    //[SyncVar]
    public float aimingFov = 40;
    //[SyncVar]
    public float targetFov;
    //[SyncVar]
    float curFov;
    //[SyncVar]
    public float cameraNormalZ = -2;
    //[SyncVar]
    public float cameraAimingZ = -0.86f;
    //[SyncVar]
    public float targetZ;
    //[SyncVar]
    float actualZ;
    //[SyncVar]
    float curZ;
    LayerMask layerMask;

    //[SyncVar]
    public float shakeRecoil = 0.5f;
    //[SyncVar]
    public float shakeMovement = 0.3f;
    //[SyncVar]
    public float shakeMin = 0.1f;
    //[SyncVar]
    float targetShake;
    //[SyncVar]
    float curShake;

    public bool fpsMode;
    //[SyncVar]
    bool canSwitch;
    ControllerSwitcher conSwitcher;
     PlayerInputActions playerInputActions;
     public Vector2 mouseDelta;
     public GameObject pauseMenu;
     bool bPauseMenuOn = false;

    // Start is called before the first frame update
    // void Start()
    void Awake() {
        playerMovement = GetComponent<PlayerMovement>();

        playerInputActions = new PlayerInputActions();
        playerInputActions.Mario.Enable();
        // playerInputActions.Mario.Aim.performed += AimStart;
        // playerInputActions.Mario.Aim.canceled += AimCancel;
        // playerInputActions.Mario.Fire.started += _ => FireStart();
        // playerInputActions.Mario.Fire.canceled += _ => FireCancel();
    }

    void Start()
    {
        crosshairManager = CrosshairManager.GetInstance();
      //  camProperties = FreeCameraLook.GetInstance();
      //  camPivot = camProperties.transform.GetChild(0);
    //    camTrans = camPivot.GetChild(0);
        shakeCam = camPivot.GetComponentInChildren<ShakeCamera>();

        states = GetComponent<StateManager>();

        layerMask = ~(1 << gameObject.layer);
        states.layerMask = layerMask;

        conSwitcher = ControllerSwitcher.GetInstance();

        if (conSwitcher != null)
        {
            canSwitch = true;
        }

        pauseMenu.SetActive(false);

    }
    
    // Update is called once per frame

    void FixedUpdate()
    {

        // if (!hasAuthority) { return; }

        camProperties = FreeCameraLook.GetInstance();

        if (camPivot == null)
        {
            camPivot = transform.Find("Camera Holder/Pivot");
        }
        if (camTrans == null)
        {
            camTrans = transform.Find("Camera Holder/Pivot/Holder 2");
        }

        HandleInput();
        UpdateStates();
        // HandleShake();


        // Find where the camera is looking
        Ray ray = new Ray(camTrans.position, camTrans.forward);
        states.lookPosition = ray.GetPoint(20);
        RaycastHit hit;

        // Debug.DrawRay(ray.origin, ray.direction);
        Debug.DrawRay(ray.origin, ray.direction, Color.red, 2.2f);

        if (Physics.Raycast(ray.origin, ray.direction, out hit, 100, layerMask))
        {
            states.lookHitPosition = hit.point;
        }
        else
        {
            states.lookHitPosition = states.lookPosition;
        }

        if (!fpsMode)
        {
            // Check for obstacles in front of the camera
            CameraCollision(layerMask);

            //Update camera's position
            curZ = Mathf.Lerp(curZ, actualZ, Time.deltaTime * 15);
            camTrans.localPosition = new Vector3(0, 0, curZ);
        }
    }


    void HandleInput()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        // mouse1 = Input.GetAxis("Fire1");
        // mouse2 = Input.GetAxis("Fire2");
        middleMouse = Input.GetAxis("Mouse ScrollWheel");
        // mouseX = Input.GetAxis("Mouse X");
        // mouseY = Input.GetAxis("Mouse Y");
        // fire3 = Input.GetAxis("Fire3");

        sprint = Input.GetAxis("Sprint");
        walk = Input.GetAxis("Walk");

        if (canSwitch)
        {
            //if (Input.GetKeyDown(KeyCode.F))
            //{
            //    Ray ray = new Ray(camTrans.position, camTrans.forward);
            //    Vector3 lookPos = ray.GetPoint(20);

            //    if (!fpsMode)
            //    {
            //        conSwitcher.SwitchToFps(lookPos);
            //    }
            //    else
            //    {
            //        conSwitcher.SwitchToTPS(lookPos);
            //    }
            //}
        }
    }

    void UpdateStates()
    {
        // states.aiming = states.onGround && (mouse2 > 0);
        states.canRun = !states.aiming;
        states.walk = (walk > 0);
        states.sprint = (sprint > 0);

        mouseDelta = playerInputActions.Mario.View.ReadValue<Vector2>();

        //1
        if (states.aiming)
        {
            targetZ = cameraAimingZ; //update target Z position of the camera
            targetFov = aimingFov;
        }
        else
        {
            states.shoot = false;
            targetZ = cameraNormalZ; //update target Z position of the camera
            targetFov = normalFov;
        }

    }

     void LateUpdate() {
        
        if (states.reloading)
        {         
            states.shoot = false;
        }
        if (states.aiming && bFireHeldDown && !states.reloading)
        {
            states.shoot = true;
        }

    }

    void HandleShake()
    {
         //UNDO????
        if (states.shoot && states.handleShooting.curBullets > 0)
        {
            targetShake = shakeRecoil;
            //camProperties.WiggleCrosshairAndCamera(0.12f);
            //targetFov += 5;
            camProperties.WiggleCrosshairAndCamera(0.001f); //JUSTIN! YOU HAD TO REDO THIS FOR CAM Moving UP!
            targetFov += 5;
        }
        else
        {
            if (states.vertical != 0)
            {
                targetShake = shakeMovement;
            }
            else
            {
                targetShake = shakeMin;
            }
        }
        //UNDOO???

        curShake = Mathf.Lerp(curShake, targetShake, Time.deltaTime * 10);
        shakeCam.positionShakeSpeed = curShake;

        curFov = Mathf.Lerp(curFov, targetFov, Time.deltaTime * 5);
        Camera.main.fieldOfView = curFov;
    }

    void CameraCollision(LayerMask layerMask)
    {
        //Do a raycast from the pivot of the camera to the camera
        Vector3 origin = camPivot.TransformPoint(Vector3.zero);
        Vector3 direction = camTrans.TransformPoint(Vector3.zero) - camPivot.TransformPoint(Vector3.zero);
        RaycastHit hit;

        //the distance of the raycast is controlled by if we are aiming or not
        actualZ = targetZ;

        //if an obstacle is found
        if (Physics.Raycast(origin, direction, out hit, Mathf.Abs(targetZ), layerMask))
        {
            //if we hit something, then find that distance
            float dis = Vector3.Distance(camPivot.position, hit.point);
            actualZ = -dis;//and the opposite of that is where we want to place our camera
        }
    }



    public void OnAim(InputAction.CallbackContext context) {
        // states.aiming = context.ReadValue<bool>();
        // states.aiming = context.action.triggered;

        if (context.started) {
            // states.aiming = states.onGround;
            states.aiming = true;
        }
        if (context.canceled) {
            states.aiming = false;

        }

    }

    public void OnFire(InputAction.CallbackContext context) {

        if (context.started) {
            
        bFireHeldDown = true;

            if (states.aiming)
            {
                if (!states.reloading)
                {
                    states.shoot = true;
                }
            }
        }

        if (context.canceled) {
            bFireHeldDown = false;
            states.shoot = false;
        }
    }

    public void Pause() {
        if (bPauseMenuOn) {
            pauseMenu.SetActive(false);
            bPauseMenuOn = false;
        }
        else if (bPauseMenuOn == false)
        {
             pauseMenu.SetActive(true);
             bPauseMenuOn = true;
        }
    }

    public void QuitGame() {
        if (bPauseMenuOn) {
            Destroy(gameObject);
        }

    }
    public void QuitGameController(InputAction.CallbackContext context) {
        if (bPauseMenuOn && context.canceled) {
            Destroy(gameObject);
        }

    }

}

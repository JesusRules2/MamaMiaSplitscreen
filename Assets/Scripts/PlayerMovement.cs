using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// using Mirror;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    // [SyncVar]
    InputHandler ih;
    //[SyncVar]
    StateManager states;
    public Rigidbody rb;

    //[SyncVar]
    Vector3 lookPosition;
    //[SyncVar]
    Vector3 storeDirection;

    HealthScript marioHealth = null;
    public float runSpeed = 3.2f; //Opposite? LOOK AT PREFAB
    public float sprintSpeed = 2.3f; //Opposite? LOOK AT PREFAB
    public float walkSpeed = 1.5f; //1.5 LOOK AT PREFAB
    [SerializeField] float staminaMaxDuration = 1.32f;
    [SerializeField] float staminaRechargeDuration = 0.9f;
    public float stamina;
    private float rechargeStaminaRate;
    public bool sprintBool = true;
    //[SyncVar]
    public float aimSpeed = 1;
    //[SyncVar]
    public float speedMultiplier = 10;
    //[SyncVar]
    public float rotateSpeed = 2;
    //[SyncVar]
    public float turnSpeed = 5;

    public float jumpForce = 10f;
    public float gravityForce = -0.5f;

    //[SyncVar]
    Vector3 v;
    //[SyncVar]
    Vector3 h;
    //[SyncVar]
    Quaternion targetRotation;

    //[SyncVar]
    public float horizontal;
    //[SyncVar]
    public float vertical;


    //[SyncVar]
    Vector3 lookDirection;

    //[SyncVar]
    PhysicMaterial zFriction;
    //[SyncVar]
    PhysicMaterial mFriction;
    Collider col;
     public Animator anim;
     bool onGround;
     PlayerInputActions playerInputActions;
     public Vector2 mouseDelta;
     Vector2 movementInput = Vector2.zero;


    void Awake() {
         playerInputActions = new PlayerInputActions();
        playerInputActions.Mario.Enable();
    }
    void Start()
    {
        ih = GetComponent<InputHandler>();
        rb = GetComponent<Rigidbody>();
        states = GetComponent<StateManager>();
        col = GetComponent<Collider>();
        marioHealth = GetComponent<HealthScript>();
        anim = GetComponent<HandleAnimations>().anim;

        zFriction = new PhysicMaterial();
        zFriction.dynamicFriction = 0;
        zFriction.staticFriction = 0;

        mFriction = new PhysicMaterial();
        mFriction.dynamicFriction = 1;
        mFriction.staticFriction = 1;
    }

    void FixedUpdate()
    {
        if (marioHealth.IsDead) { return; }


        lookPosition = states.lookPosition;
        lookDirection = lookPosition - transform.position;

        //Handle movement
        // Vector2 movement = playerInputActions.Mario.Movement.ReadValue<Vector2>();
        states.horizontal = movementInput.x;
        states.vertical = movementInput.y;
        horizontal = states.horizontal;
        vertical = states.vertical;

        // mouseDelta = playerInputActions.Mario.Movement.ReadValue<Vector2>();


        bool onGround = states.onGround;

        if (horizontal != 0 || vertical != 0 || !onGround)
        {
            col.material = zFriction;
        }
        else
        {
            col.material = mFriction;
        }

        Vector3 v = ih.camTrans.forward * vertical;
        Vector3 h = ih.camTrans.right * horizontal;
        // Vector3 v = new Vector3(10f, 10f, 10f);
        // Vector3 h = new Vector3(10f, 10f, 10f);


        v.y = 0;
        h.y = 0;
        rb.drag = 4;

        rb.AddForce((v + h).normalized * speed()); //MOVEENT

        //ROTATION
        if (states.aiming)
        {
            lookDirection.y = 0;

            targetRotation = Quaternion.LookRotation(lookDirection);
            transform.rotation = Quaternion.Slerp(rb.rotation, targetRotation, Time.deltaTime * rotateSpeed);
        }
        else
        {
            storeDirection = transform.position + h + v;

            Vector3 dir = storeDirection - transform.position;
            dir.y = 0;

            if (horizontal != 0 || vertical != 0)
            {
                float angl = Vector3.Angle(transform.forward, dir);

                if (angl != 0)
                {
                    float angle = Quaternion.Angle(transform.rotation, Quaternion.LookRotation(dir));
                    if (angle != 0)
                    {
                        rb.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(dir), turnSpeed * Time.deltaTime);
                    }
                }
            }
        }
    }

    private void Update()
    {
        // if (!hasAuthority) { return; }
         if (marioHealth.IsDead) { return; }

        onGround = states.onGround;


        if (!onGround && rb.velocity.y < 11) //GRAVITY
        {
            rb.velocity = new Vector3(rb.velocity.x, gravityForce, rb.velocity.z); //push down
        }


            //SPRINTING RATES
            if (states.sprint && rb.velocity.magnitude > 0.01f && stamina > 0 && states.reloading == false && states.shoot == false) //if sprinting
            {
                stamina -= Time.deltaTime;
                rechargeStaminaRate = 0.0f;

                //Debug.Log(stamina);
            }

            if (states.sprint == false)
            {
                rechargeStaminaRate += Time.deltaTime;
            }

            if (rechargeStaminaRate >= staminaRechargeDuration)
            {
                rechargeStaminaRate = staminaRechargeDuration;
                stamina += Time.deltaTime;

                //Debug.Log(stamina);
            }
            if (stamina > staminaMaxDuration)
            {
                stamina = staminaMaxDuration;
            }
            if (stamina <= 0)
            {
                stamina = 0;
                sprintBool = false;
            }
            else
            {
                sprintBool = true;
            }
            //yield return null;
    }
    void LateUpdate()
    {
        if (this.anim.GetCurrentAnimatorStateInfo(1).IsName("Reload"))
        {
            states.reloading = true;
        }
    }

    // [Command]
    void CmdHandleMovement(Vector3 h, Vector3 v, bool onGround)
    {
        RpcHandleMovement(h, v, onGround);
    }

    // [ClientRpc] //delete?
    void RpcHandleMovement(Vector3 h, Vector3 v, bool onGround)
    {
        if (onGround)
        {
            rb.AddForce((v + h).normalized * speed());
        }
    }

    float speed()
    {
        float speed = 0;

        if (states.aiming)
        {
            speed = aimSpeed;
        }
        else
        {
            if (states.walk || states.reloading)
            {
                //speed = walkSpeed; //2.5
                speed = aimSpeed + 2; //3
            }
            else
            {
                speed = runSpeed;
            }

            if (states.sprint && sprintBool && states.reloading == false)
            {
                speed = sprintSpeed;
            }
        }

        speed *= speedMultiplier;


        return speed;
    }
    
     public void Jump(InputAction.CallbackContext context) {
        //jumped = context.ReadValue<bool>();
        //jumped = context.action.triggered
        if (context.performed && onGround) 
        {
            states.audioManager.CmdPlayJumpSound();
            states.audioManager.landed = false;
            states.audioManager.jumpTimer = 0f;

            rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);
            //    rb.AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse);
            //  rb.velocity += Vector3.up * jumpForce;

        }
    }

    public void OnMove(InputAction.CallbackContext context) {
        movementInput = context.ReadValue<Vector2>();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// using Mirror;
using UnityEngine.InputSystem;

public class HandleAnimations : MonoBehaviour
{
    // [SerializeField]
    // private NetworkAnimator networkAnimator = null;
    public Animator anim;
    public PlayerMovement playerMovement;
    private Rigidbody rb;
     bool onGround;
     bool bMovement;

    // [SyncVar] //HIDE?
    StateManager states;
    Vector3 lookDirection;
    PlayerInputActions playerInputActions;

    void Awake() {
        playerInputActions = new PlayerInputActions();
        playerInputActions.Mario.Enable();
        playerInputActions.Mario.Movement.started += MovementOn;
        playerInputActions.Mario.Movement.canceled += MovementOff;

    }    
    void Start()
    {
        states = GetComponent<StateManager>();
        rb = GetComponent<Rigidbody>();
        SetupAnimator();
        bMovement = false;
    }

    private void MovementOn(InputAction.CallbackContext context) {
        bMovement = true;
    }
    private void MovementOff(InputAction.CallbackContext context) {
        bMovement = false;
    }
    // [Client]
    void FixedUpdate()
    {
        // if (!hasAuthority) { return; }
        //states = GetComponent<StateManager>();

        states.reloading = anim.GetBool("Reloading");
        anim.SetBool("Aim", states.aiming);
        //anim.SetBool("Aim", false);


        // float horizontal = Input.GetAxisRaw("Horizontal");
        // float vertical = Input.GetAxisRaw("Vertical");
        //  float horizontal = states.horizontal * .82f;
        // float vertical = states.vertical * .82f;
        float horizontal = GetComponent<PlayerMovement>().horizontal;
        float vertical = GetComponent<PlayerMovement>().vertical;


        if (!states.canRun)
        {
            // if (bMovement)  {
            //    anim.SetFloat("Forward", .7f, 0.1f, Time.deltaTime);
            // }
            // else {
            //     // anim.SetFloat("Forward", 0, 0.1f, Time.deltaTime);

            // }
            anim.SetFloat("Forward", Mathf.Abs(vertical), 0.1f, Time.deltaTime);
            anim.SetFloat("Sideways", Mathf.Abs(horizontal), 0.1f, Time.deltaTime);

        }
        else
        {
            float movement = Mathf.Abs(states.vertical) + Mathf.Abs(states.horizontal);

            bool walk = states.walk;
            bool aiming = states.aiming;

            // movement = Mathf.Clamp(movement, 0, (walk || states.reloading) ? 0.5f : 1);
             movement = Mathf.Clamp(movement, 0, (walk || states.reloading) ? 0.385f : 0.666f);

            if (states.reloading == true)
            {
                if (movement >= 0.385f)
                {
                    movement = 0.385f;
                }
            }

            anim.SetFloat("Forward", movement, 0.1f, Time.deltaTime);

             if (states.sprint && movement > 0.1f && playerMovement.stamina > 0 && states.reloading == false)
            {
                anim.SetFloat("Forward", 1.0f, 0.1f, Time.deltaTime);
            }
        }

       void LateUpdate()
        {
        if (this.anim.GetCurrentAnimatorStateInfo(1).IsName("Reload"))
        {
            states.reloading = true;
        }
    }     





        //if (rb.velocity.magnitude > 1)
        //{
        //    anim.SetFloat("Forward", 32.0f, 0.1f, Time.deltaTime);
        //}
        //else
        //{
        //    anim.SetFloat("Forward", 0.0f, 0.1f, Time.deltaTime);

        //}
    }

    // [Client]
    private void Update()
    {
        // if (!hasAuthority) { return; }

         onGround = states.onGround;

        if (!onGround && rb.velocity.y < 11)
        {
            anim.SetBool("isJumping", false); //change to network animator
        }
        if (!onGround && rb.velocity.y > 1)
        {
            anim.SetBool("isJumping", true);
        }

        anim.SetBool("isGrounded", onGround);

    }

    void SetupAnimator()
    {
        anim = GetComponent<Animator>();

        Animator[] anims = GetComponentsInChildren<Animator>();


        for (int i = 0; i < anims.Length; i++)
        {
            if (anims[i] != anim)
            {
                anim.avatar = anims[i].avatar;
                Destroy(anims[i]);
                break;
            }
        }
    }

    // [Client]
    public void StartReload()
    {
        if (!states.reloading)
        {
            // networkAnimator.SetTrigger("Reload");
            anim.SetTrigger("Reload");
        }
    }
}

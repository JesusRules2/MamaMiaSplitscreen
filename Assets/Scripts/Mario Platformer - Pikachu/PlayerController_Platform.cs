// using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;
public class PlayerController_Platform : MonoBehaviour
{
    //[SyncVar]
    public float moveSpeed;
    //  public Rigidbody theRB;
     public float moveSpeedMax = 19;

    //[SyncVar]
    public float jumpForce;
   //
    private CharacterController controller;
    public PickupStarPikachu starPikachu;

  //  [SyncVar]
    private Vector3 moveDirection;
    //[SyncVar]
    public float gravityScale;

    public Animator anim;

    // [SerializeField]
    // private NetworkAnimator networkAnimator = null;

    //[SyncVar]
    public Transform pivot;
    //[SyncVar]
    public float rotateSpeed;
   // [SyncVar]
    public GameObject playerModel; //REMEMBER TO USE FOR ANIMATOR CHARACTERS!

    bool bJumpAgain = true; //landed
    bool bJumpAgainTimer = true; //timer
    bool bResetJump = true;
    float JumpAgainTimer = 0f;

    float fallTimer;
    Vector2 movementInput = Vector2.zero;
    public Vector2 viewInput = Vector2.zero;
    public CameraController_Platform cameraController;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        //    theRB = GetComponent<Rigidbody>();
        starPikachu = GetComponent<PickupStarPikachu>();
       // pivot = GameObject.Find("PivotPikachu").transform;
    }

    public void Jump22()
    {
        //jumped = context.ReadValue<bool>();
        //jumped = context.action.triggered
        if (bJumpAgain)
        {
            moveDirection.y = jumpForce;

            bJumpAgain = false;
            JumpAgainTimer = 0f;

        }
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        movementInput = context.ReadValue<Vector2>();
    }
    public void OnView(InputAction.CallbackContext context) {
        viewInput = context.ReadValue<Vector2>();
    }

    void LateUpdate() {
        if (controller.isGrounded)
        {
            moveDirection.y = 0.0f;
            JumpAgainTimer += Time.deltaTime;
        }
    }
    void Update()
    {
        //if (pivot == null)
        {
           // pivot = GameObject.Find("PivotPikachu").transform;
        }
        //MAKE SURE ITS SET!!1!
        cameraController.viewInput2 = viewInput;

        // if (!hasAuthority) { return; }

        float yStore = moveDirection.y;
        // moveDirection = (transform.forward * Input.GetAxisRaw("Vertical")) +
        //     (transform.right * Input.GetAxisRaw("Horizontal"));
        moveDirection = (transform.forward * (movementInput.y) +
        (transform.right * (movementInput.x)));
        moveDirection = moveDirection.normalized * moveSpeed;
        moveDirection.y = yStore;


        // if (controller.isGrounded)
        // {
        //     moveDirection.y = 0.0f;
        //     JumpAgainTimer += Time.deltaTime;
        // }

        // // JUMP CODE
        // if (Input.GetButtonDown("Jump") && bJumpAgain)
        // {
        //     moveDirection.y = jumpForce;

        //     bJumpAgain = false;
        //     JumpAgainTimer = 0f;
        // }

        if (JumpAgainTimer > 0.12f && bJumpAgain == false)
        {
            bJumpAgain = true;
            JumpAgainTimer = 0f;
        }


        moveDirection.y = moveDirection.y + (Physics.gravity.y * gravityScale * Time.deltaTime);
        controller.Move(moveDirection * Time.deltaTime);

        if (pivot == null)
        {
            //pivot = transform.Find("PivotPikachu");
            pivot = transform.Find("Main Camera (1)/PivotPikachu");
        }

        //Move the player in different directions based on camera look direction
        // if (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0 && pivot != null)
        if (movementInput.x != 0 || movementInput.y != 0 && pivot != null)
        {
            transform.rotation = Quaternion.Euler(0f, pivot.rotation.eulerAngles.y, 0f);
            Quaternion newRotation = Quaternion.LookRotation(new Vector3(moveDirection.x, 0f, moveDirection.z));
            playerModel.transform.rotation = Quaternion.Slerp(playerModel.transform.rotation, newRotation, rotateSpeed * Time.deltaTime);
        }

        if (!controller.isGrounded && fallTimer > 0.09f)
        {
            // networkAnimator.SetTrigger("Jump");
            anim.SetTrigger("Jump");
        }

        ////if in air longer then a second, then do anim change
        if (!controller.isGrounded)
        {
            fallTimer += Time.deltaTime;
        }
        else
        {
            fallTimer = 0;
        }

        anim.SetBool("isGrounded", controller.isGrounded);
        anim.SetFloat("Speed", (Mathf.Abs(movementInput.y) + Mathf.Abs(movementInput.x)));
        // anim.SetFloat("Speed", (Mathf.Abs(Input.GetAxisRaw("Vertical")) + Mathf.Abs(Input.GetAxisRaw("Horizontal"))));
        
         if (starPikachu.bStarMode)
            {
                anim.SetBool("StarPower", true);
                //anim.SetFloat("Speed", (Mathf.Abs(Input.GetAxisRaw("Vertical")) + Mathf.Abs(Input.GetAxisRaw("Horizontal"))) * 3.2f); //*2 speed
            }
            else
            {
                anim.SetBool("StarPower", false);
            }
    }

}

// using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateManager : MonoBehaviour
{
   // [SyncVar]
    public bool aiming;
    //[SyncVar]
    public bool canRun;
     public bool sprint;

    //[SyncVar]
    public bool walk;
    //[SyncVar]
    public bool shoot;
    //[SyncVar]
    public bool reloading;
    //[SyncVar]
    public bool onGround;

    //[SyncVar]
    public float horizontal;
    //[SyncVar]
    public float vertical;
    //[SyncVar]
    public Vector3 lookPosition;
    //[SyncVar]
    public Vector3 lookHitPosition;
    //[SyncVar]
    public LayerMask layerMask;

    public CharacterAudioManager audioManager;

    [HideInInspector]
    public HandleShooting handleShooting;
    [HideInInspector]
    public HandleAnimations handleAnim;

    // Start is called before the first frame update
    void Start()
    {
        audioManager = GetComponent<CharacterAudioManager>();
        handleShooting = GetComponent<HandleShooting>();
        handleAnim = GetComponent<HandleAnimations>();
    }

    // [Client]
    private void FixedUpdate()
    {
      //  if (!hasAuthority) { return; }
        onGround = IsOnGround();
    }

    bool IsOnGround()
    {
        bool retVal = false;

        Vector3 origin = transform.position + new Vector3(0, 0.05f, 0);
        RaycastHit hit;

        if (Physics.Raycast(origin, -Vector3.up, out hit, 0.5f, layerMask))
        {
            retVal = true;
        }

        return retVal;
    }
}

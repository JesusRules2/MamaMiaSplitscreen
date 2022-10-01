using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// using Mirror;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class HandleShooting : MonoBehaviour
{
    StateManager states;
    public Animator weaponAnim;
    public float fireRate;
    float timer;
    public Transform bulletSpawnPoint;
    public GameObject smokeParticle;
    public ParticleSystem[] muzzle;
    public GameObject casingPrefab;
    public Transform caseSpawn;

    //NEW CODE
    public Camera thirdPersonCam;
    //NEW CODE (PUT IN HUD SCRIPT EVENTUALLY!)
    public Text ammoText;
    //NEW CODE
    public LayerMask layerMask = new LayerMask();

    public int BulletsMax = 30;
    public int curBullets;
    [HideInInspector]
    public bool bKill = false;
    [HideInInspector]
    public bool bDie = false;


    // [SyncVar]
    public Transform aimHelper;
    private Collider ownCollider;

    /*public override void OnStartAuthority()*/
    void Start()
    {
        curBullets = BulletsMax;
        // ammoText = GameObject.Find("AmmoText").GetComponent<Text>();
        ownCollider = GetComponent<Collider>();
        states = GetComponent<StateManager>();
    }

    bool shoot;
    bool dontShoot;

    bool emptyGun;

    // [Client]
    void FixedUpdate()
    {
        if (bKill)
        {
            bKill = false;
            GetComponent<KillCount>().kills++;
        }
        if (bDie) {
            bDie = false;
            GetComponent<KillCount>().kills--;
        }

        // if (!hasAuthority) { return; } //TODO ////////////////////////////////////////////////

        ammoText.text = "Ammo: " + curBullets.ToString();
        shoot = states.shoot;

        if (shoot)
        {
            if (timer <= 0)
            {
                weaponAnim.SetBool("Shoot", false);

                if (curBullets > 0)
                {
                    emptyGun = false;
                   // states.audioManager.PlayGunSound();

                    GameObject go = Instantiate(casingPrefab, caseSpawn.position, caseSpawn.rotation) as GameObject;
                    Rigidbody rig = go.GetComponent<Rigidbody>();
                    rig.AddForce(transform.right.normalized * 2 + Vector3.up * 1.3f, ForceMode.Impulse);
                    rig.AddRelativeTorque(go.transform.right * 1.5f, ForceMode.Impulse);

                    for (int i = 0; i < muzzle.Length; i++)
                    {
                        muzzle[i].Emit(1);
                    }

                    CmdRaycastShoot();
                    states.audioManager.CmdPlayGunSound();

                    curBullets = curBullets - 1;

                }
                else
                {
                    if (emptyGun)
                    {
                        states.handleAnim.StartReload();
                        //states.audioManager.PlayGunReload();
                        states.audioManager.CmdPlayGunReload();
                        curBullets = BulletsMax;
                    }
                    else
                    {
                        states.audioManager.PlayEffect("empty_gun");
                        emptyGun = true;
                    }
                }

                timer = fireRate;
            }
            else
            {
                weaponAnim.SetBool("Shoot", true);

                timer -= Time.deltaTime;
            }
        }
        else
        {
            timer = -1;
            weaponAnim.SetBool("Shoot", false);
        }
    }

    // [Command]
    void CmdRaycastShoot()
    {
  
        RaycastHit hit;

        Vector3 posOrigin = thirdPersonCam.transform.position;

        if (Physics.Raycast(posOrigin, thirdPersonCam.transform.forward, out hit, 3200, layerMask))
        {
            Debug.DrawRay(posOrigin, thirdPersonCam.transform.forward * 3000, Color.red, 2.0f);

            GameObject go = Instantiate(smokeParticle, hit.point, Quaternion.identity) as GameObject;
            go.transform.LookAt(bulletSpawnPoint.position);

            // NetworkServer.Spawn(go, connectionToClient);


            if (hit.transform.GetComponent<HealthScript>()) //Mario
            {
                hit.transform.GetComponent<HealthScript>().TakeDamage(10);

                if (hit.transform.GetComponent<HealthScript>().Health <= 0
                    && !hit.transform.GetComponent<HealthScript>().IsDead)
                {
                    bKill = true;
                }
            }

            if (hit.transform.GetComponent<HealthScriptPikachu>()) //Pikachu
            {
                if (hit.transform.GetComponent<HealthScriptPikachu>().pikachuStar.bStarMode) { return; }

                hit.transform.GetComponent<HealthScriptPikachu>().TakeDamage(10);

                if (hit.transform.GetComponent<HealthScriptPikachu>().Health <= 0
                    && !hit.transform.GetComponent<HealthScriptPikachu>().IsDead)
                {
                    bKill = true;
                }
            }
        }
    }

    public void Reload(InputAction.CallbackContext context) {
        if (curBullets != BulletsMax && context.performed) {

            states.handleAnim.StartReload();
            //states.audioManager.PlayGunReload();
            states.audioManager.CmdPlayGunReload();
            curBullets = BulletsMax;
        }
    }
   


    //[ClientRpc]
    //void RpcRaycastShoot()
    //{
    //    states.audioManager.PlayGunSound();

    //    return;

    //    RaycastHit hit;

    //    Vector3 posOrigin = thirdPersonCam.transform.position;

    //    if (Physics.Raycast(posOrigin, thirdPersonCam.transform.forward, out hit, 3200, layerMask))
    //    {
    //        Debug.DrawRay(posOrigin, thirdPersonCam.transform.forward * 3000, Color.red, 2.0f);

    //        GameObject go = Instantiate(smokeParticle, hit.point, Quaternion.identity) as GameObject;
    //        go.transform.LookAt(bulletSpawnPoint.position);

    //        NetworkServer.Spawn(go, connectionToClient);


    //        if (hit.transform.GetComponent<HealthScript>()) //Mario
    //        {
    //            hit.transform.GetComponent<HealthScript>().TakeDamage(10);
    //        }

    //        if (hit.transform.GetComponent<HealthScriptPikachu>()) //Pikachu
    //        {
    //            hit.transform.GetComponent<HealthScriptPikachu>().TakeDamage(10);
    //        }
    //    }
    //}
}
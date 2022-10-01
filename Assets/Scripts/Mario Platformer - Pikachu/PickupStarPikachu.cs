using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// using Mirror;

public class PickupStarPikachu : MonoBehaviour
{
    // [SyncVar]
    public bool bStarMode;
    // [SyncVar]
    public float starModeDuration = 8.2f;
    public AudioSource starModeSFX;
    public GameObject starModeSFXObject;

    PlayerController_Platform playerController;
    public float starMoveSpeed = 32.0f;
    public Material yellowSkin;
    public Material starModeSkin;
    public Renderer rend = null;

    // [SyncVar]
    bool bPlayStar;    
    void Start()
    {
        bPlayStar = false;
        playerController = GetComponent<PlayerController_Platform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (bStarMode)
        {
            playerController.moveSpeed = starMoveSpeed;
            rend.sharedMaterial = starModeSkin;
        }
        if (!bStarMode)
        {
            playerController.moveSpeed = playerController.moveSpeedMax;
            rend.sharedMaterial = yellowSkin;
        }

        starModeSFXObject.SetActive(true);
        starModeSFX.enabled = true;
    }

    void OnTriggerEnter(Collider col)
    {

        if (col.gameObject.CompareTag("Star"))
        {
                if (bStarMode) { return; }

                rend.sharedMaterial = starModeSkin;
                StartCoroutine(StarMode());
                DestroyStar(col.gameObject);

                // if (hasAuthority)
                {
                    //CmdStarSoundOnly();
                    RpcStarSoundOnly();
                }

                RpcStarSoundOnly();
        }
     }
    
    void DestroyStar(GameObject star)
    {
       // yield return new WaitForSeconds(0.132f);

        Destroy(star.gameObject);
        // NetworkServer.Destroy(star.gameObject);
    }

    IEnumerator StarMode()
    {
        //CmdPlayStarSFX();
        //starModeSFX.Play();
        bStarMode = true;

        yield return new WaitForSeconds(starModeDuration);

        bStarMode = false;
        rend.sharedMaterial = yellowSkin;
        CmdStopStarSFX();

    }


    IEnumerator PlaySFX()
    {
        yield return new WaitForSeconds(0.032f);
        CmdStarSoundOnly();
        yield return new WaitForSeconds(0.032f);
        CmdStarSoundOnly();
        yield return new WaitForSeconds(0.032f);
        CmdStarSoundOnly();
        yield return new WaitForSeconds(0.032f);
        CmdStarSoundOnly();
    }

    // [Command]
    public void CmdStarSoundOnly()
    {
        RpcStarSoundOnly();
    }
    // [ClientRpc]
    void RpcStarSoundOnly()
    {
        starModeSFX.Play();
    }




    // [Command]
    public void CmdStopStarSFX()
    {
        RpcStopStarSFX();
        rend.sharedMaterial = yellowSkin;
    }
    // [ClientRpc]
    void RpcStopStarSFX()
    {
        starModeSFX.Stop();
        rend.sharedMaterial = yellowSkin;

    }



    IEnumerator StopSound()
    {
        yield return new WaitForSeconds(0.1f);
        bPlayStar = false;
    }

}

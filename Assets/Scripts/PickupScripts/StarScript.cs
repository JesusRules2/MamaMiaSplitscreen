using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// using Mirror;

public class StarScript : MonoBehaviour
{
    [SerializeField] private Vector3 _rotation;
    [SerializeField] private float _speed;

    public float spawnTime = 0;
    public float spawnDelay = 5;

    public AudioSource starTwinkleSound;

    // public override void OnStartClient () 
    // {
    //     StartCoroutine(DeleteStar());
    // }

    void Start()
    {
        StarSound ();
        StartCoroutine(DeleteStar());

    }

    IEnumerator DeleteStar () {
        yield return new WaitForSeconds (12.5f); //15.0 REGULAR
        Destroy(gameObject);
        // NetworkServer.Destroy (gameObject);
    }

   void StarSound () {
        //CmdPlaySFX();
        //starTwinkleSound.Play();
        // if (NetworkClient.active == true) //DUNNO
        {
            // CmdPlaySFX ();
            starTwinkleSound.Play ();
        } 
        // else 
        // {
        //     starTwinkleSound.Stop ();

        // }

    }

     void Update () {
        transform.Rotate (_rotation * _speed * Time.deltaTime);
        transform.Translate (Vector3.forward * Time.deltaTime);
    }

    // [Command]
    void CmdPlaySFX()
    {
        RpcPlaySFX();
    }

    // [ClientRpc]
    void RpcPlaySFX()
    {
        starTwinkleSound.Play();

    }
}

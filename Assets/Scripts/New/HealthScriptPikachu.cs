// using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HealthScriptPikachu : MonoBehaviour
{
    // [SyncVar]
    public int Health = 30;
    Text healthText;
    Text ammoText;
    Image crosshair2;
    public Animator anim;
    SpawnPositions[] spawnPositions;
    // [SyncVar]
    public PickupStarPikachu pikachuStar = null;
    // [SyncVar]
    string reoccuringName;

    // [SerializeField]
    // private NetworkAnimator networkAnimator = null;

    public GameObject SpawnedGameObject;
    private GameObject crosshair;

    public bool IsDead = false;

    public AudioSource pikachuDie;
    public AudioClip[] pikachuDieClips;

    private void Start()
    {
        // networkAnimator = GetComponent<NetworkAnimator>(); //check i dunno
        //anim = GetComponent<Animator>();
        //reoccuringName = GetComponent<PlayerName>().playerNameTag;
        pikachuStar = GetComponent<PickupStarPikachu>();

        healthText = GameObject.Find("HealthText").GetComponent<Text>();
        ammoText = GameObject.Find("AmmoText").GetComponent<Text>();
        crosshair2 = GameObject.Find("Crosshair2").GetComponent<Image>();

        GameOverManager.instance.PikachusAlive++;
        gameObject.tag = "Player";
    }

    // [Client]
    private void Update()
    {
        if (gameObject.transform.position.y < -22f)
        {
            Health = 0;
        }

        if (Health <= 0)
        {
            Die();
        }

        if (IsDead)
        {
            Health = 0;
        }

        // if (!hasAuthority) { return; }

        healthText.text = "Health: " + Health.ToString();
        ammoText.text = "";
        crosshair2.enabled = false;


        //if (crosshair == null)
        //{
        //    crosshair = GameObject.Find("Crosshair Manager");
        //}

        //if (crosshair.activeSelf == true)
        //{
        //    crosshair.SetActive(false);
        //}

    }

    // [Client]
    public void TakeDamage(int damage)
    {
        //  if (pikachuStar.bStarMode) { return; } //yup

        Health -= damage;
    }

    private void Die()
    {
        if (anim && !IsDead)
        {
            IsDead = true;

            //gameObject.tag = "Dead";

            GameOverManager.instance.PikachusDead++;
            PikachuDeathSound();

            // networkAnimator.SetTrigger("Death");
            anim.SetTrigger("Death");
            GetComponent<PlayerController_Platform>().enabled = false;

          // if (hasAuthority) { return; }

            //   states.audioManager.PlayDeathSound();
            StartCoroutine(Respawn(SpawnedGameObject));
        }
    }

    // [Server]
    IEnumerator Respawn(GameObject go) //Mario
    {

        yield return new WaitForSeconds(3.16f);

        transform.position = transform.position + new Vector3(0f, 15f, 0f);



        IsDead = false;
        Health = 100;

        Transform newPos = GetRandomStartPosition();

        GameObject playerSpawn = Instantiate(go, //on server, put over network
                newPos.position,
                newPos.rotation);

        playerSpawn.GetComponent<KillCount>().kills = GetComponent<KillCount>().kills;
        playerSpawn.GetComponent<PlayerName>().playerNameTag = GetComponent<PlayerName>().playerNameTag; //move down?

        StartCoroutine(NameSpawn(playerSpawn));

        //NetworkServer.DestroyPlayerForConnection(connectionToClient);
        //NetworkServer.Spawn(playerSpawn, connectionToClient);
        //NetworkServer.AddPlayerForConnection(connectionToClient, playerSpawn);
        //NetworkServer.ReplacePlayerForConnection(connectionToClient, playerSpawn, true); //works on server, not client
        //Destroy(gameObject);

       
       // NetworkServer.Destroy(gameObject);
       // NetworkServer.Spawn(playerSpawn, connectionToClient);
        //NetworkServer.ReplacePlayerForConnection(connectionToClient, playerSpawn, true); //works on server, not client

    }

    IEnumerator NameSpawn(GameObject playerSpawn)
    {
        yield return new WaitForSeconds(0.16f);
        playerSpawn.GetComponent<PlayerName>().playerNameTag = GetComponent<PlayerName>().playerNameTag; //move down?

        // NetworkServer.Destroy(gameObject);
        // NetworkServer.Spawn(playerSpawn, connectionToClient);
        // NetworkServer.ReplacePlayerForConnection(connectionToClient, playerSpawn, true); //works on server, not client
    }

    // [Client]
    public void RespawnMario(GameObject go) //Mario
    {
        IsDead = false;
        Health = 100;

        Transform newPos = GetRandomStartPosition();

        GameObject playerSpawn = Instantiate(go, //on server, put over network
                newPos.position,
                newPos.rotation);

        playerSpawn.GetComponent<KillCount>().kills = GetComponent<KillCount>().kills;
        playerSpawn.GetComponent<PlayerName>().playerNameTag = GetComponent<PlayerName>().playerNameTag; //move down?

        // NetworkServer.DestroyPlayerForConnection(connectionToClient);
        // NetworkServer.Spawn(playerSpawn, connectionToClient);
        // NetworkServer.AddPlayerForConnection(connectionToClient, playerSpawn);
        // NetworkServer.ReplacePlayerForConnection(connectionToClient, playerSpawn, true); //works on server, not client


        Destroy(gameObject);

    }

    // [Client]
    public void RespawnPikachu(GameObject go)
    {
        //anim.SetBool("Death", false);
        // networkAnimator.SetTrigger("Revive");
        anim.SetTrigger("Revive");
        GetComponent<PlayerController_Platform>().enabled = true;
        

        Transform newPos = GetRandomStartPosition();
        this.gameObject.transform.position = newPos.position;
        this.gameObject.transform.rotation = newPos.rotation;
        IsDead = false;
        Health = 100;

        // NetworkServer.Spawn(go, connectionToClient);
    }


    public void PikachuDeathSound()
    {
        int ran = Random.Range(0, pikachuDieClips.Length);
        pikachuDie.clip = pikachuDieClips[ran];

        pikachuDie.Play();
    }

    Transform GetRandomStartPosition()
    {
        return spawnPositions[Random.Range(0, spawnPositions.Length)].transform;
    }
}

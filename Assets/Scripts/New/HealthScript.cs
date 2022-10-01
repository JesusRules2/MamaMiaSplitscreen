// using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HealthScript : MonoBehaviour
{    

    // [SyncVar]
    public float MaxHealth = 50;
    public float Health;
    public Image HealthBar;
    public Text healthText;
    Image crosshair2;
    Animator anim;

    SpawnPositions[] spawnPositions;
    // [SyncVar]
    string reoccuringName;

    [SerializeField]
    private HandleShooting handleShooting = null;

    public GameObject thisGameObject;

    // [SyncVar]
    public bool IsDead = false;

    StateManager states;
    public GameObject pikachuSpawn;
    private void Start()
    {
        anim = GetComponent<Animator>();
        states = GetComponent<StateManager>();
        reoccuringName = GetComponent<PlayerName>().playerNameTag;

        // healthText = GameObject.Find("HealthText").GetComponent<Text>();
        // crosshair2 = GameObject.Find("Crosshair2").GetComponent<Image>();

        GameOverManager.instance.MariosAlive++;
        gameObject.tag = "Player";

         spawnPositions = FindObjectsOfType<SpawnPositions>();
         Health = MaxHealth;

    }

    // [Client]
    private void Update()
    {
        if (gameObject.transform.position.y < -22f)
        {
            GetComponent<HandleShooting>().bDie = true;
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

        reoccuringName = GetComponent<PlayerName>().playerNameTag;


        HealthBar.fillAmount = Health / MaxHealth;
        // healthText.text = "Health: " + Health.ToString(); //Re-Enable when wanting text

        spawnPositions = FindObjectsOfType<SpawnPositions>();

    }

    // [Client]
    public void TakeDamage(int damage)
    {
        Health -= damage;
        Debug.Log(Health);
    }

    private void Die()
    {
        if (anim && !IsDead)
        {
            IsDead = true;

         //   gameObject.tag = "Dead";
            GetComponent<PlayerMovement>().enabled = false;
            GetComponent<HandleAnimations>().enabled = false;
            GetComponent<HandleShooting>().enabled = false;

            states.audioManager.PlayDeathSound();
            StartCoroutine(Respawn(thisGameObject));

            // networkAnimator.SetTrigger("Death");
            anim.SetTrigger("Death");
            // anim.SetBool("Death", true);
        }
    }

    private void OnDestroy() //put on Pikachus AFTER
    {
        if (IsDead == false)
        {
           // GameOverManager.instance.MariosAlive--;
        }
    }

    IEnumerator Respawn(GameObject go)
    {
        //NetworkServer.UnSpawn(this.gameObject);
        //Transform newPos = NetworkManager.singleton.GetStartPosition();
        //go.transform.position = newPos.position;
        //go.transform.rotation = newPos.rotation;
        
        yield return new WaitForSeconds(3.2f);

        IsDead = false;
        Health = MaxHealth;

        // anim.SetBool("Death", false);
        // networkAnimator.SetTrigger("Revive");
        anim.SetTrigger("Revive");
        GetComponent<PlayerMovement>().enabled = true;
        GetComponent<HandleAnimations>().enabled = true;
        GetComponent<HandleShooting>().enabled = true;

        IsDead = false;
        Health = MaxHealth;
        handleShooting.curBullets = handleShooting.BulletsMax; //current bullet script

        // NetworkServer.Spawn(thisGameObject, connectionToClient);
        GetComponent<PlayerName>().playerNameTag = reoccuringName; //move down?

        Transform newPos = GetRandomStartPosition();
        transform.position = newPos.position;
        transform.rotation = newPos.rotation;
    }

    // [Client]
    public void RespawnPikachu(GameObject go) //NEVER GETS CALLED!
    {
        // if (!hasAuthority) { return; }

        IsDead = false;
        Health = MaxHealth;

        Transform newPos = GetRandomStartPosition();


        GameObject playerSpawn = Instantiate(go, //on server, put over network
                newPos.position,
                newPos.rotation);


        //  NetworkServer.DestroyPlayerForConnection(connectionToClient);
        // NetworkServer.Spawn(playerSpawn, connectionToClient);
        //NetworkServer.AddPlayerForConnection(connectionToClient, playerSpawn);
        // NetworkServer.ReplacePlayerForConnection(connectionToClient, playerSpawn, true); //works on server, not client
        // NetworkServer.UnSpawn(gameObject);
        Destroy(gameObject);

        playerSpawn.GetComponent<KillCount>().kills = GetComponent<KillCount>().kills;
        playerSpawn.GetComponent<PlayerName>().playerNameTag = reoccuringName; //move down?
    }

    // [Client]
    public void RespawnMario(GameObject go)
    {
        // if (!hasAuthority) { return; }

        //anim.SetBool("Death", false);
        anim.SetTrigger("Revive");
        // networkAnimator.SetTrigger("Revive");
        GetComponent<PlayerMovement>().enabled = true;
        GetComponent<HandleAnimations>().enabled = true;
        GetComponent<HandleShooting>().enabled = true;

        Transform newPos = GetRandomStartPosition();
        transform.position = newPos.position;
        transform.rotation = newPos.rotation;
        IsDead = false;
        Health = MaxHealth;
        handleShooting.curBullets = handleShooting.BulletsMax; //current bullet script

       // NetworkServer.Spawn(thisGameObject, connectionToClient);
    }

    Transform GetRandomStartPosition()
    {
        return spawnPositions[Random.Range(0, spawnPositions.Length)].transform;
    }

    public void BeginSpawn() {
        spawnPositions = FindObjectsOfType<SpawnPositions>();

        Transform newPos = GetRandomStartPosition();
        transform.position = newPos.position;
        transform.rotation = newPos.rotation;
    }
}

// using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverManager : MonoBehaviour
{
    public static GameOverManager instance = null;
    //[SyncVar]
    public int PikachusAlive = 0;
    //[SyncVar]
    public int PikachusDead = 0;
    public int MariosAlive = 0;
    SpawnPositions[] spawnPositions;

    [SerializeField] private GameObject MarioWinPanel = null;
    [SerializeField] private GameObject PikachuWinPanel = null;

    Text pikachusLeftText;
    Text mariosLeftText;

    bool isMario = false;

    private GameObject[] allPlayers;
    int MarioPlayerStart;

    float StartTimer = 0f;
    bool StartEnabled = false;
    float EndTimer = 0f;
    public bool bGameOver = false;
    private bool bMarioWins = false;
    private bool bPikachuWins = false;

    public GameObject MarioPrefab;
    public GameObject PikachuPrefab;

    public List<GameObject> Players2 = new List<GameObject>(); //List of Mario AND pikachus
    GamePlayers[] allGamePlayers;
    int numPlayers2 = 0;

    //  [SerializeField] private NetworkManagerMario networkManagerMario = null;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        pikachusLeftText = GameObject.Find("PikachusLeftText").GetComponent<Text>();
        mariosLeftText = GameObject.Find("MariosLeftText").GetComponent<Text>();

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Confined;
    }

    // Update is called once per frame
    void Update()
    {
        int PikachusLeft = PikachusAlive - PikachusDead;
        pikachusLeftText.text = "Pikachus Left: " + PikachusLeft.ToString();

        if (mariosLeftText != null)
            mariosLeftText.text = "Marios: " + MariosAlive.ToString();


        if (StartTimer < 0.12f && !StartEnabled)
        {
            StartTimer += Time.deltaTime;
        }
        else
        {
            StartEnabled = true;
        }


        if (!StartEnabled) { return; }

        if (PikachusDead == PikachusAlive)
        {
            bMarioWins = true;
        }
        else
        {
            bMarioWins = false;
        }


        if (bMarioWins)
        {
            MarioWinPanel.SetActive(true);
        }
        else
        {
            MarioWinPanel.SetActive(false);
        }


        if (bMarioWins || bPikachuWins)
        {
            EndTimer += Time.deltaTime;
        }
        if (EndTimer > 6.2f && !bGameOver) //change back to 6.2f
        {
            bGameOver = true;
            //ResetLevelClient();
            ResetLevelServer();

            bGameOver = false;
            bMarioWins = false;
            bPikachuWins = false;
            EndTimer = 0f;

            MariosAlive = 0;
            PikachusAlive = 0;
            PikachusDead = 0;
            numPlayers2 = 0;
            MarioPlayerStart = 0;

            allPlayers = GameObject.FindGameObjectsWithTag("Player"); //Dont need Pikachus (for this game mode) - maybe for timer event


        }
    }

    // [Server]
    public void ResetLevelServer() //Marios Win
    {

        //allPlayers = GameObject.FindGameObjectsWithTag("Player"); //Dont need Pikachus (for this game mode) - maybe for timer event
        //MarioPlayerStart = UnityEngine.Random.Range(1, allPlayers.Length );
        allPlayers = GameObject.FindGameObjectsWithTag("Player"); //Dont need Pikachus (for this game mode) - maybe for timer event
        //MarioPlayerStart = UnityEngine.Random.Range(1, 3); //gotta add 1 for max on Ints
        MarioPlayerStart = allPlayers.Length;

        Debug.Log("Mario = " + MarioPlayerStart);


        foreach (GameObject player in allPlayers)
        {
            Transform StartPosition2 = GetRandomStartPosition();

            PlayerName namePlayer = player.GetComponent<PlayerName>();
            // NetworkIdentity id = player.GetComponent<NetworkIdentity>();
            KillCount playerKillCount = player.GetComponent<KillCount>();
            // if (id == null) return;
            {

                StartCoroutine(RespawnNew(namePlayer, playerKillCount));

            }
        }




    }

   //  [Client]
    IEnumerator RespawnNew(PlayerName namePlayer, KillCount playerKillCount) //Mario
    {
        yield return new WaitForSeconds(0.32f);

        //int MarioPlayerStart = UnityEngine.Random.Range(1, allPlayers.Length + 1);

        string nameTag = namePlayer.playerNameTag;
        Transform StartPosition2 = GetRandomStartPosition();

        numPlayers2++;

        if (numPlayers2 == 2)
        {
            Debug.Log("MarioNew = " + numPlayers2);

            GameObject marioSpawn = SpawnGameObject(MarioPrefab, StartPosition2);
            //GameObject marioSpawn = Instantiate(MarioPrefab,
            //StartPosition2.position, Quaternion.identity);

            marioSpawn.GetComponent<KillCount>().kills = playerKillCount.kills;

            // NetworkServer.Destroy(id.gameObject);

            // NetworkServer.Spawn(marioSpawn, id.connectionToClient);
            // NetworkServer.ReplacePlayerForConnection(id.connectionToClient, marioSpawn, true); //works on server, not client

            marioSpawn.GetComponent<PlayerName>().playerNameTag = nameTag;
            StartCoroutine(NameChangeSame(marioSpawn, nameTag));
        }
        else
        {
            Debug.Log("PikachuNew = " + numPlayers2);

            // var conn2 = id.connectionToClient;

            GameObject pikachuSpawn = SpawnGameObject(PikachuPrefab, StartPosition2);
            //GameObject pikachuSpawn = Instantiate(PikachuPrefab,
            //StartPosition2.position, Quaternion.identity);

            pikachuSpawn.GetComponent<KillCount>().kills = playerKillCount.kills;

            // Destroy(id.gameObject);
            // NetworkServer.ReplacePlayerForConnection(conn2, pikachuSpawn, true);

            pikachuSpawn.GetComponent<PlayerName>().playerNameTag = nameTag;
            StartCoroutine(NameChangeSame(pikachuSpawn, nameTag));
        }
    }

    // [Server]
    GameObject SpawnGameObject(GameObject go, Transform transform)
    {
        GameObject newGameObject = Instantiate(go,
            transform.position, Quaternion.identity);

        return newGameObject;
    }
   // [Server]
    IEnumerator NameChangeSame(GameObject go, string nameTag)
    {
        yield return new WaitForSeconds(1.0f);

        CmdNameChangeSame(go, nameTag);
        go.GetComponent<PlayerName>().playerNameTag = nameTag;
    }

    // [Command]
    void CmdNameChangeSame(GameObject go, string nameTag)
    {
        RpcNameChangeSame(go, nameTag);
        go.GetComponent<PlayerName>().playerNameTag = nameTag;

    }
    // [ClientRpc]
    void RpcNameChangeSame(GameObject go, string nameTag)
    {
        go.GetComponent<PlayerName>().playerNameTag = nameTag;

    }

    Transform GetRandomStartPosition()
    {
        return spawnPositions[Random.Range(0, spawnPositions.Length)].transform;
    }
}

//numPlayers2++;

//if (numPlayers2 == MarioPlayerStart)
//{
//    //NetworkServer.UnSpawn(playerGame.gameObject);
//    GameObject marioSpawn = Instantiate(MarioPrefab, //on server, put over network
//    StartPosition.position, Quaternion.identity);

//    NetworkServer.Spawn(marioSpawn, playerGame.connectionToClient);
//    // NetworkServer.ReplacePlayerForConnection(playerGame.connectionToClient, marioSpawn, true);
//}
//else
//{
//    //  NetworkServer.UnSpawn(playerGame.gameObject);
//    GameObject pikachuSpawn = Instantiate(PikachuPrefab, //on server, put over network
//    StartPosition.position, Quaternion.identity);

//    NetworkServer.Spawn(pikachuSpawn, playerGame.connectionToClient);
//    //  NetworkServer.ReplacePlayerForConnection(playerGame.connectionToClient, pikachuSpawn, true);
//}

//NetworkServer.Destroy(player);
//Destroy(player);






//foreach (GameObject player in allPlayers)
//{
//    GamePlayers playerGame = player.GetComponent<GamePlayers>();

//    Transform StartPosition = NetworkManager.singleton.GetStartPosition();

//   // NetworkServer.UnSpawn(playerGame.gameObject);
//   // Destroy(player);

//    numPlayers2++;

//    if (numPlayers2 == MarioPlayerStart)
//    {
//        //NetworkServer.UnSpawn(playerGame.gameObject);
//        GameObject marioSpawn = Instantiate(MarioPrefab, //on server, put over network
//        StartPosition.position, Quaternion.identity);

//        NetworkServer.Spawn(marioSpawn, playerGame.connectionToClient);
//       // NetworkServer.ReplacePlayerForConnection(playerGame.connectionToClient, marioSpawn, true);
//    }
//    else
//    {
//      //  NetworkServer.UnSpawn(playerGame.gameObject);
//        GameObject pikachuSpawn = Instantiate(PikachuPrefab, //on server, put over network
//        StartPosition.position, Quaternion.identity);

//        NetworkServer.Spawn(pikachuSpawn, playerGame.connectionToClient);
//      //  NetworkServer.ReplacePlayerForConnection(playerGame.connectionToClient, pikachuSpawn, true);
//    }

//    Destroy(player);
//}

// NetworkManager.singleton.StopHost();
//  NetworkManager.singleton.Start(); 




//int MarioPlayerStart = UnityEngine.Random.Range(1, allMario.Length + 1); //gotta add 1 for max on Ints

//foreach (GameObject mario in allMario)
//{
//    numPlayers2++;

//    if (numPlayers2 == MarioPlayerStart)
//    {
//        mario.GetComponent<HealthScript>().RespawnMario(MarioPrefab);
//    }
//    else
//    {
//        mario.GetComponent<HealthScript>().RespawnPikachu(PikachuPrefab);
//    }
//}
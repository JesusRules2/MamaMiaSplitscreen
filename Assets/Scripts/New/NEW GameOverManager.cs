
//using System.Collections;
//using System.Collections.Generic;
//using Mirror;
//using UnityEngine;
//using UnityEngine.SceneManagement;
//using UnityEngine.UI;

//public class GameOverManager2 : NetworkBehaviour
//{
//    public static GameOverManager instance = null;

//    public int PikachusAlive = 0;
//    public int PikachusDead = 0;

//    [SyncVar]
//    public float timeStart = 200;

//    int numPikasAttempt = 0;

//    [SerializeField] public GameObject MarioWinPanel = null;
//    [SerializeField] public GameObject PikachuWinPanel = null;

//    public bool bHidePikachuCount = false;

//    Text pikachusLeftText;
//    Text mariosLeftText;
//    public bool bShowPikaText = false;

//    bool isMario = false;

//    private GameObject[] allPlayers;
//    int MarioPlayerStart;

//    float StartTimer = 0f;
//    bool StartEnabled = false;
//    float EndTimer = 0f;
//    public bool bGameOver = false;

//    public bool bMarioWins = false;
//    public bool bPikachuWins = false;
//    public bool bHidePanelsBeginning = true;

//    public GameObject MarioPrefab;
//    public GameObject PikachuPrefab;
//    public GameObject CursorPrefab;

//    public bool bBeginGame = true;

//    //public List<GameObject> Players2 = new List<GameObject>(); //List of Mario AND pikachus
//    //GamePlayers[] allGamePlayers;

//    int numPlayers2 = 0;

//    // int PikachusLeft = 0;
//    int PikachusLeft2 = 0;

//   // NetworkSpawnPositions[] spawnPositions;

//    //Dictionary<NetworkConnection, int> killsForConnection = new Dictionary<NetworkConnection, int>();

//    //  [SerializeField] private NetworkManagerMario networkManagerMario = null;

//    private void Awake()
//    {
//        if (instance == null)
//        {
//            instance = this;
//        }
//        else if (instance != this)
//        {
//            Destroy(gameObject);
//        }
//    }

//    // Start is called before the first frame update
//    void Start()
//    {

//        PikachusLeft2 = FindObjectsOfType<HealthScriptPikachu>().Length; //INSTEAD OF HealthScriptPikachu
//        pikachusLeftText = GameObject.Find("PikachusLeftText").GetComponent<Text>();
//        pikachusLeftText.text = "Pikachus Left: " + PikachusLeft2.ToString();

//        //pikachusLeftText.text = "";

//        StartCoroutine(UpdateManager());

//        //Cursor.visible = false; //REVERSE 
//        //Cursor.lockState = CursorLockMode.Confined; //REVERSE
//        Cursor.visible = true;
//        Cursor.lockState = CursorLockMode.None;

//        //bHidePanelsBeginning = true;
//        bBeginGame = true;


//        // StartCoroutine(ResetLevelServer());

//        MarioWinPanel.SetActive(false);
//        PikachuWinPanel.SetActive(false);
//        CursorPrefab.SetActive(false);

//        StartCoroutine(HidePanels()); //starts level initial

//        spawnPositions = FindObjectsOfType<NetworkSpawnPositions>();
//    }

//    IEnumerator HidePanels() //starts level initial
//    {
//        yield return new WaitForSeconds(0.08f); //has to be lower then 0.16f
//        //bHidePanelsBeginning = true;
//        bBeginGame = false;

//        //INTS
//        numPlayers2 = 0;

//        //PikachusLeft = 0;
//        PikachusLeft2 = 0;

//        PikachusAlive = 0;
//        PikachusDead = 0;

//        MarioPlayerStart = 0;
//        numPlayers2 = 0;

//        StartCoroutine(UpdateManager());

//        // if (isServer) StartCoroutine(ResetLevelServer());
//        // StartCoroutine(ResetLevelServer());

//        //yield return new WaitForSeconds(0.08f);

//        // bHidePanelsBeginning = false; //1

//    }

//    //void Update()
//    IEnumerator UpdateManager()
//    {
//        while (true)
//        {
//            //if (bBeginGame == false)
//            //{
//            //    PikachusAlive = 0;
//            //    //if (isServer) StartCoroutine(ResetLevelServer());
//            //    //StartCoroutine(ResetLevelServer());
//            //    bBeginGame = true;
//            //}

//            //if (StartTimer < 0.12f && !StartEnabled)
//            //{
//            //    StartTimer += Time.deltaTime;
//            //}
//            //else
//            //{
//            //    StartEnabled = true;
//            //}

//            //if (!StartEnabled)
//            //{
//            //    yield return null;
//            //    continue;
//            //}

//            //if (PikachusDead == PikachusAlive)

//            PikachusLeft2 = FindObjectsOfType<HealthScriptPikachu>().Length; //INSTEAD OF HealthScriptPikachu
//            int MariosLeft = FindObjectsOfType<HealthScript>().Length; //INSTEAD OF HealthScriptPikachu

//            pikachusLeftText = GameObject.Find("PikachusLeftText").GetComponent<Text>();



//            //if (NetworkManager.singleton.numPlayers == 0)
//            if (PikachusLeft2 == 0 && MariosLeft == 0)
//            {
//                //PikachusLeft2 = 0;
//                //bMarioWins = false;
//                bHidePanelsBeginning = true;
//            }



//            if (bShowPikaText)
//            {
//                pikachusLeftText.text = "Pikachus Left: " + PikachusLeft2.ToString();
//            }
//            else
//            {
//                pikachusLeftText.text = "";
//            }


//            if (PikachusLeft2 <= 0) //PikachusLeft
//            {
//                bMarioWins = true;
//            }
//            else
//            {
//                bMarioWins = false;
//            }

//            //if (bMarioWins && bHidePikachuCount == true) 
//            //if (bMarioWins && !bHidePanelsBeginning)
//            if (bMarioWins && !bHidePanelsBeginning)
//            {
//                MarioWinPanel.SetActive(true);
//            }
//            else
//            {
//                MarioWinPanel.SetActive(false);
//            }

//            if (bPikachuWins) //+?
//            {
//                PikachuWinPanel.SetActive(true);
//            }
//            else
//            {
//                PikachuWinPanel.SetActive(false);
//            }

//            if (bMarioWins || bPikachuWins)
//            {
//                EndTimer += Time.deltaTime;
//                //Debug.Log(EndTimer.ToString()); //test
//            }
//            else
//            {
//                EndTimer = 0;
//            }

//            if (EndTimer > 12.2f) //change back to 6.2f
//            {

//                //bMarioWins = false; ??
//                //bPikachuWins = false;
//                //PikachuWinPanel.SetActive(false);
//                //MarioWinPanel.SetActive(false);

//                EndTimer = 0f;

//                //Debug.Log("PIKAS: " + PikachusLeft.ToString());
//                PikachusAlive = 0;
//                PikachusDead = 0;

//                //PikachusLeft = PikachusAlive - PikachusDead;
//                //pikachusLeftText.text = "Pikachus Left: " + PikachusLeft.ToString();

//                //if (PikachusLeft <= 0)
//                // {
//                StartCoroutine(ResetLevelServer());
//                //ResetLevelServer();
//                // }

//                //allPlayers = GameObject.FindGameObjectsWithTag("Player"); //Dont need Pikachus (for this game mode) - maybe for timer event
//            }

//            yield return null;
//        }
//    }

//    public void ChaseLevelServer()
//    {
//        //GameObject[] allPlayers = GameObject.FindGameObjectsWithTag("DeletePlayer");
//        //foreach (GameObject player in allPlayers)
//        //{
//        //    Destroy(player);
//        //}

//        StartCoroutine(ResetLevelServer());
//    }

//    //void ResetLevelServer() //Marios Win
//    IEnumerator ResetLevelServer()
//    {
//        yield return new WaitForSeconds(0.16f);

//        //bHidePanelsBeginning = false; //1

//        // TimerManager.instance.timeValue = TimerManager.instance.timeStart; //important
//        // TimerManager.instance.timeValue = timeStart; //important

//        MarioPlayerStart = 0;
//        numPlayers2 = 0;

//        //Debug.Log ("RESET_LEVEL_SERVER CALLED!!!");

//        allPlayers = GameObject.FindGameObjectsWithTag("Player"); //Dont need Pikachus (for this game mode) - maybe for timer event
//        MarioPlayerStart = allPlayers.Length;

//        //Debug.Log ("Mario = " + MarioPlayerStart);

//        foreach (GameObject player in allPlayers)
//        {
//            Transform StartPosition2 = NetworkManager.singleton.GetStartPosition();

//            PlayerName namePlayer = player.GetComponent<PlayerName>();
//            NetworkIdentity id = player.GetComponent<NetworkIdentity>();
//            //KillCount playerKillCount = player.GetComponent<KillCount> ();

//            if (id != null) //return;
//            {

//                StartCoroutine(RespawnNew(id, namePlayer, player));

//            }
//        }
//    }

//    //NUMBER 2 (Bottom)

//    //  [Client]
//    IEnumerator RespawnNew(NetworkIdentity id, PlayerName namePlayer, GameObject player)
//    {
//        yield return new WaitForSeconds(0.32f);

//        //bHidePanelsBeginning = false; //2

//        TimerManager.instance.timeValue = timeStart; //important

//        bMarioWins = false;
//        bPikachuWins = false;
//        PikachuWinPanel.SetActive(false);
//        MarioWinPanel.SetActive(false);

//        PickupSpawningManager.instance.ResetGamePickups();

//        string nameTag = namePlayer.playerNameTag;
//        //Transform startPosition = NetworkManager.singleton.GetStartPosition();
//        Transform startPosition = GetRandomStartPosition();

//        numPlayers2++;

//        //string matchID2 = player.GetComponent<Player>().matchID;
//        GameObject playerSpawn = SpawnGameObject(numPlayers2 == 2 ? TurnManager.instance.MarioPrefab : TurnManager.instance.PikachuPrefab, startPosition, nameTag, player);

//        Debug.Log($"{(numPlayers2 == 2 ? "Mario Spawned" : "Pikachu Spawned")}");

//        if (NetworkServer.ReplacePlayerForConnection(id.connectionToClient, playerSpawn, true))
//        {
//            Debug.Log($"Replaced player for connection successfully");
//        }
//        else
//        {
//            Debug.Log($"Failed to replace player for connection");
//        }

//        playerSpawn.GetComponent<PlayerName>().playerNameTag = nameTag;


//        int kills = player.GetComponent<KillCount>().kills;

//        NetworkServer.Destroy(id.gameObject);

//        // playerSpawn.GetComponent<KillCount>().kills = killsForConnection[id.connectionToClient]; Jared code
//        playerSpawn.GetComponent<KillCount>().kills = kills;



//        // playerSpawn.GetComponent<KillCount>().kills = player.GetComponent<KillCount>().kills; //DONT WORK ON SERVER BUILT
//        //playerSpawn.GetComponent<KillCount>().kills = 32; //Test

//        StartCoroutine(NameChangeSame(playerSpawn, nameTag, player, id, kills));
//        // playerSpawn.GetComponent<KillCount>().kills = killsForConnection[id.connectionToClient]; Jared code COPY
//    }

//    //string matchID;
//    [Server]
//    GameObject SpawnGameObject(GameObject go, Transform transform, string nameTag, GameObject player)
//    {

//        GameObject newGameObject = Instantiate(go,
//            transform.position, Quaternion.identity);

//        //newGameObject.GetComponent<NetworkMatchChecker>().matchId = matchID.ToGuid(); 


//        return newGameObject;
//    }

//    IEnumerator NameChangeSame(GameObject go, string nameTag, GameObject player, NetworkIdentity id, int kills) //SHOW JARED
//    { //name AND kills

//        yield return new WaitForSeconds(0.08f); //WORKS

//        //bHidePanelsBeginning = false; //3

//        go.GetComponent<PlayerName>().playerNameTag = nameTag;
//        go.GetComponent<KillCount>().kills = player.GetComponent<KillCount>().kills; //DONT WORK

//        //NetworkServer.Destroy(player.gameObject); //Destroying the wrong ones!
//    }

//    Transform GetRandomStartPosition()
//    {
//        return spawnPositions[Random.Range(0, spawnPositions.Length)].transform;
//    }

//    //public void AddKillsForConnection(NetworkConnection conn)
//    //{
//    //    killsForConnection[conn]++;
//    //}

//    // [TargetRpc]
//    // void TargetKillCount (GameObject playerSpawn, NetworkIdentity id, GameObject player) {
//    //     int kills = player.GetComponent<KillCount> ().savedKills;

//    //     //NetworkServer.Destroy(id.gameObject);

//    //     playerSpawn.GetComponent<KillCount> ().kills = kills;
//    // }

//    //[Command]
//    //void CmdNameChangeSame(GameObject go, string nameTag, GameObject player, NetworkIdentity id)
//    //{
//    //    go.GetComponent<PlayerName>().playerNameTag = nameTag;
//    //    go.GetComponent<KillCount>().kills = player.GetComponent<KillCount>().kills;

//    //    RpcNameChangeSame(go, nameTag, player, id);
//    //}

//    //[ClientRpc]
//    //void RpcNameChangeSame (GameObject go, string nameTag, GameObject player, NetworkIdentity id) 
//    //{
//    //    //go.GetComponent<KillCount>().kills = 32;
//    //    go.GetComponent<PlayerName> ().playerNameTag = nameTag;
//    //    go.GetComponent<KillCount>().kills = player.GetComponent<KillCount>().kills;                                                                                                 // go.GetComponent<KillCount>().kills = 32;

//    //}

//}

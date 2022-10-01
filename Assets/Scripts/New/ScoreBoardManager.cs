// using Mirror;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreBoardManager : MonoBehaviour
{
    bool bShowupScore = false;
    public GameObject killBoard = null;

    PlayerName[] players;
    int numPlayer = 0;

    [SerializeField] private TMP_Text[] playerNameTextsBoard = new TMP_Text[12];//change??? more players?
    [SerializeField] private TMP_Text[] playerKillTextsBoard = new TMP_Text[12];//change??? more players?

    // Start is called before the first frame update
    void Start()
    {
        killBoard = GameObject.Find("KillScoreBoard");
        players = FindObjectsOfType<PlayerName>();

    }

    // Update is called once per frame
    // [Client]
    void Update()
    {
        KillCountBoard();
    }

    void KillCountBoard()
    {
        players = FindObjectsOfType<PlayerName>();

        for (int i = 0; i < 12; i++)
        {
            playerNameTextsBoard[i].text = "";
            playerKillTextsBoard[i].text = "";
        }

        for (int i = 0; i < players.Length; i++)
        {
            playerNameTextsBoard[i].text = players[i].playerNameTag;
            playerKillTextsBoard[i].text = players[i].GetComponent<KillCount>().kills.ToString();
        }

        if (Input.GetKeyDown(KeyCode.H) || Input.GetButtonDown("ShowScoreBoard"))
        {
            bShowupScore = !bShowupScore;
        }

        if (bShowupScore)
        {
            killBoard.SetActive(true);
        }
        if (!bShowupScore)
        {
            killBoard.SetActive(false);
        }

    }
}

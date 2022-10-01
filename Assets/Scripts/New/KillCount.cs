// using Mirror;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class KillCount : MonoBehaviour
{
    public Text displayKillText = null;

    //public GameObject killBoard = null;
    //[SyncVar]
    //bool bShowupScore = false;

    // [SyncVar]
    public int kills;

    private void Start()
    {
        // displayKillText = GameObject.Find("KillText").GetComponent<Text>();
       // killBoard = GameObject.Find("KillScoreBoard");
    }

    // [Client]
    private void Update()
    {
        //killBoard = GameObject.Find("KillScoreBoard"); DONT WORK ON UPDATE

        //if (Input.GetKeyDown(KeyCode.H))
        //{
        //    TurnOffOnKillBoard();
        //}

        //if (bShowupScore)
        //{
        //    killBoard.SetActive(true);
        //}
        //if (!bShowupScore)
        //{
        //    killBoard.SetActive(false);
        //}



        // if (!hasAuthority) { return; }


        if (displayKillText == null)
        {
            //UNDO!
            // displayKillText = GameObject.Find("KillText").GetComponent<Text>();
        }

        if (displayKillText)
        {
            displayKillText.text = "Kills: " + kills.ToString();
        }



    }


    void TurnOffOnKillBoard()
    {
       // bShowupScore = !bShowupScore;
    }
}

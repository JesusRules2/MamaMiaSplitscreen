// using Mirror;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerName : MonoBehaviour
{
    public TMP_Text displayNameText = null;

    // [SyncVar] //KEEP ON
    public string playerNameTag;

    public TMP_InputField nameInput;
    public Canvas canvasDisplay = null;

    void Start()
    {
        nameInput = GameObject.Find("Name_InputField").GetComponent<TMP_InputField>();
        playerNameTag = "Test";
    }

    //private void Update()
    //{
    //    // ServerCheck();
    //   // nameInput = GameObject.Find("Name_InputField").GetComponent<TMP_InputField>();

    //    if (canvasDisplay)
    //    {
    //        canvasDisplay.transform.forward = Camera.main.transform.forward;
    //    }

    //    if (!hasAuthority) { return; }

    //    //playerNameTag = nameInput.text;


    //    if (displayNameText)
    //    {
    //        displayNameText.text = playerNameTag;
    //    }

    //   // CmdNameChange();

    //}

    // [Client]
    private void Update()
    {
      //  int kills = GetComponent<KillCount>().kills;

        if (displayNameText)
        {
            //displayNameText.text = playerNameTag + "K:" + kills;
            displayNameText.text = playerNameTag;
        }
        if (canvasDisplay)
        {
            canvasDisplay.transform.forward = Camera.main.transform.forward;
        }

        // if (!hasAuthority) { return; }

        if (displayNameText)
        {
             displayNameText.text = "";
        }

    }

    private void LateUpdate()
    {
        //if (!hasAuthority) { return; }

        //if (displayNameText)
        //{
        //    displayNameText.text = "";
        //}
    }

    // [Server]
    void ServerCheck()
    {
        {
            displayNameText.text = playerNameTag;
        }
    }

    // [Command]
    void CmdNameChange()
    {
        //  playerNameTag = nameInput.text;

        //if (displayNameText)
        {
            displayNameText.text = playerNameTag;
        }

        RpcNameChange();


    }
    // [ClientRpc]
    void RpcNameChange()
    {
        // playerNameTag = nameInput.text;

       // if (displayNameText)
        {
            displayNameText.text = playerNameTag;
        }
    }
}

// using Mirror;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GamePlayers : MonoBehaviour
{
    // [SyncVar(hook = nameof(AuthorityHandlePartyOwnerStateUpdated))]
    private bool isPartyOwner = false;

    // public static event Action<bool> AuthorityOnPartyOwnerStateUpdated;
    // public static event Action ClientOnInfoUpdated;


    //public TMP_Text displayNameText = null;
    //public TMP_Text displayKillText = null;
   // public Canvas canvasDisplay = null;

    //[SyncVar]
    //public string playerNameTag;

   // public TMP_InputField nameInput;

   // [SyncVar]
    //public int kills;


    // [SyncVar(hook = nameof(ClientHandleDisplayNameUpdated))]
    private string displayName;

    public string transferName;

    private void Start()
    {
       //nameInput = GameObject.Find("Name_InputField").GetComponent<TMP_InputField>();
    }


    //[Client]
    //private void Update()
    //{
    //    if (canvasDisplay)
    //    {
    //        canvasDisplay.transform.forward = Camera.main.transform.forward;
    //    }

    //    if (!hasAuthority) { return; }

    //    //nameInput = GameObject.Find("Name_InputField").GetComponent<TMP_InputField>();
    //    if (nameInput)
    //    {
    //        playerNameTag = nameInput.text;
    //    }

    //    if (displayNameText)
    //    {
    //        displayNameText.text = playerNameTag;
    //    }

    //    CmdNameChange();

    //}

    //[Command]
    //void CmdNameChange()
    //{
    //  //  playerNameTag = nameInput.text;

    //    if (displayNameText)
    //    {
    //       displayNameText.text = playerNameTag;
    //    }

    //    RpcNameChange();


    //}
    //[ClientRpc]
    //void RpcNameChange()
    //{
    //   // playerNameTag = nameInput.text;

    //    if (displayNameText)
    //    {
    //        displayNameText.text = playerNameTag;
    //    }
    //}

    public string GetDisplayName()
    {
        return displayName;
    }
    public bool GetIsPartyOwner()
    {
        return isPartyOwner;
    }

    // public override void OnStartClient()
    // {
    //     if (NetworkServer.active) { return; }

    //     ((NetworkManagerMario)NetworkManager.singleton).Players.Add(this);

    //     if (!isClientOnly) { return; }
    // }

    // public override void OnStopClient()
    // {
    //     ClientOnInfoUpdated?.Invoke();

    //     if (!isClientOnly) { return; }

    //     ((NetworkManagerMario)NetworkManager.singleton).Players.Remove(this);
    // }

    // [Server]
    public void SetDisplayName(string displayName)
    {
        this.displayName = displayName;
    }

    // [Server]
    public void SetPartyOwner(bool state)
    {
        isPartyOwner = state;
    }

    // [Command]
    public void CmdStartGame()
    {
        if (!isPartyOwner) { return; }

        // ((NetworkManagerMario)NetworkManager.singleton).StartGame();
    }

    // private void AuthorityHandlePartyOwnerStateUpdated(bool oldState, bool newState)
    // {
    //     if (!hasAuthority) { return; }

    //     AuthorityOnPartyOwnerStateUpdated?.Invoke(newState);
    // }

    // private void ClientHandleDisplayNameUpdated(string oldDisplayName, string newDisplayName)
    // {
    //     ClientOnInfoUpdated?.Invoke();
    // }
}

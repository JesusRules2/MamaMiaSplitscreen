using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// using Mirror;
using TMPro;
using UnityEngine.UI;

public class JoinLobbyMenu : MonoBehaviour
{
    [SerializeField] private GameObject landingPagePanel = null;
    [SerializeField] private TMP_InputField addressInput = null;
    [SerializeField] private Button joinButton = null;

    private void OnEnable()
    {
        NetworkManagerMario.ClientOnConnected += HandleClientConnected;
        NetworkManagerMario.ClientOnDisconnected += HandleClientDisconnected;
    }

    private void OnDisable()
    {
        NetworkManagerMario.ClientOnConnected -= HandleClientConnected;
        NetworkManagerMario.ClientOnDisconnected -= HandleClientDisconnected;
    }

    public void Join()
    {
        string address = addressInput.text;

        // NetworkManager.singleton.networkAddress = address;
        // NetworkManager.singleton.StartClient();

        joinButton.interactable = false;
    }

    private void HandleClientConnected()
    {
        joinButton.interactable = true;

        gameObject.SetActive(false);
        landingPagePanel.SetActive(false);
    }

    private void HandleClientDisconnected()
    {
        joinButton.interactable = true;
    }

    public void TurnOffEnterAddress()
    {
        // NetworkManager.singleton.StopHost();
        // NetworkManager.singleton.Start();
    }
}

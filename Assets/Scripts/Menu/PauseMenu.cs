using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
// using Mirror;
using UnityEngine.SceneManagement;
public class PauseMenu : MonoBehaviour
{
    [SerializeField] Slider volumeSlider;
    [SerializeField] public GameObject quitButton;
    [SerializeField] GameOverManager gm;
    void Start()
    {
        volumeSlider.value = 1; //default
    }
     public void GameBeginVolume() {
        volumeSlider.value = 1;
    }
    public void ChangeVolume()
    {
        AudioListener.volume = volumeSlider.value;
        Save();
    }
    private void Load()
    {
        volumeSlider.value = PlayerPrefs.GetFloat("gameVolume");
    }
    private void Save()
    {
        PlayerPrefs.SetFloat("gameVolume", volumeSlider.value);
    }
    public void QuitGame()
    {
        // GameOverManager gameManager = GameObject.FindObjectOfType<GameOverManager>();
        // gm.CmdResetLevelServer();
        // gm.RpcResetLevelServer();


        //GameOverManager.instance.bHidePanelsBeginning = true;
        Application.Quit();

        
        // NetworkManager.singleton.StopHost();
        // // NetworkManager.singleton.StopServer();
        // NetworkManager.singleton.StopClient();
        // // NetworkManager.singleton.ServerChangeScene("Scene_Menu");
        // // NetworkManager.singleton.Start();
        // SceneManager.LoadScene(0);
    }

    // [Command]
    // void CmdEndGame() {
    //     RpcEndGame();
    //     TargetEndGame();
    //     NetworkManager.singleton.StopHost();
    //     NetworkManager.singleton.StopServer();
    //     NetworkManager.singleton.StopClient();
    //             NetworkManager.singleton.ServerChangeScene("Scene_Menu");

    //     // NetworkManager.singleton.Start();
    //     SceneManager.LoadScene(0);
    // }

    // [ClientRpc]
    // void RpcEndGame() {
    //     TargetEndGame();
    //     NetworkManager.singleton.StopHost();
    //     NetworkManager.singleton.StopServer();
    //     NetworkManager.singleton.StopClient();
    //             NetworkManager.singleton.ServerChangeScene("Scene_Menu");

    //     // NetworkManager.singleton.Start();
    //     SceneManager.LoadScene(0);
    // }

    // [TargetRpc]
    // void TargetEndGame() {
    //     NetworkManager.singleton.StopHost();
    //     NetworkManager.singleton.StopServer();
    //     NetworkManager.singleton.StopClient();
    //             NetworkManager.singleton.ServerChangeScene("Scene_Menu");

    //     // NetworkManager.singleton.Start();
    //     SceneManager.LoadScene(0);
    // }
}

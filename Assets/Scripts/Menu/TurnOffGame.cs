// using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TurnOffGame : MonoBehaviour
{
    //[SerializeField] private bool isMario;

    bool CountDownQuit = false;
    float TimerQuit = 0f;

    // [Client]
    // void Update()
    // {
    //     gameObject.SetActive(true);
    //     // if (!hasAuthority) { return; }
    //     if (Input.GetKeyDown(KeyCode.Escape))
    //     {
    //         //CmdPikachuDie();
    //         CountDownQuit = true;

    //         // Application.Quit(); Do not put this on
    //         // NetworkManager.singleton.StopHost();
    //         // NetworkManager.singleton.Start();
    //         // SceneManager.LoadScene(0);// DUNNNOOOOO
    //     }

    //     if (CountDownQuit)
    //     {
    //         TimerQuit += Time.deltaTime;
    //         if (TimerQuit > 0.32)
    //         {
    //             // NetworkManager.singleton.StopHost();
    //             // NetworkManager.singleton.Start();
    //             // SceneManager.LoadScene(0);
    //         }
    //     }

    // }

    // [Command]
    void CmdPikachuDie()
    {
        //GameOverManager.instance.PikachusDead++;
        RpcPikachuDie();
    }

    // [ClientRpc]
    void RpcPikachuDie()
    {
        if (CountDownQuit) { return; }
        GameOverManager.instance.PikachusDead++;
    }
}

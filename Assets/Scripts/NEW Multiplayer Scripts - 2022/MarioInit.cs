using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MarioInit : MonoBehaviour
{
    void Start()
    {
        GameObject.FindGameObjectWithTag("TextJoinGame").GetComponent<TMP_Text>().enabled = false;
        
    }
    public void QuitGame() {
        // FindObjectOfType<MultiplayerGameManager>().canvasSetup.SetActive(true);
        FindObjectOfType<MultiplayerGameManager>().QuitGame();
    }

}

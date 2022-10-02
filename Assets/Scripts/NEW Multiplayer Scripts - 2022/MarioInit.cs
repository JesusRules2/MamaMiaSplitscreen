using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MarioInit : MonoBehaviour
{
    [SerializeField] GameObject winScreen;
    [SerializeField] GameObject loseScreen;
    [SerializeField] TMP_Text killsToWin;
    int killWinCount;
    bool bGameOver;
    void Start()
    {
        GameObject.FindGameObjectWithTag("TextJoinGame").GetComponent<TMP_Text>().enabled = false;
        bGameOver = false;
        // killWinCount = MultiplayerGameManager.instance.killCountWin;
        // killsToWin.text = $"Kills to win: {killWinCount}";
        
    }
    public void QuitGame() {
        // FindObjectOfType<MultiplayerGameManager>().QuitGame();
        MultiplayerGameManager.instance.QuitGame();
    }

    void Update() {
        killWinCount = MultiplayerGameManager.instance.killCountWin;
        killsToWin.text = $"Kills to win: {killWinCount}";

        if (GetComponent<KillCount>().kills >= killWinCount) {
            GameObject[] allMarios = GameObject.FindGameObjectsWithTag("Player");
            foreach(GameObject mario in allMarios) {
                mario.GetComponent<MarioInit>().loseScreen.SetActive(true);
            }
            loseScreen.SetActive(false);
            winScreen.SetActive(true);

            StartCoroutine(BackToMenu());
            // GameObject.FindGameObjectWithTag("CameraRed").GetComponent<Camera>().enabled = true;
            bGameOver = true;
        }
    }

    IEnumerator BackToMenu() {
        yield return new WaitForSeconds(10.0f);
        MultiplayerGameManager.instance.QuitGame();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using UnityEngine.UI;

public class MultiplayerGameManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject gameInputManager;
    public GameObject canvasSetup;
    [SerializeField] TMP_InputField killsInputField;
    [SerializeField] Button playButton;
    [HideInInspector] public int killCountWin;
    [SerializeField] GameObject joinPlayerTextCanvas;
    public bool bShowSetupScreen = true;

    void Start()
    {
        killsInputField.text = "15";
        killsInputField.onValueChanged.AddListener(KillCountChanged);
        playButton.onClick.AddListener(PlayButton);
        GameObject.FindObjectOfType<PlayerInputManager>().DisableJoining();
    }


    void KillCountChanged(string changedString) {

        killCountWin = int.Parse(changedString);
        Debug.Log(killCountWin);
    }

    void PlayButton() {
        GameObject.FindGameObjectWithTag("TextJoinGame").GetComponent<TMP_Text>().enabled = true;
        canvasSetup.SetActive(false);
        GameObject.FindObjectOfType<PlayerInputManager>().EnableJoining();
        // joinPlayerTextCanvas.SetActive(true);
    }

    public void QuitGame() {
         canvasSetup.SetActive(true);
        GameObject[] marios = GameObject.FindGameObjectsWithTag("Player");
        foreach (GameObject mario in marios) {
            Destroy(mario);
        }
        GameObject.FindObjectOfType<PlayerInputManager>().DisableJoining();
    }
}

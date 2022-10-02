using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MultiplayerGameManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject gameInputManager;
    public GameObject canvasSetup;
    [SerializeField] TMP_InputField killsInputField;
    [SerializeField] Button playButton;
    [HideInInspector] public int killCountWin;
    [SerializeField] GameObject killErrorText;

    public static MultiplayerGameManager instance;    

    void Awake() {
        if (instance != this) {
            instance = this;
        }
    }

    void Start()
    {
        killsInputField.text = "15";
        killCountWin = int.Parse(killsInputField.text);
        killsInputField.onValueChanged.AddListener(KillCountChanged);
        playButton.onClick.AddListener(PlayButton);
        GameObject.FindObjectOfType<PlayerInputManager>().DisableJoining();
    }


    void KillCountChanged(string changedString) {

        killCountWin = int.Parse(changedString);
        Debug.Log(killCountWin);
    }

    void PlayButton() {
        if (killCountWin <= 0) {
            killErrorText.SetActive(true);
            StartCoroutine(DisplayErrorTextDelay());
            return;
        }
        GameObject.FindGameObjectWithTag("TextJoinGame").GetComponent<TMP_Text>().enabled = true;
        canvasSetup.SetActive(false);
        GameObject.FindObjectOfType<PlayerInputManager>().EnableJoining();
        // joinPlayerTextCanvas.SetActive(true);
    }

    IEnumerator DisplayErrorTextDelay() {
        yield return new WaitForSeconds(5.0f);
        killErrorText.SetActive(false);
    }

    public void QuitGame() {
        killErrorText.SetActive(false);
        // GameObject.FindGameObjectWithTag("CameraRed").GetComponent<Camera>().enabled = false;
         canvasSetup.SetActive(true);
        GameObject[] marios = GameObject.FindGameObjectsWithTag("Player");
        foreach (GameObject mario in marios) {
            Destroy(mario);
        }
        GameObject.FindObjectOfType<PlayerInputManager>().DisableJoining();
        EventSystem.current.SetSelectedGameObject(playButton.gameObject);
    }
}

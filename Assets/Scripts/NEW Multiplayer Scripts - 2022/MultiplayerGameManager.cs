using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MultiplayerGameManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject gameInputManager;
    [SerializeField] TMP_InputField killsInputField;
    public int killCountInt;


    void Start()
    {
        killsInputField.text = "15";
        killsInputField.onValueChanged.AddListener(KillCountChanged); //use listeners! NOT inspector onValueChanged
        gameInputManager.SetActive(false);
    }


    public void KillCountChanged(string changedString) {

        killCountInt = int.Parse(changedString);
        Debug.Log(killCountInt);
    }
}

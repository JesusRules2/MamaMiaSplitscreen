using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PlayerSwitch : MonoBehaviour
{
    public GameObject mario = null;
    public GameObject pikachu = null;
    bool bMarioToPikachu;
    public bool isMario;
    bool bPikachuMove;
    SpawnPositions[] spawnPositions;
    //praise JESUS
    public Component[] marioComponents;
    public Component[] pikachuComponents;
    // public GameObject marioModel;
    // public GameObject pikachuModel;
    public Text healthText;
    public Text ammoText;

    void Start() {
        // SwitchToMario();
        // bMarioToPikachu = true;
    }

    public void SwitchToMario() {
        isMario = true;
        //  GetComponent<HealthScriptPikachu>().enabled = false;

        mario.SetActive(true);
        pikachu.SetActive(false);

        foreach (MonoBehaviour comp2 in marioComponents)
        {
            comp2.enabled = true;
        }
        foreach (MonoBehaviour comp2 in pikachuComponents)
        {
            comp2.enabled = false;
        }

        GetComponent<CharacterController>().enabled = false;

        Transform StartPosition = GetRandomStartPosition();
        transform.position = StartPosition.position;
        transform.rotation = StartPosition.rotation;
    }
    public void SwitchToPikachu() {
        isMario = false;
        //  GetComponent<HealthScriptPikachu>().enabled = true;

        mario.SetActive(false);
        pikachu.SetActive(true);

        foreach (MonoBehaviour comp2 in marioComponents)
        {
            comp2.enabled = false;
        }
        foreach (MonoBehaviour comp2 in pikachuComponents)
        {
            comp2.enabled = true;
        }

        GetComponent<CharacterController>().enabled = true;

        Transform StartPosition = GetRandomStartPosition();
        transform.position = StartPosition.position;
        transform.rotation = StartPosition.rotation;
    }

    void Update() 
    {
        spawnPositions = FindObjectsOfType<SpawnPositions>();

        if (Input.GetKeyDown(KeyCode.J)) {
            SwitchToMario();
        }
        if (Input.GetKeyDown(KeyCode.K)) {
            SwitchToPikachu();
        }
    }

    Transform GetRandomStartPosition()
    {
        return spawnPositions[Random.Range(0, spawnPositions.Length)].transform;
    }
}

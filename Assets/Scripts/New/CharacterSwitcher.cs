using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterSwitcher : MonoBehaviour
{
    int index = 0;
    [SerializeField] List<GameObject> fighters = new List<GameObject>();
    PlayerInputManager manager;
    SpawnPositions[] spawnPositions;
    void Start()
    {
        manager = GetComponent<PlayerInputManager>();
        index = Random.Range(0, fighters.Count);
        manager.playerPrefab = fighters[index];

         #if UNITY_EDITOR
             Debug.unityLogger.logEnabled = true;
        #else
             Debug.unityLogger.logEnabled=false;
        #endif
    }

    private void Update() {
        spawnPositions = FindObjectsOfType<SpawnPositions>();

    }

    public void SwitchNextSpawnCharacter(PlayerInput input) {

        index = Random.Range(0, fighters.Count);
        manager.playerPrefab = fighters[index];
    }

    // public void SpawnPlayer2(PlayerInput input) {
    //     manager.playerPrefab = fighters[0];
    //     Instantiate(manager.playerPrefab);
    // }

    Transform GetRandomStartPosition()
    {
        return spawnPositions[Random.Range(0, spawnPositions.Length)].transform;
    }
}

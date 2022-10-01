using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// using Mirror;

public class StarSpawnManager : MonoBehaviour
{
    public GameObject starPrefab;
    SpawnPositions[] spawnPositions;
    // [SyncVar]
    public float starSpawnTime = 12.5f;
    void Start() 
    {
         StartCoroutine (SpawnStars ());
         spawnPositions = FindObjectsOfType<SpawnPositions>();
    }
    
    IEnumerator SpawnStars () 
    {
        float time = starSpawnTime;
        while (true) 
        {
            if (time > 0) 
            {
                time -= Time.deltaTime;
              //  Debug.Log ($"Reducing time: {time}");
            } 
            else 
            {
                time = starSpawnTime;
                SpawnStar ();
            }
           // Debug.Log($"Time Scale: {Time.timeScale}");
            yield return null;
        }
    }
        void SpawnStar () {
        //Vector3 spawnPos = NetworkManager.singleton.GetStartPosition ().position + Vector3.up;
        Vector3 spawnPos = GetRandomStarPosition() + Vector3.up;

        GameObject starObject = Instantiate (starPrefab, spawnPos, Quaternion.identity);

        // NetworkServer.Spawn (starObject);
    }

    Vector3 GetRandomStarPosition()
    {
        return spawnPositions[Random.Range(0, spawnPositions.Length)].transform.position;
    }
}

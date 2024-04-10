using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private GameObject[] obstacles;
    [SerializeField] private float[] spawnLocationsX;
    [SerializeField] private Transform parent;

    [Header("Settings")]
    [SerializeField] private float spawnCooldown;

    private int randomNumber;

    void Start()
    {
        StartCoroutine(SpawnObstacles());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnObstacles()
    {
        while(true)
        {
            yield return new WaitForSeconds(Random.Range(spawnCooldown - 1, spawnCooldown + 4));
            randomNumber = Random.Range(0, 3);
            GameObject obstacle = Instantiate(obstacles[randomNumber], new Vector3(transform.position.x, spawnLocationsX[randomNumber], transform.position.z), Quaternion.identity);
            obstacle.transform.parent = parent;
        }
    }
}

/*
 * Basic mechanics of the game is done 
 * but need to focus on difficulty 
 * game is kinda easy right now
 * 
 * Decide about finding assets or
 * making the game no asset project 
 * with handmade basic animations
 * 
 * A hypercasual game of course needs
 * a timer or scoreboard
 * 
 * Coins or extra points might be added
 * for example of collectibles
 */
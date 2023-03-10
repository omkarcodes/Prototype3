using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    float startDelay = 2f;
    float SpawnInterval = 2f;
    int spawnIndex;

    public GameObject[] randomObstacleSpawn;
    

    Vector3 spawnPos = new Vector3(25, 0, 0);
    PlayerController playerController;
   

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnObstacle", startDelay, SpawnInterval);
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        
    }

    // Update is called once per frame
    void Update()
    {
        spawnIndex = Random.Range(0, randomObstacleSpawn.Length);
    }
    void SpawnObstacle()
    {
        GameObject spawnObject = randomObstacleSpawn[spawnIndex];
        Quaternion spawnRotation = randomObstacleSpawn[spawnIndex].transform.rotation;
        if (playerController.gameOver == false)
        {
            Instantiate(spawnObject, spawnPos, spawnRotation);
        }
        
       
    }
    
}

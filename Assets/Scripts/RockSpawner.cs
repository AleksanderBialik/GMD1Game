using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockSpawner : MonoBehaviour
{
    
    // Reference to the Prefab. Drag a Prefab into this field in the Inspector.
    public GameObject rock;
    private float InstantiationTimer = 2f;
    private Vector3 spawnPosition;
    
    void Start()
    {
        spawnPosition = transform.position;
        spawnPosition.y += 5f;
        InvokeRepeating("SpawnRock", 5.0f, 3.0f);
        
    }

    void SpawnRock()
    {
        Instantiate(rock, spawnPosition, Quaternion.identity);
    }
}

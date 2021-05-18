using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockSpawner : MonoBehaviour
{
    
    // Reference to the Prefab. Drag a Prefab into this field in the Inspector.
    public GameObject rock;
    private Vector3 spawnPosition;
    
    void Start()
    {
        spawnPosition = transform.position;
        InvokeRepeating("SpawnRock", 0f, 0.2f);
        
    }

    void SpawnRock()
    {
        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, Random.Range(79f,140f), transform.rotation.eulerAngles.z);
        GameObject shotSphere = Instantiate(rock, spawnPosition, Quaternion.identity);
       shotSphere.GetComponent<Rigidbody>().AddForce(transform.forward * 30000f);
    }
}

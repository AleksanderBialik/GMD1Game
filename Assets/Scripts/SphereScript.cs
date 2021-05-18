using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.name == "Player")
        {
            GameObject player = other.gameObject;
            player.SendMessage("TeleportPlayer");
            Destroy(gameObject);
        }
        if (other.gameObject.name == "Ground")
        {
            Destroy(gameObject);
        }

        
    }
}

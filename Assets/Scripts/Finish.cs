using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    [SerializeField] private GameObject stopwatch;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            string time = stopwatch.GetComponent<Stopwatch>().time;
            PlayerPrefs.SetString("finish", time);
            PlayerPrefs.Save();
            SceneManager.LoadScene("END");
        }
    }
}

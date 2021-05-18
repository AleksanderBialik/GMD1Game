using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class MusicVolume : MonoBehaviour
{
    
    [SerializeField]private AudioSource music;
    
    // Start is called before the first frame update
    void Start()
    {
        music.volume = PlayerPrefs.GetFloat("music");
    }

    // Update is called once per frame
    void Update()
    {
        music.volume = PlayerPrefs.GetFloat("music");
    }
}

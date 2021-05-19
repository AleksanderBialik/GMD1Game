using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioVolume : MonoBehaviour
{
    [SerializeField]private Slider musicSlider;
    

    void Start()
    {
        PlayerPrefs.SetFloat("music",0.02f);
        musicSlider.value = PlayerPrefs.GetFloat("music");
        PlayerPrefs.Save();
    }

    public void SetMusicVolume(float volume)
    {
        PlayerPrefs.SetFloat("music",volume);
        PlayerPrefs.Save();
    }

    public void SetEffectsVolume(float volume)
    {

    }

}

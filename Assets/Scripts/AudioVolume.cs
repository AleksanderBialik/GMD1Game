using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioVolume : MonoBehaviour
{
    [SerializeField]private Slider musicSlider;
    [SerializeField]private Slider effectsSlider;



    void Start()
    {
        if (PlayerPrefs.GetInt("isSoundSet") != 1)
        {
            PlayerPrefs.SetFloat("music",0.02f);
            PlayerPrefs.SetFloat("effects", 1f);
            PlayerPrefs.SetInt("isSoundSet",1);
            PlayerPrefs.Save();
        }
        musicSlider.value = PlayerPrefs.GetFloat("music");
        effectsSlider.value = PlayerPrefs.GetFloat("effects");
        
    }

    public void SetMusicVolume(float volume)
    {
        PlayerPrefs.SetFloat("music",volume);
        PlayerPrefs.Save();
    }

    public void SetEffectsVolume(float volume)
    {
        PlayerPrefs.SetFloat("effects",volume);
        PlayerPrefs.Save();
    }

}

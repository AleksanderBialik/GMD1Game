using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShowText : MonoBehaviour
{

    public string textValue;
    public TextMeshProUGUI textElement;
    private AudioSource source;
    private float startingAudioVolume = 1f;
    [SerializeField] public AudioClip startingAudio;
    // Start is called before the first frame update
    void Start()
    {
        textElement.text = textValue;
        source = GetComponent<AudioSource>();
        source.PlayOneShot(startingAudio,startingAudioVolume);
        StartCoroutine(DisableText());
    }

    IEnumerator DisableText()
    {
        //Print the time of when the function is first called.
        Debug.Log("Started Coroutine at timestamp : " + Time.time);

        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(5);

        //After we have waited 5 seconds print the time again.
        Debug.Log("Finished Coroutine at timestamp : " + Time.time);
    }
}

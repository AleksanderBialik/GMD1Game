using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShowText : MonoBehaviour
{

    public string textValue;
    public TextMeshProUGUI textElement;
    [SerializeField]private AudioSource source;
    [SerializeField]private float startingAudioVolume = 1f;
    [SerializeField] public AudioClip startingAudio;
    // Start is called before the first frame update
    void Start()
    {
        textElement.text = textValue;
        source.PlayOneShot(startingAudio,startingAudioVolume);
        StartCoroutine(DisableText());
    }

    IEnumerator DisableText()
    {
        float t = 0;
        Color32 startColor = new Color32(255,255,255,0);
        Color32 endColor = new Color32(255,255,255,255);
        textElement.color = startColor;
        while (t < 1)
        {
            textElement.color = Color32.Lerp(startColor, endColor, t);
            t += Time.deltaTime / 3f;
            yield return null;
        }

        t = 0;
        yield return new WaitForSeconds(1);
        while (t < 1)
        {
            textElement.color = Color32.Lerp(endColor, startColor, t);
            t += Time.deltaTime / 3f;
            yield return null;
        }
    }
}

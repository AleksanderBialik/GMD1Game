using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Stopwatch : MonoBehaviour
{
    private float timer;
    public string time;
    private float seconds;
    private float minutes;
    private float hours;

    [SerializeField] private Text text;
    

    
    
    
    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        calculateTime();
    }

    void calculateTime()
    {
        timer += Time.deltaTime;
        seconds = (int)(timer % 60);
        minutes = (int)(timer / 60);
        hours = (int)(timer / 3600);
        time = hours.ToString("00") + ":" + minutes.ToString("00") + ":" + seconds.ToString("00");
        text.text = hours.ToString("00") + ":" + minutes.ToString("00") + ":" + seconds.ToString("00");
    }
}

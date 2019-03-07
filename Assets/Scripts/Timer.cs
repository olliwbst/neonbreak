using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public GameObject timer;

    private float displayTime = 0f;
    private bool stop = false;
    private Text _timer;

    void Start()
    {
        _timer=timer.GetComponent<Text>();
    }
    
    //timer is counted up with time and displayed in ui
    void Update()
    {
        if (stop == false)
        {
            displayTime += Time.deltaTime;
            _timer.text = displayTime.ToString("F2");
        }
        else
        {
            GameManager.instance.time = displayTime;
        }
    }
    //function that stops timer and returns endtime
    public float EndTimer()
    {
        stop = true;
        return displayTime;
    }

    public void SetLowestTime()
    {
        //checks if the current displaytime is the lowest yet and sets it as such if it is not
        if (GameManager.instance.time == 0f||GameManager.instance.time <= displayTime)
        {
            GameManager.instance.time = displayTime;
            
            PlayerPrefs.SetFloat("HighScoreTime", displayTime); //set the pesistend highscore for the time to be the displaytime
        }
    }
}

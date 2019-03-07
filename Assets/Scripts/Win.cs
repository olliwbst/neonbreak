using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Win : MonoBehaviour
{
    public Timer _Timer;
    public GameObject victoryui;
    public Text _text;

    //triggers victory-function when player enters collider (script is on victoryzone)
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Victory();
        }
    }

    void Victory()
    {
        _text.text = "your time - " + _Timer.EndTimer().ToString("F2"); //display timer-time on victory-ui
        Time.timeScale = 0; //freeze time
        victoryui.SetActive(true); //victory-ui is shown
        _Timer.SetLowestTime(); //lowest time is reset in Timer-Script in case a new record was achieved
    }
}

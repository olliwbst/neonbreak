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
    public Die _Die;

    //triggers victory-function when player enters collider (script is on victoryzone)
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Victory();
        }
        Debug.Log("doorkills:"+GameManager.instance.Adoorkills);
        Debug.Log("enemykills"+GameManager.instance.Aenemykills);
        Debug.Log("stealthstatus"+GameManager.instance.Astealth);
    }

    void Victory()
    {
        _text.text = "your time - " + _Timer.EndTimer().ToString("F2"); //display timer-time on victory-ui
        Time.timeScale = 0; //freeze time
        victoryui.SetActive(true); //victory-ui is shown
        _Timer.SetLowestTime(); //lowest time is reset in Timer-Script in case a new record was achieved
        
        //check for achievements:
        if (PlayerPrefs.GetInt("a0")!=1 && (_Timer.EndTimer() < 20f))
        {
            PlayerPrefs.SetInt("a0", 1);//1=true in playerprefs for achievements
            //show new achievement alert here
        } 
        
        if (PlayerPrefs.GetInt("a1")!=1 &&(_Die.hits == 0))
        {
            PlayerPrefs.SetInt("a1", 1);
        }

        if (PlayerPrefs.GetInt("a2")!=1 &&(GameManager.instance.Aenemykills == 11))
        {
            PlayerPrefs.SetInt("a2", 1);
        }
        
        if (PlayerPrefs.GetInt("a3")!=1 &&(GameManager.instance.Adoorkills == 12))
        {
            PlayerPrefs.SetInt("a3", 1);
        }
        
        if (PlayerPrefs.GetInt("a4")!=1 &&(GameManager.instance.Astealth == true))
        {
            PlayerPrefs.SetInt("a4", 1);
        }
    }
}

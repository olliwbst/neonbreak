using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetScoreAch : MonoBehaviour
{
    private Text timescoretext;
    private float time;

    public Text a0;
    public Text a1;
    public Text a2;
    public Text a3;
    public Text a4;
    
    /*gets time saved in gamemanager and displays it in the achievements-ui (and a text if it is 0 which is not
     possible and used as a "not yet done"-value). other achievements can be taken from gamemanager and displayed
     in a similar way if the conditions are also checked on the right points*/
    void Start()
    {
        //set timerscore in ui
        timescoretext = gameObject.GetComponent<Text>();
        time = GameManager.instance.time;
        
        if (time == 0)
        {
            timescoretext.text = "lowest time - to be determined...";
        }
        else
        {
            timescoretext.text = "lowest time - " + time.ToString("F2");
        }
        
        //set achievements in ui
        if (PlayerPrefs.GetInt("a0") == 1)
        {
            a0.text += " - done";
            a0.color=Color.white;
        }
        if (PlayerPrefs.GetInt("a1") == 1)
        {
            a1.text += " - done";
            a1.color=Color.white;
        }
        if (PlayerPrefs.GetInt("a2") == 1)
        {
            a2.text += " - done";
            a2.color=Color.white;
        }
        if (PlayerPrefs.GetInt("a3") == 1)
        {
            a3.text += " - done";
            a3.color=Color.white;
        }
        if (PlayerPrefs.GetInt("a4") == 1)
        {
            a4.text += " - done";
            a4.color=Color.white;
        }
    }
}

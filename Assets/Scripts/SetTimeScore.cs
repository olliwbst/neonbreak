using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetTimeScore : MonoBehaviour
{
    private Text timescoretext;
    private float time;
    
    /*gets time saved in gamemanager and displays it in the achievements-ui (and a text if it is 0 which is not
     possible and used as a "not yet done"-value). other achievements can be taken from gamemanager and displayed
     in a similar way if the conditions are also checked on the right points*/
    void Start()
    {
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
    }
}

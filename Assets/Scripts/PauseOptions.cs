using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseOptions : MonoBehaviour
{
    public GameObject optionmenu;
    // freeze time and show options ingame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = 0;
            optionmenu.SetActive(true);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExitMenuOnEsc : MonoBehaviour
{
    public GameObject Menu;

    public Slider master;
    public Slider music;
    public Slider sfx;

    public bool ispausemenu = false; //if true, we assume that the UI is used as pause-screen in level
    
    //set UI-sliders to correct values for volumes on start
    private void Start()
    {
        master.value = GameManager.instance._masterLvl;
        music.value = GameManager.instance._musicLvl;
        sfx.value = GameManager.instance._sfxLvl;
    }

    // If escape is pressed, return to mainmenu or to realtime
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            gameObject.SetActive(false);
            
            if (ispausemenu)
            {
                Time.timeScale = 1;
            }
            else
            {
                Menu.SetActive(true);
            }
        }
    }
}

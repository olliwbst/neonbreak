using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditsToMenu : MonoBehaviour
{
    public GameObject menu;
    //disables credits and enables mainmenu on any button
    //can also be used for any similar ui-transition
    void Update()
    {
        if (Input.anyKey)
        {
            gameObject.SetActive(false);
            menu.SetActive(true);
        }
    }
}

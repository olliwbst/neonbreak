using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseSplash : MonoBehaviour
{
    /*splashscreen is disabled if any button is pressed and destroyed on first
    update if it isnt called the first time (handled in ChangeScene)*/
    void Update()
    {
        if (Input.anyKey)
        {
            gameObject.SetActive(false);
        }

        if (GameManager.instance.firststart==false)
        {
            Destroy(gameObject);
        }
    }
}

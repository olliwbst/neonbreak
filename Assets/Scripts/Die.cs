using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Die : MonoBehaviour
{
    private int hits = 0;
    private Text text;

    public int lives = 3;
    public GameObject hitui;
    public GameObject goui;

    void Start()
    {
        text = hitui.GetComponent<Text>(); //get the UI-component once at start
    }
    
    /*checks for collisions with projectiles, adds a hit and triggers Death-function if
     hits are >=lives*/
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("ProjectileP")||other.CompareTag("ProjectileE"))
        {
            Debug.Log(gameObject+"has been hit by"+other);
            hits += 1;
            if (gameObject.CompareTag("Player"))
            {
                text.text += "X"; //adds an "X" to the UI-so player can keep track of lives
            }
            if (hits >= lives)
            {
                Death();
            }
        }
    }
    //if dying object is player GameOver is triggered else the object is destroyed
    private void Death()
    {
        if (gameObject.CompareTag("Player"))
        {
            GameOver();
        }
        else
        {
            Destroy(gameObject);
        }
    }
    //sets gameover-UI active and freezes time so player doesnt hear sfx etc clicks
    public void GameOver()
    {
        goui.SetActive(true);
        Time.timeScale = 0;
    }
}

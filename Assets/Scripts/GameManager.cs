﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;//Static instance of GameManager which allows it to be accessed by any other script.

    //variables that need to be passed across scenes:
    public float time;
    public bool firststart=true;
    public float _sfxLvl;
    public float _musicLvl;
    public float _masterLvl;
    
    //Singleton enforcement
    void Awake()
    {
        //Check if instance already exists
        if (instance == null)

            //if not, set instance to this
            instance = this;

        //If instance already exists and it's not this:
        else if (instance != this)

            //Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
            Destroy(gameObject);

        //Sets this to not be destroyed when reloading scene
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        //sets the "highscore"-time equal to the persistend highscore from a previous session on start
        time = PlayerPrefs.GetFloat("HighScoreTime");
    }
    //other achievement states can be stored in a similar way
    //PlayerPrefs.DeleteAll(); can be used on a button to delete all the stored achievement-values
}

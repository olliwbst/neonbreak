using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    /*the functions here are called by UI-elements in the level scene(s), more can be added if needed*/
    public void SwitchToMainMenu()
    {
        SceneManager.LoadSceneAsync("MainMenu");
    }
}

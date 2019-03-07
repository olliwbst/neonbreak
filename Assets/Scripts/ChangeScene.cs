using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public List<GameObject> uilist;
    public Texture2D cursorTexture;
    
    private Vector2 cursorHotspot;
    
    //set the cursor and move its hotspot to the center
    private void Start()
    {
        cursorHotspot = new Vector2 (cursorTexture.width / 2, cursorTexture.height / 2);
        Cursor.SetCursor(cursorTexture, cursorHotspot, CursorMode.Auto);
    
    }

    //load a new scene in case i need it again
    public void ChangeCurrentScene(string sceneName)
    {
        SceneManager.LoadSceneAsync(sceneName);
    }
    
    //quits the game
    public void Quit()
    {
        Application.Quit();
    }
    
    //starts the first level
    public void StartGame()
    {
        Time.timeScale = 1; //set time to 1 in case it's still 0 from another script
        GameManager.instance.firststart = false; //if scene is loaded while game runs, splashscreen is disabled
        SceneManager.LoadSceneAsync("Level1"); //load levelscene
    }
    //transitions to different ui-screens here
    public void ShowCredits()
    {
        uilist[0].SetActive(false);
        uilist[1].SetActive(false);
        uilist[2].SetActive(false);
        uilist[3].SetActive(false);
        uilist[4].SetActive(true);
        uilist[5].SetActive(false);
    }

    public void ShowMenu()
    {
        uilist[0].SetActive(true);
        uilist[1].SetActive(false);
        uilist[2].SetActive(false);
        uilist[3].SetActive(false);
        uilist[4].SetActive(false);
        uilist[5].SetActive(false);
    }
    
    public void ShowOptions()
    {
        uilist[0].SetActive(false);
        uilist[1].SetActive(false);
        uilist[2].SetActive(false);
        uilist[3].SetActive(true);
        uilist[4].SetActive(false);
        uilist[5].SetActive(false);
    }
    
    public void ShowAchievements()
    {
        uilist[0].SetActive(false);
        uilist[1].SetActive(false);
        uilist[2].SetActive(false);
        uilist[3].SetActive(false);
        uilist[4].SetActive(false);
        uilist[5].SetActive(true);
    }
}

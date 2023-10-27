using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseGameScript : MonoBehaviour
{
    public GameObject pasueMenu;
    public static bool gamePaused = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !gamePaused && !EndOfGameScript.gameEnded)
        {
            gamePaused = true;
            pasueMenu.SetActive(true);
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && gamePaused)
        {
            Resume();
        }
        if (gamePaused)
        {
            //do this in some other way to not get bugs
            Time.timeScale = 0;
        }
        else Time.timeScale = 1;
    }   
    public void Resume()
    {
        gamePaused = false;
        pasueMenu.SetActive(false);
    }
}

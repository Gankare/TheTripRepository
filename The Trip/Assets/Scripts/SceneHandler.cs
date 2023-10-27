using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using System.Diagnostics;

public class SceneHandler : MonoBehaviour
{
    public Image fade;
    private PauseGameScript pauseScript;
    private void Start()
    {
        if (SceneManager.GetActiveScene().name == "Menu")
        {
            CameraFollow.currentStage = 1;
        }
        fade.CrossFadeAlpha(1, 0, true);
        pauseScript = FindObjectOfType<PauseGameScript>();
    }
    public void StartGame()
    {
        StartCoroutine(StartGameAfter());
    }
    public void ReturnToMenu()
    {
        StartCoroutine(GoToMenuAfter());
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void ResumeGame()
    {
        pauseScript.Resume();
    }
    IEnumerator StartGameAfter()
    {
        fade.CrossFadeAlpha(255, 1, true);
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(1);
    }
    IEnumerator GoToMenuAfter()
    {
        PauseGameScript.gamePaused = false;
        fade.CrossFadeAlpha(255, 1, true);
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("Menu");
    }
}


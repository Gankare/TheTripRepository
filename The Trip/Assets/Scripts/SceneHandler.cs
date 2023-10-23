using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class SceneHandler : MonoBehaviour
{
    public Image fade;
    private PauseGameScript pauseScript;
    private void Start()
    {
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
        Debug.Log("GameQuit");
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
        SceneManager.LoadScene("GameScene");
    }
    IEnumerator GoToMenuAfter()
    {
        PauseGameScript.gamePaused = false;
        fade.CrossFadeAlpha(255, 1, true);
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("MenuScene");
    }
}


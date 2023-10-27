using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndOfGameScript : MonoBehaviour
{
    public GameObject interactText;
    private bool inArea;
    public Image endGameFade;
    public GameObject endGameText1;
    public GameObject endGameText2;
    private AudioSource endGameSound;
    public static bool gameEnded;

    private void Start()
    { 
        gameEnded = false;
        endGameSound = GetComponent<AudioSource>();
        endGameFade.CrossFadeAlpha(1, 0, true);
    }
    void Update()
    {
        if (inArea && Input.GetKeyDown(KeyCode.E))
        {
            StartCoroutine(EndGame());
        }
    }
    public IEnumerator EndGame()
    {
        gameEnded = true;
        endGameSound.PlayOneShot(endGameSound.clip);
        endGameFade.CrossFadeAlpha(255, 2, true);
        yield return new WaitForSeconds(2);
        endGameText1.SetActive(true);
        yield return new WaitForSeconds(2);
        endGameText1.SetActive(false);
        endGameText2.SetActive(true);
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("Menu");
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            interactText.SetActive(true);
            inArea = true;
        }
    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            interactText?.SetActive(false);
            inArea = false;
        }
    }
}

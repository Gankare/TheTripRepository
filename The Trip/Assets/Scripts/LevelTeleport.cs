using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class LevelTeleport : MonoBehaviour
{
    public GameObject interactText;
    public GameObject mainCamera;
    public Transform player;
    public Transform area1;
    public Transform area2;
    public Transform area3;
    public Transform area4;
    public GameObject highEffect1;
    public GameObject highEffect2;
    public GameObject highEffect3;
    public GameObject highEffect4;
    public static bool cutScene = false;
    private bool inArea;

    
    public void Update()
    {
        if (inArea && Input.GetKeyDown(KeyCode.E))
        {
            if (mainCamera.GetComponent<CameraFollow>().currentStage == 1)
            {
                StartCoroutine(HighEffectLevel1());
                player.position = area1.transform.position;
            }

            if (mainCamera.GetComponent<CameraFollow>().currentStage == 2)
            {
                StartCoroutine(HighEffectLevel2());
                player.position = area2.transform.position;
            }

            if (mainCamera.GetComponent<CameraFollow>().currentStage == 3)
            {
                StartCoroutine(HighEffectLevel3());
                player.position = area3.transform.position;
            }

            if (mainCamera.GetComponent<CameraFollow>().currentStage == 4)
            {
                StartCoroutine(HighEffectLevel4());
                player.position = area4.transform.position;
            }

            mainCamera.GetComponent<CameraFollow>().currentStage++;
        }
    }
    public IEnumerator HighEffectLevel1()
    {
        cutScene = true;
        highEffect1.SetActive(true);
        yield return new WaitForSeconds(3);
        highEffect1.SetActive(false);
        cutScene = false;
    }
    public IEnumerator HighEffectLevel2()
    {
        cutScene = true;
        highEffect2.SetActive(true);
        yield return new WaitForSeconds(3);
        highEffect2.SetActive(false);
        cutScene = false;
    }
    public IEnumerator HighEffectLevel3()
    {
        cutScene = true;
        highEffect3.SetActive(true);
        yield return new WaitForSeconds(3);
        highEffect3.SetActive(false);
        cutScene = false;
    }
    public IEnumerator HighEffectLevel4()
    {
        cutScene = true;
        highEffect4.SetActive(true);
        yield return new WaitForSeconds(3);
        highEffect4.SetActive(false);
        cutScene = false;
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
            inArea = false;
            interactText?.SetActive(false);
        }
    }
}

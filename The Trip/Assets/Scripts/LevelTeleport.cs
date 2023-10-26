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
    private bool inArea;

    public void Update()
    {
        if (inArea && Input.GetKeyDown(KeyCode.E))
        {
            if (mainCamera.GetComponent<CameraFollow>().currentStage == 1)
            {
                player.position = area1.transform.position;
            }

            if (mainCamera.GetComponent<CameraFollow>().currentStage == 2)
            {
                player.position = area2.transform.position;
            }

            if (mainCamera.GetComponent<CameraFollow>().currentStage == 3)
            {
                player.position = area3.transform.position;
            }

            if (mainCamera.GetComponent<CameraFollow>().currentStage == 4)
            {
                player.position = area4.transform.position;
            }

            mainCamera.GetComponent<CameraFollow>().currentStage++;
        }
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

using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class LevelTeleport : MonoBehaviour
{
    public GameObject mainCamera;
    public Transform area1;
    public Transform area2;
    public Transform area3;
    public Transform area4;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (mainCamera.GetComponent<CameraFollow>().currentStage == 1)
            {
                collision.transform.position = area1.transform.position;
            }

            if (mainCamera.GetComponent<CameraFollow>().currentStage == 2)
            {
                collision.transform.position = area2.transform.position;
            }

            if (mainCamera.GetComponent<CameraFollow>().currentStage == 3)
            {
                collision.transform.position = area3.transform.position;
            }

            if (mainCamera.GetComponent<CameraFollow>().currentStage == 4)
            {
                collision.transform.position = area4.transform.position;
            }

            mainCamera.GetComponent<CameraFollow>().currentStage++;
        }
    }
}
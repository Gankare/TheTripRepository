using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public float FollowSpeed = 2f;
    public float yOffset = 1f;
    public Transform player;
    public Vector3 minValues, maxValue;
    public int currentStage = 1;

    // Update is called once per frame
    void Update()
    {
        switch (currentStage)
        {
            case 1:
                minValues = new Vector3(-5.2f, -2.1f, -10f);
                maxValue = new Vector3(16.47f, 8.4f, -10f);
                break;
            case 2:
                minValues = new Vector3(84.95f, -1.65f, -10f);
                maxValue = new Vector3(106.81f, 10.5f,-10f);
                break;
            case 3:
                minValues = new Vector3(-1000f, -1000f, -10f);
                maxValue = new Vector3(1000f, 1000f, -10f);
                break;
            case 4:
                minValues = new Vector3(-1000f, -1000f, -10f);
                maxValue = new Vector3(1000f, 1000f, -10f);
                break;
            
            default:
                minValues = new Vector3(-1000f, -1000f, -10f);
                maxValue = new Vector3(1000f, 1000f, -10f);
                break;
    
        }

        Vector3 boundPosition = new Vector3(
                Mathf.Clamp(player.position.x, minValues.x, maxValue.x),
                Mathf.Clamp(player.position.y, minValues.y, maxValue.y),
                Mathf.Clamp(player.position.z, minValues.z, maxValue.z));

        Vector3 newPos = new Vector3(player.position.x, player.position.y + yOffset, -10f);
        transform.position = Vector3.Slerp(transform.position, boundPosition, FollowSpeed * Time.deltaTime);

    }
}

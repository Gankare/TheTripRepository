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
    public GameObject bounds;
    public GameObject bounds1;
    public GameObject bounds2;
    public GameObject bounds3;
    public GameObject bounds4;
    public GameObject bounds5;
    public static int currentStage;
    float width;
    float height;

    private void Start()
    {
        if (currentStage == 0)
            currentStage = 1;
    }
    void Update()
    {
        Debug.Log(currentStage);
        switch (currentStage)
        {
            case 1:
                width = bounds.GetComponent<SpriteRenderer>().bounds.size.x;
                height = bounds.GetComponent<SpriteRenderer>().bounds.size.y;

                minValues = new Vector3(bounds.transform.position.x - width / 6.2f,
                    bounds.transform.position.y - height / 7, -10f);
                maxValue = new Vector3(bounds.transform.position.x + width / 6.5f,
                    bounds.transform.position.y + height / 7, -10f);
                break;
            case 2:
                width = bounds1.GetComponent<SpriteRenderer>().bounds.size.x;
                height = bounds1.GetComponent<SpriteRenderer>().bounds.size.y;

                minValues = new Vector3(bounds1.transform.position.x - width / 4f,
                    bounds1.transform.position.y - height / 3.4f, -10f);
                maxValue = new Vector3(bounds1.transform.position.x + width / 3.6f,
                    bounds1.transform.position.y + height / 3.4f, -10f);
                break;
            case 3:
                width = bounds2.GetComponent<SpriteRenderer>().bounds.size.x;
                height = bounds2.GetComponent<SpriteRenderer>().bounds.size.y;

                minValues = new Vector3(bounds2.transform.position.x - width / 4f,
                    bounds2.transform.position.y - height / 3.4f, -10f);
                maxValue = new Vector3(bounds2.transform.position.x + width / 3.6f,
                    bounds2.transform.position.y + height / 3.4f, -10f);
                break;
            case 4:
                width = bounds3.GetComponent<SpriteRenderer>().bounds.size.x;
                height = bounds3.GetComponent<SpriteRenderer>().bounds.size.y;

                minValues = new Vector3(bounds3.transform.position.x - width / 4f,
                    bounds3.transform.position.y - height / 3.4f, -10f);
                maxValue = new Vector3(bounds3.transform.position.x + width / 3.6f,
                    bounds3.transform.position.y + height / 3.4f, -10f);
                break;
            case 5:
                width = bounds4.GetComponent<SpriteRenderer>().bounds.size.x;
                height = bounds4.GetComponent<SpriteRenderer>().bounds.size.y;

                minValues = new Vector3(bounds4.transform.position.x - width / 6.2f,
                    bounds4.transform.position.y - height / 7, -10f);
                maxValue = new Vector3(bounds4.transform.position.x + width / 6.5f,
                    bounds4.transform.position.y + height / 7, -10f);
                break;
            case 6:
                width = bounds5.GetComponent<SpriteRenderer>().bounds.size.x;
                height = bounds5.GetComponent <SpriteRenderer>().bounds.size.y;

                minValues = new Vector3(bounds5.transform.position.x - width / 4,
                    bounds5.transform.position.y - height / 2, -10f);
                maxValue = new Vector3(bounds5.transform.position.x + width / 4,
                    bounds5.transform.position.y + height / 4, -10f);
                break;

            default:
                minValues = new Vector3(-1000f, -1000f, -10f);
                maxValue = new Vector3(1000f, 1000f, -10f);
                break;
    
        }
    }
    public void FixedUpdate()
    {
        Vector3 boundPosition = new Vector3(
                Mathf.Clamp(player.position.x, minValues.x, maxValue.x),
                Mathf.Clamp(player.position.y, minValues.y, maxValue.y),
                Mathf.Clamp(player.position.z, minValues.z, maxValue.z));

        transform.position = Vector3.Slerp(transform.position, boundPosition, FollowSpeed * Time.deltaTime);
    }
}

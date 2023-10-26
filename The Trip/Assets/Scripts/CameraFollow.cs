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
    public GameObject bounds1;
    public GameObject bounds2;
    public GameObject bounds3;
    public GameObject bounds4;
    public int currentStage = 1;
    float width;
    float height;

    // Update is called once per frame
    void Update()
    {
        switch (currentStage)
        {
            case 1:
                width = bounds1.GetComponent<SpriteRenderer>().bounds.size.x;
                height = bounds1.GetComponent<SpriteRenderer>().bounds.size.y;

                minValues = new Vector3(bounds1.transform.position.x - width / 4,
                    bounds1.transform.position.y - height / 2, -10f);
                maxValue = new Vector3(bounds1.transform.position.x + width / 4,
                    bounds1.transform.position.y + height / 2, -10f);
                break;
            case 2:
                width = bounds2.GetComponent<SpriteRenderer>().bounds.size.x;
                height = bounds2.GetComponent<SpriteRenderer>().bounds.size.y;

                minValues = new Vector3(bounds2.transform.position.x - width / 4,
                    bounds2.transform.position.y - height / 2, -10f);
                maxValue = new Vector3(bounds2.transform.position.x + width / 4,
                    bounds2.transform.position.y + height / 2, -10f);
                break;
            case 3:
                width = bounds3.GetComponent<SpriteRenderer>().bounds.size.x;
                height = bounds3.GetComponent<SpriteRenderer>().bounds.size.y;

                minValues = new Vector3(bounds3.transform.position.x - width / 4,
                    bounds3.transform.position.y - height / 2, -10f);
                maxValue = new Vector3(bounds3.transform.position.x + width / 4,
                    bounds3.transform.position.y + height / 2, -10f);
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

<<<<<<< Updated upstream
        Vector3 newPos = new Vector3(player.position.x, player.position.y + yOffset, -10f);
        transform.position = Vector3.Slerp(transform.position, newPos, FollowSpeed * Time.deltaTime);
=======
        //Vector3 newPos = new Vector3(player.position.x, player.position.y + yOffset, -10f);
        transform.position = Vector3.Slerp(transform.position, boundPosition, FollowSpeed * Time.deltaTime);
>>>>>>> Stashed changes

    }
}

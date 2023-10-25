using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialScript : MonoBehaviour
{
    public GameObject pickUpText;
    void Start()
    {
        pickUpText.SetActive(false);
    }
    public void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.tag == "Player" && !GrabOjectScript.holding)
        {
            pickUpText.SetActive(true);
            UpdateRotation();
        }
        else if (GrabOjectScript.holding)
            pickUpText.SetActive(false);
    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
            pickUpText.SetActive(false);
    }
    public void UpdateRotation()
    {
        transform.eulerAngles = new Vector3(0, 0, 0);
    }
}

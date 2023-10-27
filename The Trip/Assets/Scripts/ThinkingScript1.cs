using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThinkingScript1 : MonoBehaviour
{
    public GameObject thinking;

    public void OnTriggerStay2D(Collider2D collision)
    {
        thinking.SetActive(true);
    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        thinking.SetActive(false);
        Destroy(gameObject);
    }
}

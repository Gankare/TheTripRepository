using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabOjectScript : MonoBehaviour
{
    [SerializeField]
    private float rayDistance;
    public static bool holding;
    public Transform holdPoint, rayPoint;
    private GameObject grabbedObject;

    private int layerIndex;
    void Start()
    {
        layerIndex = LayerMask.NameToLayer("Grabbable");
    }

    void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(rayPoint.position, transform.right, rayDistance);
        Debug.DrawRay(rayPoint.position, transform.right, Color.green);

        if (hit.collider != null && hit.collider.gameObject.layer == layerIndex)
        {
            if (Input.GetKeyDown(KeyCode.LeftShift) && grabbedObject == null)
            {
                holding = true;
                grabbedObject = hit.collider.gameObject;
                grabbedObject.GetComponent<AudioSource>().Play();
                grabbedObject.transform.position = holdPoint.position;
                grabbedObject.GetComponent<Rigidbody2D>().isKinematic = true;
                grabbedObject.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
                grabbedObject.transform.SetParent(transform);
                grabbedObject.GetComponentInParent<Animator>().SetBool("Holding", true);
            }
        }
        if (Input.GetKeyUp(KeyCode.LeftShift) && grabbedObject != null)
        {
            holding = false;
            grabbedObject.GetComponent<AudioSource>().Play();
            grabbedObject.GetComponent<Rigidbody2D>().isKinematic = false;
            grabbedObject.GetComponentInParent<Animator>().SetBool("Holding", false);
            grabbedObject.GetComponentInParent<Animator>().SetTrigger("Throwing");
            grabbedObject.transform.SetParent(null);
            if (Movement.rightDirection)
                if(grabbedObject.tag == "ThrowingMushroom")
                    grabbedObject.GetComponent<Rigidbody2D>().velocity = new Vector2(10, 8);
                else
                    grabbedObject.GetComponent<Rigidbody2D>().velocity = new Vector2(5, 5);
            else
                if(grabbedObject.tag == "ThrowingMushroom")
                    grabbedObject.GetComponent<Rigidbody2D>().velocity = new Vector2(-10, 8);
                else
                    grabbedObject.GetComponent<Rigidbody2D>().velocity = new Vector2(-5, 5);

            grabbedObject = null;
        }
    }
}

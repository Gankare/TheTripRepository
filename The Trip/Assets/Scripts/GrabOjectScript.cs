using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabOjectScript : MonoBehaviour
{
    [SerializeField]
    private float rayDistance;

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
                grabbedObject = hit.collider.gameObject;
                grabbedObject.transform.position = holdPoint.position;
                grabbedObject.GetComponent<Rigidbody2D>().isKinematic = true;
                grabbedObject.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
                grabbedObject.transform.SetParent(transform);
            }
        }
        if (Input.GetKeyUp(KeyCode.LeftShift) && grabbedObject != null)
        {
            grabbedObject.GetComponent<Rigidbody2D>().isKinematic = false;
            grabbedObject.transform.SetParent(null);
            grabbedObject = null;
        }
    }
}

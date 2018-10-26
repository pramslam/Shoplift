using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastMaster : MonoBehaviour {

    public GameObject raycastObject;
    public LayerMask mask;
    public float castDistance;
    public float forwardOffset;
    
	// Update is called once per frame
	void Update () {

        if (Input.GetMouseButtonDown(0))
            Grab();

        if (Input.GetMouseButtonUp(0))
            Release();
    }

    void Grab()
    {
        //Debug.Log("Grab");
        CheckForHit();
    }

    void Release()
    {
        //Debug.Log("Release");
    }
    
    void CheckForHit()
    {
        RaycastHit hit;
        Vector3 offsetTransform = raycastObject.transform.position + (raycastObject.transform.forward * forwardOffset);         // Offsets the raycast start position forward.
        Vector3 forward = raycastObject.transform.TransformDirection(Vector3.forward) * castDistance;                           // Get forward direction
        //Debug.DrawRay(offsetTransform, forward * castDistance, Color.red, 10f, false);                                          // Draw debug ray

        if (Physics.Raycast(offsetTransform, forward, out hit, castDistance, mask))
        {
            //Debug.Log("Hit " + hit.collider);
        }
        else
        {
            //Debug.Log("Did not Hit!");
        }
    }
}

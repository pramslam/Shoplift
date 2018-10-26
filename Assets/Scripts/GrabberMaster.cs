using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabberMaster : MonoBehaviour {

    float castDistance = 1;
    float forwardOffset = 0.25f;

    public GameObject raycastObject;
    
	// Update is called once per frame
	void Update () {

        if (Input.GetMouseButtonDown(0))
            Grab();

        if (Input.GetMouseButtonUp(0))
            Release();
    }

    // Grab an item
    void Grab()
    {
        CheckForHit();
        // Place item in hand
        // Stow item in Inventory

        //Debug.Log("Grab");
    }

    // Release an item
    void Release()
    {
        // Place item in world

        //Debug.Log("Release");
    }
    
    void CheckForHit()
    {
        RaycastHit hit;
        Vector3 offsetTransform = raycastObject.transform.position + (raycastObject.transform.forward * forwardOffset);         // Offsets the raycast start position forward, prevents Raycast from hitting Player Controller
        Vector3 forward = raycastObject.transform.TransformDirection(Vector3.forward) * castDistance;                           // Get forward direction

        if (Physics.Raycast(offsetTransform, forward, out hit, castDistance))
        {
            Debug.DrawRay(offsetTransform, forward * hit.distance, Color.red, 10f, false);                                          // Draw debug ray
            Debug.Log("Hit " + hit.collider);
        }
        else
        {
            Debug.DrawRay(offsetTransform, forward * castDistance, Color.yellow, 10f, false);                                       // Draw debug ray
            Debug.Log("Did not Hit!");
        }
    }
}

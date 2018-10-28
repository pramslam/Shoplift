using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabberMaster : MonoBehaviour {

    private float castDistance = 1.1f;
    private float originOffset = 0.25f;             // Offsets the origin of raycast
    private Handling hand;

    public GameObject raycastObject;

    void Start()
    {
        hand = GameObject.FindObjectOfType<Handling>();
    }

    // Update is called once per frame
    void Update ()
    {
        if (Input.GetMouseButtonDown(0))
            Grab();

        if (Input.GetMouseButtonDown(1))
            Release();
        if (Input.GetKeyDown("e"))
            hand.Stow();
    }

    // Grab an item
    void Grab()
    {
        CheckForHit();
    }

    // Release an item
    void Release()
    {
        Debug.Log(hand.GetItems() + " item(s) held.");
    }

    void CheckForHit()
    {
        RaycastHit hit;
        Vector3 origin = raycastObject.transform.position + (raycastObject.transform.forward * originOffset);                   // Offsets the raycast start position forward, prevents Raycast from colliding with Player Controller
        Vector3 forward = raycastObject.transform.TransformDirection(Vector3.forward) * castDistance;                           // Get forward direction
        Ray ray = new Ray(origin, forward);

        if (Physics.Raycast(ray, out hit, castDistance))
        {
            if (hit.collider.gameObject.tag == "Item")
            {
                // Hits an item
                hand.AddItem(hit);
                Debug.DrawRay(ray.origin, ray.direction, Color.red, 10f, false);                // Draw debug ray
            }
            else
            {
                // Hits object but not an item
                Debug.Log("Did not Hit!");
                Debug.DrawRay(ray.origin, ray.direction, Color.yellow, 10f, false);             // Draw debug ray
            }
        }
        else
        {
            // Hits nothing
            Debug.Log("Did not Hit!");
            Debug.DrawRay(origin, forward * castDistance, Color.yellow, 10f, false);            // Draw debug ray
        }
    }
}

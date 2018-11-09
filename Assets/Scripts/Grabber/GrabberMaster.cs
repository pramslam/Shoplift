using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabberMaster : MonoBehaviour {

    private GameObject heldObject;
    private Handling hand;

    private bool holding = false;
    private float castDistance = 1.3f;
    private float originOffset = 0.25f;             // Distance of the raycast offset origin
    private float smooth = 10;                      // Smoothing rate of held item

    public GameObject raycastObject;

    void Start()    {
        hand = GameObject.FindObjectOfType<Handling>();
    }

    // Update is called once per frame
    void Update()    {
        if (holding)
        {
            Hold(heldObject);
            CheckRelease();
            CheckStow();
        }
        else
            CheckGrab();
    }

    // Updates the held item position in front of the player
    void Hold(GameObject item)    {
        item.transform.position = Vector3.Lerp(item.transform.position, raycastObject.transform.position + raycastObject.transform.forward, Time.deltaTime * smooth);
    }

    void CheckRelease()    {
        if (Input.GetMouseButtonDown(1))
            Release();
    }

    void CheckGrab()    {
        if (Input.GetMouseButtonDown(0))
            CheckForHit();
    }

    void CheckStow()    {
        if (Input.GetKeyDown("e"))
        {
            hand.Stow(heldObject);
            Release();
        }
    }

    void Release()
    {
        holding = false;
        heldObject.GetComponent<Rigidbody>().isKinematic = false;
        heldObject = null;
    }

    void CheckForHit()    {
        Vector3 origin = raycastObject.transform.position + (raycastObject.transform.forward * originOffset);                   // Offsets the raycast start position forward, prevents Raycast from colliding with Player Controller
        Vector3 forward = raycastObject.transform.TransformDirection(Vector3.forward) * castDistance;                           // Get forward direction

        RaycastHit hit;
        Ray ray = new Ray(origin, forward);

        if (Physics.Raycast(ray, out hit, castDistance))
        {
            Grabbable item = hit.collider.GetComponent<Grabbable>();
            if (item != null)
            {
                holding = true;
                heldObject = item.gameObject;
                heldObject.GetComponent<Rigidbody>().isKinematic = true;
                Physics.IgnoreCollision(raycastObject.GetComponentInParent<Collider>(), item.GetComponent<Collider>());         // Ignores collision between held object and player
                Debug.DrawRay(ray.origin, ray.direction, Color.green, 10f, false);                                              // Draw debug ray
            }
        }
    }
}

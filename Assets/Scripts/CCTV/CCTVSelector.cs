// Allows setting camera parameters in inspector
// Format for cameratype is camera tilt angle(30,45,60) then sweep(0,1)
// Example: 30deg tilt, short sweep is 300
//          45deg tilt, long sweep is 451
//          60deg tilt, short sweep is 600

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CCTVSelector : MonoBehaviour {

    bool doOnce = false;
    public bool disabled = false;
    public float speed = 1.0f;
    public int cameraType = 0;

    Animator animator;
    CCTVLight cctvLight;

	// Use this for initialization
	void Start () {
        animator = GetComponent<Animator>();
        cctvLight = gameObject.GetComponentInChildren<CCTVLight>();
    }

	// Update is called once per frame
	void Update () {
        if (disabled == true)
        {
            if (doOnce == true)
            {
                Deactivate();
                doOnce = false;
            }
        }
        else
        if (disabled == false)
        {
            if (doOnce == false)
            {
                Activate();
                doOnce = true;
            }
        }
    }

    void Activate()
    {
        animator.SetInteger("Camera Type", cameraType);
        animator.speed = speed;
        cctvLight.On();
    }

    void Deactivate()
    {
        animator.SetInteger("Camera Type", 0);          // Sets to shutdown animation
        cctvLight.Off();                                // turn off light
    }
}

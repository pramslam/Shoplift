using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CCTVSelector : MonoBehaviour {

    bool doOnce = false;
    public bool disabled = false;
    public float speed = 1.0f;
    public int cameraType = 0;

    Animator animator;

	// Use this for initialization
	void Start () {
        animator = GetComponent<Animator>();
	}

	// Update is called once per frame
	void Update () {
        if (doOnce == false) {
            Activate();
            doOnce = true;
        }
        
        if (disabled == true)
            Deactivate();
        else
        if (disabled == false)
            Activate();
    }

    void Activate()
    {
        animator.SetInteger("Camera Type", cameraType);
        animator.speed = speed;
    }

    void Deactivate()
    {
        animator.SetInteger("Camera Type", 0);          // Sets to shutdown animation
    }
}

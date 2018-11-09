//Controlls the cctv light

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CCTVLight : MonoBehaviour {

    private Light myLight;

	// Use this for initialization
	void Start () {
        myLight = GetComponent<Light>();
    }

    public void On()
    {
        myLight.enabled = true;
    }

    public void Off()
    {
        myLight.enabled = false;
    }
}

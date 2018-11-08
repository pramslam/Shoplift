using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CCTVPlayerDetection : MonoBehaviour {

    private GameObject player;
    private LastPlayerSighting lastPlayerSighting;

	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        lastPlayerSighting = GameObject.FindGameObjectWithTag("GameController").GetComponent<LastPlayerSighting>();
	}

    void OnTriggerStay(Collider other)    {
        if (other.gameObject == player)
        {
            Vector3 relPlayerPos = player.transform.position - transform.position;
            RaycastHit hit;

            if (Physics.Raycast(transform.position, relPlayerPos, out hit)) {
                if (hit.collider.gameObject == player) {
                    lastPlayerSighting.position = player.transform.position;
                    Debug.Log(gameObject.name + " Detected " + player);
                }
            }
        }
    }
}

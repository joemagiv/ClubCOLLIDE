using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfluenceCircle : MonoBehaviour {

    private Dancer dancer;

	// Use this for initialization
	void Start () {
        dancer = GetComponentInParent<Dancer>();
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Enter Detected " + other.name);
        if (other.tag == "Player")
        {
            dancer.playerInCircle = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log("Exit Detected " + other.name);
        if (other.tag == "Player")
        {
            dancer.playerInCircle = false;
        }

    }

    // Update is called once per frame
    void Update () {
		
	}
}

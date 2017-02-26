using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitWalls : MonoBehaviour {

    public Transform respawnPosition;

	// Use this for initialization
	void Start () {
		
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            other.transform.position = respawnPosition.position;
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            other.transform.position = respawnPosition.position;
        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}

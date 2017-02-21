using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shredder : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Dancer")
        {
            Dancer dancer = other.GetComponent<Dancer>();
            if (dancer.completedDancing)
            {
                Destroy(other.gameObject);
            }
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Dancer")
        {
            Dancer dancer = other.GetComponent<Dancer>();
            if (dancer.completedDancing)
            {
                Destroy(other.gameObject);
            }
        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}

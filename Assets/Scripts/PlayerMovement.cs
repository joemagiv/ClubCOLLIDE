using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    private Rigidbody2D rigidbody2d;
    public float force;

	// Use this for initialization
	void Start () {
        rigidbody2d = GetComponent<Rigidbody2D>();

	}
	
	// Update is called once per frame
	void Update () {


        if (Input.GetAxis("Vertical") == 1)
        {
            rigidbody2d.AddForce(new Vector2(0,force));
        }

        if (Input.GetAxis("Vertical") == -1)
        {
            rigidbody2d.AddForce(new Vector2(0, -force));
        }

        if (Input.GetAxis("Horizontal") == 1)
        {
            rigidbody2d.AddForce(new Vector2(force, 0));
        }

        if (Input.GetAxis("Horizontal") == -1)
        {
            rigidbody2d.AddForce(new Vector2(-force, 0));
        }
    }
}

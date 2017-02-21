using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dancer : MonoBehaviour {

  

    public bool playerInCircle;
    public bool dancing;

    public float reverseForce;

    private Rigidbody2D rb;

    public float timeBetweenListsSet;
    public float timeBetweenLists;

    public int currentDance;

    public float listingForce;

    private GameContoller gameController;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
        timeBetweenLists = timeBetweenListsSet;
        gameController = FindObjectOfType<GameContoller>().GetComponent<GameContoller>();

        currentDance = Mathf.FloorToInt(Random.Range(0, 4));

    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            Rigidbody2D playerRB = other.gameObject.GetComponent<Rigidbody2D>();
            playerRB.AddForce(new Vector2((playerRB.velocity.x+1) * reverseForce, (playerRB.velocity.y+1) * reverseForce));
        }
    }

    void ApplyListingForce()
    {
        //randomizes a bit of movement so dancers float around the dancefloor
        int randomDirection = Mathf.RoundToInt(Random.Range(0, 4));
        if (randomDirection == 0)
        {
            rb.AddForce(new Vector2(listingForce,0));
        }
        if (randomDirection == 1)
        {
            rb.AddForce(new Vector2(0, listingForce));
        }
        if (randomDirection == 2)
        {
            rb.AddForce(new Vector2(0, -listingForce));
        }
        if (randomDirection == 3)
        {
            rb.AddForce(new Vector2(-listingForce, 0));
        }
    }

    void DanceInitiated(int danceNumber)
    {
        Debug.Log("Dance " + danceNumber + " initiated");
        if (playerInCircle)
        {
            if (currentDance == danceNumber)
            {
                Debug.Log("Dance confirmed");
                gameController.AddToScore();
            }
            else
            {
                Debug.Log("Wrong Dance");
            }
        }
    }
	
   

	// Update is called once per frame
	void Update () {
		if (timeBetweenLists > 0)
        {
            timeBetweenLists -= Time.deltaTime;
        } else
        {
            timeBetweenLists = timeBetweenListsSet;
            ApplyListingForce();
        }

        if (Input.GetButtonDown("Fire1"))
        {
            if (playerInCircle)
            {
                Debug.Log("Dance initiated");
            }
            else
            {
                Debug.Log("Player not in dance radius");
            }
        }

        if (Input.GetKeyDown(KeyCode.I))
        {
            DanceInitiated(0);
        }

        if (Input.GetKeyDown(KeyCode.J))
        {
            DanceInitiated(1);
        }

        if (Input.GetKeyDown(KeyCode.K))
        {
            DanceInitiated(2);
        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            DanceInitiated(3);
        }
    }
}

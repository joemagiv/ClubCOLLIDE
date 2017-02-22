using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    private Rigidbody2D rigidbody2d;
    public float force;
    public Animator jetpackAnimator;
    private Animator playerAnimator;
    private GameContoller gameController;

    public float timeBetweenLists;
    public float timeBetweenListsSet;

    public bool playerDancing;


    // Use this for initialization
    void Start () {
        rigidbody2d = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
        gameController = FindObjectOfType<GameContoller>().GetComponent<GameContoller>();

	}

    void DanceInitiated(int danceNumber)
    {
        if (!playerDancing)
        {
            playerAnimator.SetTrigger("Dance" + danceNumber.ToString());
            
        }
    }

    public void DanceStarted()
    {
        playerDancing = true;
    }

    public void DanceComplete()
    {
        playerDancing = false;
    }

    void ApplyListingForce()
    {
        float listingForce = 20;
        int randomDirection = Mathf.RoundToInt(Random.Range(0, 4));
        if (randomDirection == 0)
        {
            rigidbody2d.AddForce(new Vector2(listingForce, 0));
        }
        if (randomDirection == 1)
        {
            rigidbody2d.AddForce(new Vector2(0, listingForce));
        }
        if (randomDirection == 2)
        {
            rigidbody2d.AddForce(new Vector2(0, -listingForce));
        }
        if (randomDirection == 3)
        {
            rigidbody2d.AddForce(new Vector2(-listingForce, 0));
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (gameController.gameStarted)
        {

            if (!gameController.jetpackDisable)
            {
                if (Input.GetAxis("Vertical") == 1)
                {
                    rigidbody2d.AddForce(new Vector2(0, force));
                    jetpackAnimator.SetBool("JetpackActive", true);
                }

                if (Input.GetAxis("Vertical") == -1)
                {
                    rigidbody2d.AddForce(new Vector2(0, -force));
                    jetpackAnimator.SetBool("JetpackActive", true);

                }

                if (Input.GetAxis("Horizontal") == 1)
                {
                    rigidbody2d.AddForce(new Vector2(force, 0));
                    jetpackAnimator.SetBool("JetpackActive", true);

                }

                if (Input.GetAxis("Horizontal") == -1)
                {
                    rigidbody2d.AddForce(new Vector2(-force, 0));
                    jetpackAnimator.SetBool("JetpackActive", true);

                }

                if (Input.GetAxis("Horizontal") == 0 && Input.GetAxis("Vertical") == 0)
                {
                    jetpackAnimator.SetBool("JetpackActive", false);
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
            else
            {
                if (timeBetweenLists > 0)
                {
                    timeBetweenLists -= Time.deltaTime;
                }
                else
                {
                    timeBetweenLists = timeBetweenListsSet;
                    ApplyListingForce();
                }
            }
        }
    }
}

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

    public Transform endingPosition;
    public float endingMoveSpeed;

    public bool playerDancing;

    private bool atFinalPosition;

    private BoxCollider2D playerCollider;

    // Use this for initialization
    void Start () {
        rigidbody2d = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
        gameController = FindObjectOfType<GameContoller>().GetComponent<GameContoller>();
        playerCollider = GetComponent<BoxCollider2D>();

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

    private int FinalDanceCalled;

    private void FinalDance() {
        FinalDanceCalled++;
        if (FinalDanceCalled == 1)
        {
            playerAnimator.SetTrigger("FinalDance");

            VidScreen[] vidscreens = FindObjectsOfType<VidScreen>();
            foreach (VidScreen vidscreen in vidscreens)
            {
                Animator anim = vidscreen.GetComponent<Animator>();
                anim.SetTrigger("Hearts");
            }
        }
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

        Debug.Log("Vertical " + Input.GetAxis("Vertical") + " Horizontal " + Input.GetAxis("Horizontal"));

        if (atFinalPosition)
        {
            playerAnimator.SetBool("FinalDance", true);
        }

        if (!gameController.gameEnding)
        {
            if (gameController.gameStarted)
            {

                if (!gameController.jetpackDisable)
                {
                    if (Input.GetAxis("Vertical") > 0.5f)
                    {
                        rigidbody2d.AddForce(new Vector2(0, force));
                        jetpackAnimator.SetBool("JetpackActive", true);
                    }

                    if (Input.GetAxis("Vertical") < -0.5f)
                    {
                        rigidbody2d.AddForce(new Vector2(0, -force));
                        jetpackAnimator.SetBool("JetpackActive", true);

                    }

                    if (Input.GetAxis("Horizontal") > 0.5f)
                    {
                        rigidbody2d.AddForce(new Vector2(force, 0));
                        jetpackAnimator.SetBool("JetpackActive", true);

                    }

                    if (Input.GetAxis("Horizontal") < -0.5f)
                    {
                        rigidbody2d.AddForce(new Vector2(-force, 0));
                        jetpackAnimator.SetBool("JetpackActive", true);

                    }

                    if (Input.GetAxis("Horizontal") == 0 && Input.GetAxis("Vertical") == 0)
                    {
                        jetpackAnimator.SetBool("JetpackActive", false);
                    }



                    if (Input.GetButtonDown("Dance0"))
                    {
                        DanceInitiated(0);
                    }

                    if (Input.GetButtonDown("Dance1"))
                    {
                        DanceInitiated(1);
                    }

                    if (Input.GetButtonDown("Dance2"))
                    {
                        DanceInitiated(2);
                    }

                    if (Input.GetButtonDown("Dance3"))
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
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, endingPosition.transform.position, endingMoveSpeed);
            playerCollider.enabled = false;
            jetpackAnimator.SetBool("JetpackActive", true);
            if (transform.position == endingPosition.position)
            {
                Invoke("FinalDance", 2f);
            }
        }
    } 
}

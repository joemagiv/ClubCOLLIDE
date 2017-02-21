using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dancer : MonoBehaviour {

  

    public bool playerInCircle;
    public bool dancing;

    public bool completedDancing;

    public float reverseForce;

    private Rigidbody2D rb;

    public float timeBetweenListsSet;
    public float timeBetweenLists;

    public float leavingDancefloorSpeed;
    public float secondsBeforeLeaving;

    public int currentDance;

    public float listingForce;

    private GameContoller gameController;

    public Animator jetpackAnimator;
    private Animator dancerAnimator;

    public SpriteRenderer statusSprite;

    public Sprite checkMark;
    public Sprite sadFace;

    private SpriteRenderer sprite;

    private Spawner parentSpawner;

    public PlayerMovement playerMovement;
    

	// Use this for initialization
	void Start () {
        parentSpawner = GetComponentInParent<Spawner>();
        rb = GetComponent<Rigidbody2D>();
        dancerAnimator = GetComponent<Animator>();
        playerMovement = FindObjectOfType<PlayerMovement>().GetComponent<PlayerMovement>();

        sprite = GetComponentInChildren<SpriteRenderer>();
        RandomizeColor();

        timeBetweenLists = timeBetweenListsSet;

        gameController = FindObjectOfType<GameContoller>().GetComponent<GameContoller>();

        currentDance = Mathf.FloorToInt(Random.Range(0, 4));
        dancerAnimator.SetTrigger("Dance" + currentDance.ToString());

        jetpackAnimator.SetBool("JetpackActive", true);

        if (gameController.jetpackDisable)
        {
            dancerAnimator.SetTrigger("Hover");
            jetpackAnimator.SetBool("JetpackActive", false);
        }

    }

    public void NewDance()
    {
        currentDance = Mathf.FloorToInt(Random.Range(0, 4));
        dancerAnimator.SetTrigger("Dance" + currentDance.ToString());

        jetpackAnimator.SetBool("JetpackActive", true);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Player"|| other.gameObject.tag == "Dancer")
        {
            Rigidbody2D playerRB = other.gameObject.GetComponent<Rigidbody2D>();
            playerRB.AddForce(new Vector2((playerRB.velocity.x+1) * reverseForce, (playerRB.velocity.y+1) * reverseForce));
        }
    }

    void RandomizeColor()
    {
        int randomColor = Mathf.FloorToInt(Random.Range(0, 5));

        if (randomColor == 0)
        {
            sprite.color = Color.blue;
        }
        if (randomColor == 1)
        {
            sprite.color = Color.red;
        }
        if (randomColor == 2)
        {
            sprite.color = Color.yellow;
        }
        if (randomColor == 3)
        {
            sprite.color = Color.magenta;
        }

        if (randomColor == 4)
        {
            sprite.color = Color.green;
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
        if (!completedDancing)
        {

            if (playerInCircle)
            {
                if (!playerMovement.playerDancing)
                {
                        if (currentDance == danceNumber)
                        {

                            gameController.AddToScore();
                            completedDancing = true;
                            statusSprite.sprite = checkMark;
                            parentSpawner.CallSpawner();
                        }
                        else
                        {

                            statusSprite.sprite = sadFace;
                        }
                    }
                }
            }
       }
    
	
   

	// Update is called once per frame
	void Update () {
        if (!completedDancing)
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
        } else
        {
            secondsBeforeLeaving -= Time.deltaTime;
            if (secondsBeforeLeaving < 0)
            {
                Transform shredderTransform = FindObjectOfType<Shredder>().GetComponent<Transform>();
                transform.position = Vector2.MoveTowards(transform.position, shredderTransform.position, leavingDancefloorSpeed);
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameContoller : MonoBehaviour {

    public Text scoreText;
    private int score;

    public float countdownToSwarm;

    public int swarmVolume;

    public bool swarmActive;


    public float countdownToHover;

    public bool hoverActive;

    public bool jetpackDisable;

    public bool gameStarted;

    public float timeBeforeGameEnding;

    public bool gameEnding;
    public bool gameOver;

    public GameObject finalDancer;

    public GameObject pushers;

    public float timeToGameOver;


    // Use this for initialization
    void Start () {
        score = 0;
        finalDancer.SetActive(false);
        pushers.SetActive(false);
	}

    public void AddToScore()
    {
        score++;
    }

    private void SwarmGeneration()
    {
        Spawner[] spawners = FindObjectsOfType<Spawner>();
        foreach (Spawner spawner in spawners)
        {
            int spawnsLeft = swarmVolume;
            while (spawnsLeft > 0)
            {
                spawnsLeft--;
                spawner.SpawnDancer();
            }
        }
    }

    private void SetPlayerHover()
    {
        Animator playerAnimator = FindObjectOfType<PlayerMovement>().GetComponent<Animator>();
        playerAnimator.SetTrigger("Hover");


        Dancer[] dancers = FindObjectsOfType<Dancer>();

        foreach (Dancer dancer in dancers)
        {
            Animator dancerAnimator = dancer.GetComponent<Animator>();
            dancerAnimator.SetTrigger("Hover");
        }

        Jetpack[] jetpacks = FindObjectsOfType<Jetpack>();

        foreach (Jetpack jetpack in jetpacks)
        {
            Animator jetpackAnimator = jetpack.GetComponent<Animator>();
            jetpackAnimator.SetTrigger("Hover");
        }

        
    }

    void RestartDancers()
    {
        Dancer[] dancers = FindObjectsOfType<Dancer>();

        foreach (Dancer dancer in dancers)
        {
            dancer.NewDance();
        }
    }


	
	// Update is called once per frame
	void Update () {

        timeToGameOver -= Time.deltaTime;

        if (timeToGameOver <= 0)
        {
            int scene = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(scene, LoadSceneMode.Single);
        }

        if (!gameEnding)
        {
            timeBeforeGameEnding -= Time.deltaTime;

            if (timeBeforeGameEnding <= 0)
            {
                gameEnding = true;
                finalDancer.SetActive(true);
            }
        }


		if(score == 0)
        {
            scoreText.text = "";
        }
        else
        {
            if (!jetpackDisable)
            {
                scoreText.text = score.ToString();
            } else
            {
                scoreText.text = score.ToString() + "\n Jetpacks Disabled!";
            }
        }

        if (!hoverActive)
        {
            countdownToHover -= Time.deltaTime;
            if (countdownToHover < 0)
            {
                hoverActive = true;
                SetPlayerHover();
                jetpackDisable = true;
            }
        }

        if (!swarmActive)
        {
            if (countdownToSwarm < 18)
            {
                
                if (jetpackDisable)
                {
                    jetpackDisable = false;
                    RestartDancers();
                }
            }
            countdownToSwarm -= Time.deltaTime;
            if (countdownToSwarm < 0)
            {
                pushers.SetActive(true);
                swarmActive = true;
                SwarmGeneration();
            }
        }
	}
}

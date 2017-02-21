using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameContoller : MonoBehaviour {

    public Text scoreText;
    private int score;


	// Use this for initialization
	void Start () {
        score = 0;
	}

    public void AddToScore()
    {
        score++;
    }
	
	// Update is called once per frame
	void Update () {
		if(score == 0)
        {
            scoreText.text = "";
        }
        else
        {
            scoreText.text = score.ToString();
        }
	}
}

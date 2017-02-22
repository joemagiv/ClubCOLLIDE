using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Intro : MonoBehaviour {


    private GameContoller gamecontroller;

	// Use this for initialization
	void Start () {
        gamecontroller = FindObjectOfType<GameContoller>().GetComponent<GameContoller>();
		
	}

    public void StartGame()
    {
        gamecontroller.gameStarted = true;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}

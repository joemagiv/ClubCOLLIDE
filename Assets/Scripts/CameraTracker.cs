using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTracker : MonoBehaviour {

    public Transform player;
    private Vector3 offset;
    private GameContoller gamecontroller;

	// Use this for initialization
	void Start () {
        offset = transform.position - player.transform.position;
        gamecontroller = FindObjectOfType<GameContoller>().GetComponent<GameContoller>();
	}
	
	// Update is called once per frame
	void Update () {
        if (gamecontroller.gameStarted)
        {
            transform.position = new Vector3(Mathf.Clamp(player.transform.position.x, -2.81f, 2.9f), Mathf.Clamp(player.transform.position.y, -20.1f, 20.3f), -10f);
        }
      }
}

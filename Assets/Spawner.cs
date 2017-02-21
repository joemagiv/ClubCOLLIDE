using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    public GameObject dancerPrefab;



	// Use this for initialization
	void Start () {
		
	}

    public void CallSpawner()
    {
        Invoke("SpawnDancer", 7f);
    }

    public void SpawnDancer()
    {
        GameObject Dancer = Instantiate(dancerPrefab, transform.position, Quaternion.identity) as GameObject;
        Dancer.transform.parent = this.transform;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}

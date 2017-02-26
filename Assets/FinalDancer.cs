using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalDancer : MonoBehaviour {

    public Animator jetpackAnimator;

    // Use this for initialization
    void Start () {
        jetpackAnimator.SetBool("JetpackActive", true);

    }

    // Update is called once per frame
    void Update () {
        jetpackAnimator.SetBool("JetpackActive", true);

    }
}

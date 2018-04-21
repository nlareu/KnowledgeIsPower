using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller_NextQuestion : MonoBehaviour {

    public Question_Show questions;

	// Use this for initialization
	void Start () {
    }

    // Update is called once per frame
    void Update () {
        if (Input.GetKeyDown("n"))
        {
            this.questions.changing = true;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller_NextQuestion : MonoBehaviour {

    private Question_Show questions;

	// Use this for initialization
	void Start () {
        GameObject g = GameObject.Find("QuestionsHolder");

        this.questions = g.GetComponent<Question_Show>();
    }

    // Update is called once per frame
    void Update () {
        if (Input.GetKeyDown("n"))
        {
            this.questions.changing = true;
        }
    }
}

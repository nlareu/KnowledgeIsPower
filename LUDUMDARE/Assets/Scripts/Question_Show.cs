using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Question_Show : MonoBehaviour {

    public GameObject q1;
    public GameObject q2;
    public GameObject q3;
    private int currentQ;

    // Use this for initialization
    void Start () {
        this.q1.SetActive(false);
        this.q2.SetActive(false);
        this.q3.SetActive(false);

        this.currentQ = 1;

        this.q1.SetActive(true);
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown("p"))
        {
            switch (this.currentQ)
            {
                case 1:
                    this.q1.SetActive(false);
                    this.q2.SetActive(true);

                    this.currentQ = 2;
                    break;
                case 2:
                    this.q2.SetActive(false);
                    this.q3.SetActive(true);

                    this.currentQ = 3;
                    break;
                case 3:
                    this.q3.SetActive(false);
                    this.q1.SetActive(true);

                    this.currentQ = 1;
                    break;
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverPanel_Class : MonoBehaviour {

    public Text FinalPointsText;

    // Use this for initialization
    void Start () {
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SetFinalPoints(int points)
    {
        this.FinalPointsText.text = "Points: " + points.ToString();

        this.gameObject.SetActive(true);
    }
}

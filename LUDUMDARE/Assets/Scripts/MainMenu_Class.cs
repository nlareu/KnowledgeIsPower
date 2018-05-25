using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu_Class : MonoBehaviour {

    public AppController_Class AppController;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //Wait for any key input to start the game play.
        if (Input.anyKey)
        {
            this.gameObject.SetActive(false);

            this.AppController.StartGamePlay();
        }
    }
}

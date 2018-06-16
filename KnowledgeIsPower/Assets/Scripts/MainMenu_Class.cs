using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class MainMenu_Class : MonoBehaviour {

    public AppController_Class AppController;

    private AudioSource audioSource_backgroundMusic;


    // Use this for initialization
    void Start () {
        this.audioSource_backgroundMusic = this.gameObject.AddComponent<AudioSource>();

        this.audioSource_backgroundMusic.Play();
    }
	
	// Update is called once per frame
	void Update () {
        //Wait for any key input to start the game play.
        if (Input.anyKey)
        {
            //this.audioSource_backgroundMusic.Stop();

            this.gameObject.SetActive(false);

            this.AppController.StartGamePlay();
        }
    }
}

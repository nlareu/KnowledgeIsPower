﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PresentationPanel_Class : MonoBehaviour {



	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void DisplayPresentation(PresentatioLevel_Class presentation, Action onCompleteCallback)
    {
        this.gameObject.SetActive(true);

        presentation.Display(onCompleteCallback);
    }
}

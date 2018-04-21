using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Patron : MonoBehaviour {
	public float Enemy_RateOfSpawn;
	public bool isred;
	public bool isblue;

	public Transform[] target;

	public float Patron_AssignableSpeedOfMovement;
	// Use this for initialization
	void Start () {
		if (isred) {
			isblue = false;
		}
		if (isblue) {
			isred = false;
		}
	}
	
	// Update is called once per frame
	void Update () {
	//	if (transform.position != target[current]) {
			
	//	}
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Clase : MonoBehaviour {
	public int Enemy_Color;
	public int Enemy_Life;
	public float Shoot_Time_Left= 1.5f;

	void Start () {
//		if ("fución ") {
//			Enemy_Life = 1;

//		}
	}
	
	// Update is called once per frame
	void Update () {

		Shoot_Time_Left -= Time.deltaTime;
		if ( Shoot_Time_Left < 0 )
		{
//			Shoot();
		}
	}

	void OnCollisionEnter2D(Collision2D coll) {
//		if (coll.gameObject.tag == "Enemy")
//			coll.gameObject.hurt_enemy ("actual player weapon");
	}
}


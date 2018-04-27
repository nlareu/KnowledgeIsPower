using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Clase : MonoBehaviour {
	public int Enemy_Color = 1;
	public int Enemy_Life;
	public float Shoot_Time_Left= 1.5f;
	public Rigidbody2D rbody;

	void Start () {
//		if ("fución ") {
//			Enemy_Life = 1;

//		}
		rbody = this.GetComponent<Rigidbody2D>();

	}
	
	// Update is called once per frame
	void Update () {
		/*
		Shoot_Time_Left -= Time.deltaTime;
		if ( Shoot_Time_Left < 0 )
		{
//			Shoot();
		}
		*/
	}

	void OnTriggerEnter2D(Collider2D coll) {
		if (coll.gameObject.tag == "Bullet") {
			//	coll.gameObject.hurt_enemy ("actual player weapon");
			AppController.InformEnemyDestroyed (this);

			Destroy (this.gameObject);
		}
		//	Destroy(coll.gameObject);
	}
}


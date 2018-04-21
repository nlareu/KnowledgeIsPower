using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Spawner : MonoBehaviour {
	public GameObject Enemy;
	public float enemyspawnrate = 2f;
	public GameObject spawn;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		

	
		enemyspawnrate -= Time.deltaTime;
		if ( enemyspawnrate < 0 )
		{
			GameObject santiago;
			santiago = Instantiate(Enemy, spawn.transform.position, Quaternion.identity) as GameObject;
			santiago.transform.gameObject.tag = "Enemy";
			enemyspawnrate = 2f;
		}
	}


	void OnCollisionEnter2D(Collision2D coll) {
//		if (coll.gameObject.tag == "Enemy")
//			coll.gameObject.hurt_enemy ("actual player weapon");
	}
}

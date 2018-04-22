using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Spawner : MonoBehaviour {
	public GameObject Enemy;
	public float enemyspawnrate = 2f;
	public GameObject spawn;

	public GameObject[] ListOfWaypoints1;
	public GameObject[] ListOfWaypoints2;
	public GameObject[] ListOfWaypoints3;

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
			santiago.GetComponent<Waypointlist>().ListOfWaypoints[0] = ListOfWaypoints1[0];
			santiago.GetComponent<Waypointlist>().ListOfWaypoints[1] = ListOfWaypoints1[1];
			santiago.GetComponent<Waypointlist>().ListOfWaypoints[2] = ListOfWaypoints1[2];

			GameObject rodrigo;
			rodrigo = Instantiate(Enemy, spawn.transform.position, Quaternion.identity) as GameObject;
			rodrigo.transform.gameObject.tag = "Enemy";
			rodrigo.GetComponent<Waypointlist>().ListOfWaypoints[0] = ListOfWaypoints2[0];
			rodrigo.GetComponent<Waypointlist>().ListOfWaypoints[1] = ListOfWaypoints2[1];
			rodrigo.GetComponent<Waypointlist>().ListOfWaypoints[2] = ListOfWaypoints2[2];

			enemyspawnrate = 2f;
		}
	}


	void OnCollisionEnter2D(Collision2D coll) {
//		if (coll.gameObject.tag == "Enemy")
//			coll.gameObject.hurt_enemy ("actual player weapon");
	}
}

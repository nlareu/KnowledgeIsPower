using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypointlist : MonoBehaviour {

	// public GameObject InitialWaypoint;
	public GameObject[] ListOfWaypoints;
	public int StartIndex;
	public bool LoopList;
	public System.Type[] MonoBehavioursCallback;

	private int currentWaypointIndex;
	private GameObject _currentWaypont;
	private GameObject _nextWaypoint;

	public float Enemy_Velocity;

	// private float time = 1.0f;
	private float timer = 5.0f;
	// Use this for initialization
	void Start () {
		Enemy_Velocity = 0.25f;
		_currentWaypont = transform.gameObject;
		_nextWaypoint = ListOfWaypoints[StartIndex];
	}

	// Update is called once per frame
	void Update () {
		if (_nextWaypoint != null) {
			timer += Time.deltaTime*Enemy_Velocity;
			Vector2 initPos = _currentWaypont.transform.position;
			Vector2 endPos = _nextWaypoint.transform.position;
			var newPos = Vector2.Lerp (initPos, endPos, timer);

			transform.position = newPos;




		}
		if (timer >= 1.0f) {
			timer = 0;
			_currentWaypont = _nextWaypoint;

			currentWaypointIndex++;
			if (currentWaypointIndex == ListOfWaypoints.Length)
				currentWaypointIndex = 0;

			if (!LoopList && StartIndex == currentWaypointIndex) {
				/*
				 * Bug:
				 * 	I couldn't make a foreach of <T> so I'll enabled every MonoBehaviour
				 * 	from the enemies. In the future I should look at this
				 * 
				foreach (var mono in MonoBehavioursCallback) {
					GetComponent<typeof(mono)> ().enabled = true;
				}
				*/


				this.enabled = false;
			} else {
				_nextWaypoint = ListOfWaypoints [currentWaypointIndex];
			}

		}
	}
}
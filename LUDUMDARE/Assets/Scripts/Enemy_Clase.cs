using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Clase : MonoBehaviour {

    public Question_Class QuestionOwner;
    public int Enemy_Color = 1;
    public float Enemy_Velocity = 0.25f;
    public List<GameObject> ListOfWaypoints;
    public int StartIndex = 0;
    //public bool LoopList;

    //public int Enemy_Life;
    //public float Shoot_Time_Left= 1.5f;
    //public Rigidbody2D rbody;

    public List<Vector2> waypoints;
    private int currentWaypointIndex;
    private Vector2 _currentWaypont;
    private Vector2 _nextWaypoint;
    private float timer = 5.0f;

    void Start (){
        //If waypoints are not defined, build it automatically
        //depending the initial position of the object.
        if (this.ListOfWaypoints.Count == 0)
            this.BuildWaypoints_HorizontalSimple();
        else
            this.ListOfWaypoints.ForEach(item => this.waypoints.Add(item.transform.position));


        this.currentWaypointIndex = this.StartIndex;


        this._currentWaypont = this.waypoints[this.currentWaypointIndex];
        //this._currentWaypont = this.transform.gameObject;

        this.currentWaypointIndex++;

        this._nextWaypoint = this.waypoints[this.currentWaypointIndex];

        //		if ("fución ") {
        //			Enemy_Life = 1;

        //		}
        //rbody = this.GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void Update()
    {
        if (this._nextWaypoint != null)
        {
            Vector2 initPos = this._currentWaypont;
            Vector2 endPos = this._nextWaypoint;

            this.timer += Time.deltaTime * this.Enemy_Velocity;

            var newPos = Vector2.Lerp(initPos, endPos, timer);

            this.transform.position = newPos;
        }


        if (this.timer >= 1.0f)
        {
            this.timer = 0;

            this._currentWaypont = this._nextWaypoint;

            this.currentWaypointIndex++;

            if (this.currentWaypointIndex == this.waypoints.Count)
                this.currentWaypointIndex = 0;

            //        if (!this.LoopList && this.StartIndex == this.currentWaypointIndex)
            //        {
            //            /*
            // * Bug:
            // * 	I couldn't make a foreach of <T> so I'll enabled every MonoBehaviour
            // * 	from the enemies. In the future I should look at this
            // * 
            //foreach (var mono in MonoBehavioursCallback) {
            //	GetComponent<typeof(mono)> ().enabled = true;
            //}
            //*/


            //            this.enabled = false;
            //        }
            //        else
            //        {
            this._nextWaypoint = this.waypoints[this.currentWaypointIndex];
            //}

        }


        /*
		Shoot_Time_Left -= Time.deltaTime;
		if ( Shoot_Time_Left < 0 )
		{
//			Shoot();
		}
		*/
    }

    private void BuildWaypoints_HorizontalSimple()
    {
        //Build list of waypoints depending the initial position.

        //Create a new instance to prevent reference.
        this.waypoints.Add(new Vector2(this.transform.position.x, this.transform.position.y));

        this.waypoints.Add(new Vector2(this.transform.position.x + 1, this.transform.position.y));
    }

	void OnTriggerEnter2D(Collider2D coll) {
		if (coll.gameObject.tag == "Bullet") {
            //	coll.gameObject.hurt_enemy ("actual player weapon");
            //AppController_Class.Instance.InformEnemyDestroyed (this);
            this.QuestionOwner.InformEnemyDestroyed(this);


            Destroy (this.gameObject);
		}
		//	Destroy(coll.gameObject);
	}
}


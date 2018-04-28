using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour {

    
    public float speed = 5.0f;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {

        transform.position += Vector3.up * speed * Time.deltaTime;
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        Destroy(this.gameObject);
    }
}

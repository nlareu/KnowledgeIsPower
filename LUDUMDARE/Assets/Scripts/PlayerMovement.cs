using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public float speed;
    Rigidbody2D rb;
    public GameObject bullet;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
        
    }
	
	// Update is called once per frame
	void Update ()
    {
        //MOVIMIENTO
        if (Input.GetKey(KeyCode.A))
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.W))
        {
            Instantiate(bullet, transform.position, Quaternion.identity);
        }

        //LIMITAR POSICION
        Vector3 pos = transform.position;
        if (transform.position.x >= 5)
        {
            pos.x = 5;
        }
        if (transform.position.x <= 0)
        {
            pos.x = 0;
        }

        transform.position = pos;

    }
}

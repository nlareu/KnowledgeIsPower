using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour {

    public GameObject Bullet;
    public float Speed = 5.0f;

    //Sounds
    public AudioClip Sound_Shoot;
    public AudioClip Sound_Motor;

    private AudioSource audioSource_motor;
    private AudioSource audioSource_shoot;
    private float timerbulletcalentado = 0.2f;

    // Use this for initialization
    void Start () {
        this.audioSource_motor = this.gameObject.AddComponent<AudioSource>();
        this.audioSource_motor.clip = this.Sound_Motor;
        this.audioSource_motor.loop = true;
        this.audioSource_shoot = this.gameObject.AddComponent<AudioSource>();
        this.audioSource_shoot.clip = this.Sound_Shoot;


        ////Start background sounds.
        //this.audioSource_motor.Play();
    }
	
	// Update is called once per frame
	void Update ()
    {
        //MOVIMIENTO
        if (Input.GetKey(KeyCode.A))
        {
            transform.position += Vector3.left * Speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += Vector3.right * Speed * Time.deltaTime;
        }
	
		timerbulletcalentado -= Time.deltaTime;

		if ( timerbulletcalentado < 0 )
		{
			if (Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.W))
			{
                //Play sound
                this.audioSource_shoot.PlayOneShot(this.Sound_Shoot);

                GameObject bullet = Instantiate(this.Bullet, this.gameObject.transform.position, Quaternion.identity) as GameObject;
				bullet.transform.gameObject.tag = "Bullet";

				Destroy (bullet, 2f);

				timerbulletcalentado = 0.2f;
			}
		}

       

        //LIMITAR POSICION
        //Vector3 pos = transform.position;
        //if (transform.position.x >= 5)
        //{
        //    pos.x = 5;
        //}
        //if (transform.position.x <= 0)
        //{
        //    pos.x = 0;
        //}

        //transform.position = pos;

    }
}

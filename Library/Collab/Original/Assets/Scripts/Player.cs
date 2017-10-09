using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {


	//Floats
	public float maxSpeed = 3;
	public float speed = 50f;

	//Referencias
	private Rigidbody2D rb2d;

	private bool leftPointer = false;
	private bool rightPointer = false;

	private Animator anim;

	// Use this for initialization
	void Start () {
		rb2d = gameObject.GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetAxis("Horizontal") < -0.1f || leftPointer)
		{
			transform.localScale = new Vector3(-1, 1, 1);
		}

		if (Input.GetAxis("Horizontal") > 0.1f || rightPointer)
		{
			transform.localScale = new Vector3(1, 1, 1);
		}
		/*
		if ((Input.GetButtonDown("Jump") && grounded) || (jumpPointer && grounded))
		{
			rb2d.AddForce(Vector2.up * jumpPower);
		}

		if (curHealth > maxHealth)
		{
			curHealth = maxHealth;
		}

		if (curHealth <= 0)
		{
			Die();
		}*/

	}

	void FixedUpdate()
	{

		Vector3 easeVelocity = rb2d.velocity;
		easeVelocity.y = rb2d.velocity.y;
		easeVelocity.z = 0.0f;
		easeVelocity.x *= 0.75f;

		float h = Input.GetAxis("Horizontal");
		if (leftPointer)
			h = -1;
		else if (rightPointer)
			h = 1;

		//mover el jugador
		rb2d.AddForce((Vector2.right * speed) * h);

		//limito la velocidad del jugador
		if (rb2d.velocity.x > maxSpeed)
		{
			rb2d.velocity = new Vector2(maxSpeed, rb2d.velocity.y);
		}

		if (rb2d.velocity.x < -maxSpeed)
		{
			rb2d.velocity = new Vector2(-maxSpeed, rb2d.velocity.y);
		}

		if (rb2d.velocity.y > maxSpeed + 5)
		{
			rb2d.velocity = new Vector2(rb2d.velocity.x, maxSpeed + 5);
		}

	}

}

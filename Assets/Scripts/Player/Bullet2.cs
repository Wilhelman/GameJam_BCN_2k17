using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bullet2 : MonoBehaviour
{
    GameObject pufff;
    GameObject puf;
    public int bulletVelocity = 5;

	public Vector3 bulletDirection = Vector3.zero;
	public Vector3 inputDirection = Vector3.zero;

	public P2 player;

	public float module = 0;

	//UI Stuff
	public bool rainbow = false;

	public int points2 = 0;

	// Use this for initialization
	void Start()
	{
		player = GameObject.Find("P2").GetComponent<P2>();
		//
		points2 = 0;

        puf = GameObject.Find("Puf");

        module = Vector3.Magnitude(player.bulletDirection);
		inputDirection = player.bulletDirection / module;
	}

	void FixedUpdate()
	{
		Movement();
	}

	// Update is called once per frame
	void Update()
	{

	}

	void Movement()
	{
		transform.position += bulletVelocity * inputDirection;
	}

	private void OnTriggerEnter2D(Collider2D col)
	{

		if (col.gameObject.tag == "EndofZone")
		{
			Destroy(gameObject);
		}

		//Toca escudo y se vuelve rainbow
		if (col.gameObject.tag == "Shield")
		{
            pufff = Instantiate(puf, transform.position, Quaternion.identity);
            Destroy(pufff, 0.5f);

            rainbow = true;
		}

		//Toca enemigo y enemigo se vuelve triste
		if (col.gameObject.tag == "Enemy")
		{
			if (rainbow)
			{
				points2 += 10;
			}

			Destroy(gameObject);
		}
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public int bulletVelocity = 5;

    public Vector3 inputDirection = Vector3.zero;

    private float module = 0;

    public GameObject enemy;

    public StayDistant enemyShot;
    //
    // Use this for initialization
    void Start()
    {
        enemy = GameObject.Find("EnemyDone");
        enemyShot = enemy.GetComponent<StayDistant>();

        module = Vector3.Magnitude(enemyShot.bulletDirection);
        inputDirection = enemyShot.bulletDirection / module;
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
        if (col.gameObject.tag == "P1")
        {
			//Player turns sad
			P1 player1 = col.gameObject.GetComponent<P1>();
			player1.isSad = true;
            Destroy(gameObject);
		}
		else if(col.gameObject.tag == "P2")

		{
			//Player turns sad
			P2 player1 = col.gameObject.GetComponent<P2>();
			player1.isSad = true;
			Destroy(gameObject);
		}
		else if (col.gameObject.tag == "P3")
		{
			//Player turns sad
			P3 player1 = col.gameObject.GetComponent<P3>();
			player1.isSad = true;
			Destroy(gameObject);
		}
		else if (col.gameObject.tag == "P4")
		{
			//Player turns sad
			P4 player1 = col.gameObject.GetComponent<P4>();
			player1.isSad = true;
			Destroy(gameObject);
		}
        else if (col.gameObject.tag == "EndofZone")
        {
            Destroy(gameObject);
        }

    }
}

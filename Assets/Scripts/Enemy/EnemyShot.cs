using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShot : MonoBehaviour {

    public Vector3 bulletDirection;
    public Vector3 bulletPosition;

    public Vector3 enemyPosition;
    public Vector3 playerPosition;

    public GameObject player;
    public GameObject enemy;

    public GameObject bullet;

    private int shoot = 0;

    //IF ENEMY IS INSIDE THE BATTLEGROUND
    public Chase chase;
    public bool canbe = false;
    //

    // Use this for initialization
    void Start () {
        player = GameObject.Find("P1");
        bullet = GameObject.Find("EnemyBullet");
        chase = GameObject.Find("Enemy").GetComponent<Chase>();
    }

    // Update is called once per frame
    void Update () {
        canbe = chase.canshotandbekilled;

        if (canbe)
        {
            shoot = Random.Range(0, 80);

            if (shoot == 10) //Si están dins de la zona de niebla i cada x segons.
            {
                Shoot();
            }
        }
	}

    void Shoot()
    {
        playerPosition = player.transform.position;
        enemyPosition = transform.position;

        bulletDirection = playerPosition - enemyPosition;

        bulletPosition = enemyPosition;

        Instantiate(bullet, bulletPosition, Quaternion.identity);
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
		else if (col.gameObject.tag == "P2")

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

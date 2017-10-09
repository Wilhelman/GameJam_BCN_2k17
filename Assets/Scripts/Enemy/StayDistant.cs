using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StayDistant : MonoBehaviour {

    Bullet1 bullet1;
    Bullet2 bullet2;
    Bullet3 bullet3;

    SpawnEnemyScript SpawnEnemyCore;

    public Vector3 anim_pos;

    private Bullet1 bull1;
    private Bullet2 bull2;
    private Bullet3 bull3;
    private Bullet4 bull4;

    private Transform Player;
    private GameObject player;

    public Vector3 bulletDirection;
    public Vector3 bulletDirection2;
    public Vector3 bulletDirection3;
    public Vector3 bulletDirection4;
    private Vector3 bulletPosition;

    private Vector3 enemyPosition;
    private Vector3 playerPosition;
    private GameObject bullet;

    private float DistanceModular;
    public Vector3 Distance;
    private int velocity = 1;
    private int intensity = 1;
    private float keepdistance = 150;

    public int vida = 1;

    int playerObjectiu;
    private bool firstmeet;

    private int shoot = 0;

    //IF ENEMY IS INSIDE THE BATTLEGROUND
    // public Chase chase;
    public bool canbe = false;
    //

    //Fugida
    float velocityRun = 1.0f;
    Vector3 run;
    float module = 0;
    bool fugida = false;
    public bool do_once = true;
    float timer = 0;
    //

    public SpriteRenderer enemyDoneSad;
    public SpriteRenderer enemyDoneHappy;

    // Use this for initialization
    void Start () {
        bullet = GameObject.Find("EnemyBullet");
        playerObjectiu = Random.Range(1, 5);
        //    chase = GameObject.Find("Enemy").GetComponent<Chase>();
        SpawnEnemyCore = GameObject.Find("SpawnEnemyCore").GetComponent<SpawnEnemyScript>();
        enemyDoneSad.enabled = true;
        enemyDoneHappy.enabled = false;
        FindAllPlayers();
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        anim_pos = player.transform.position - this.transform.position;

        if (vida <= 0)
        {

            Fugida();
        }
        else
        {
            timer += Time.deltaTime;
            if (timer >= 10)
                vida = 0;
            shoot = Random.Range(0, 180);
            //  canbe = chase.canshotandbekilled;
            if (firstmeet == true && shoot == 10)
            {
                Shoot();
            }

             
            StayDistantFunction(1);
        }
	}

    void StayDistantFunction(int intensity)
    {
        
        DistanceModular = Vector3.Distance(Player.transform.position, transform.position);
        if (DistanceModular > keepdistance && firstmeet == false)
        {
            Distance = Player.position - transform.position;
            transform.position += Distance * intensity * Time.deltaTime;
        }
        else if (DistanceModular <= keepdistance && firstmeet == false)
        {
            firstmeet = true;
        }
        else if (DistanceModular > keepdistance + 200 && firstmeet == true)
        {
            firstmeet = false;
        }

    }
    //
    void FindAllPlayers()
    {
        Player = GameObject.Find("P" + playerObjectiu).GetComponent<Transform>(); //Player is Transform
        //IT MUST SHOOT Player!!!
        player = GameObject.Find("P" + playerObjectiu); //player is GameObject
    }

    void Shoot()
    {
        enemyPosition = transform.position;
		bulletPosition = enemyPosition;

        bulletDirection = new Vector3 (1, 0, 0);
        EnemyBullet bul1 = Instantiate(bullet, bulletPosition, Quaternion.identity).GetComponent<EnemyBullet>();
        bul1.inputDirection = bulletDirection;
        bul1.bulletVelocity = 5;
        bulletDirection = new Vector3(-1, 0, 0);
		EnemyBullet bul2 = Instantiate(bullet, bulletPosition, Quaternion.identity).GetComponent<EnemyBullet>();
        bul2.inputDirection = bulletDirection;
        bul2.bulletVelocity = 5;
        bulletDirection = new Vector3(0, 1, 0);
		EnemyBullet bul3 = Instantiate(bullet, bulletPosition, Quaternion.identity).GetComponent<EnemyBullet>();
        bul3.inputDirection = bulletDirection;
        bul3.bulletVelocity = 5;
        bulletDirection = new Vector3(0, -1, 0);
		EnemyBullet bul4 = Instantiate(bullet, bulletPosition, Quaternion.identity).GetComponent<EnemyBullet>();
        bul4.inputDirection = bulletDirection;
        bul4.bulletVelocity = 5;

       

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bullet1")
        {
            bull1 = collision.gameObject.GetComponent<Bullet1>();

            if (bull1.rainbow)
            {
                vida--;
                
                //tempo = 0;
            }

        }

        if (collision.gameObject.tag == "Bullet2")
        {
            bull2 = collision.gameObject.GetComponent<Bullet2>();

            if (bull2.rainbow)
            {

                vida--;
                //tempo = 0;
            }

        }

        if (collision.gameObject.tag == "Bullet3")
        {
            bull3 = collision.gameObject.GetComponent<Bullet3>();

            if (bull3.rainbow)
            {

                vida--;
                //tempo = 0;
            }

        }

        if (collision.gameObject.tag == "Bullet4")
        {
            bull4 = collision.gameObject.GetComponent<Bullet4>();

            if (bull4.rainbow)
            {

                vida--;
                //tempo = 0;
            }

        }

        if (fugida && collision.gameObject.tag == "EndofZone")
        {
            Destroy(gameObject, 5);
        }
    }

    void Fugida()
    {
        transform.Translate(1.5f, 1.5f,0);
		if (do_once)
		{
            enemyDoneSad.enabled = false;
            enemyDoneHappy.enabled = true;

            run.x = this.transform.position.x * -1;
			run.y = this.transform.position.y * -1;
			run.z = this.transform.position.z;

			module = Vector3.Magnitude(run);
			run = run / module;

			SpawnEnemyCore.restarEnemiesVius();

			do_once = false;
		}

        this.transform.position += new Vector3(20,20,0);

		fugida = true;
    }
}

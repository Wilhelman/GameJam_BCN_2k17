using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet2 : MonoBehaviour
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

        module = Vector3.Magnitude(enemyShot.bulletDirection2);
        inputDirection = enemyShot.bulletDirection2 / module;
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
        if (col.gameObject.tag == "Player")
        {
            //Player turns sad

            Destroy(gameObject);
        }
        else if (col.gameObject.tag == "EndofZone")
        {
            Destroy(gameObject);
        }

    }
}

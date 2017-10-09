using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bullet1 : MonoBehaviour {

    public int bulletVelocity = 5;

    GameObject pufff;

    public Vector3 bulletDirection = Vector3.zero;
    public Vector3 inputDirection = Vector3.zero;

    public P1 player;

    GameObject puf;

    public float module = 0;

    //UI Stuff
    public bool rainbow = false;
    private bool didShield = false;

    public int points1 = 0;

    // Use this for initialization
    void Start()
    {
        puf = GameObject.Find("Puf");

        player = GameObject.Find("P1").GetComponent<P1>();
        //
        points1 = 0;

        module = Vector3.Magnitude(player.bulletDirection);
        inputDirection = player.bulletDirection / module;
    }

    void FixedUpdate()
    {
        Movement();
    }

    // Update is called once per frame
    void Update () {
         
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
            didShield = true;
        }

        //Toca enemigo y enemigo se vuelve triste
        if (col.gameObject.tag == "Enemy")
        {
            if (didShield)
            {
                points1 += 10;
            }

            Destroy(gameObject);
        }
    }
}

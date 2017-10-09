using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Colliders : MonoBehaviour {

    // Use this for initialization
    public int live = 10;

    //IF ENEMY IS INSIDE THE BATTLEGROUND
    public Chase chase;
    public bool canbe = false;
    //

	void Start () {
        chase = GameObject.Find("Enemy").GetComponent<Chase>();
	}
	
	// Update is called once per frame
	void Update () {
        canbe = chase.canshotandbekilled;

        if (canbe)
        {
            if (live <= 0)
            {
                Destroy(gameObject);
            }
        }
	}

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (canbe)
        {
            if (col.gameObject.tag == "Bullet1" || col.gameObject.tag == "Bullet2" || col.gameObject.tag == "Bullet3" || col.gameObject.tag == "Bullet4")
            {
                live--;
            }
        }
    }
}

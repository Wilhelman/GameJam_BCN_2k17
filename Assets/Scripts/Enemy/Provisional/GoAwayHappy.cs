using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoAwayHappy : MonoBehaviour {

    //IF ENEMY IS INSIDE THE BATTLEGROUND
    public Chase chase;
    public bool canbe = false;
    //

    // Use this for initialization
    void Start () {
        chase = GameObject.Find("Enemy").GetComponent<Chase>();
    }
	
	// Update is called once per frame
	void Update () {
        canbe = chase.canshotandbekilled;

        if (canbe)
        {




        }
    }
}

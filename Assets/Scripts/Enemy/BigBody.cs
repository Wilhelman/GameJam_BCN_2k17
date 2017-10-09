using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigBody : MonoBehaviour {

    BigBudy big;

    public Animator anim;
	// Use this for initialization
	void Start () {
        big = GameObject.Find("BigBudy").GetComponent<BigBudy>();
        anim = gameObject.GetComponent<Animator>();

        anim.Play("walk_body");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

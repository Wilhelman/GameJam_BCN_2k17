using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puf : MonoBehaviour {

    Animator anim;

	// Use this for initialization
	void Start () {
        anim = gameObject.GetComponent<Animator>();
        anim.Play("SMOKE");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

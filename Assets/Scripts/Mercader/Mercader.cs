using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mercader : MonoBehaviour {

    bool red;
    bool green;
    bool blue;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
           
        }

  
    }

    private void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            
        }
    }
}

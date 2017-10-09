using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chase : MonoBehaviour {

    public Transform Player;
    private float DistanceModular;
    private Vector3 Distance;
    public int velocity = 1;
    public int intensity = 1;
    public string options = "noone";

    public bool canshotandbekilled = false;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        ChaseFunction(intensity);
    }

    void ChaseFunction(int intensity)
    {
        Distance = Player.position - transform.position;
        transform.position += Distance * intensity * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "EndofZone")
        {
            canshotandbekilled = true;
        }
    }
}

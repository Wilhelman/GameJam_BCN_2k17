using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FastChase : MonoBehaviour {

    public Transform Player;
    private float DistanceModular;
    private Vector3 Distance;
    public int velocity = 1;
    public int intensity = 1;
    public float keepdistance = 300;


    private bool firstmeet;
    private bool letsattack;
    private bool charge;
    public bool shortposition;
    private Vector3 ShortDistance;
    //  public float rotationSpeed = 3;
    public float time = 0.5f;
    private float interpolationPeriod = 0.5f;
    public float time2 = 0.5f;
    private float interpolationPeriod2 = 0.5f;

    //IF ENEMY IS INSIDE THE BATTLEGROUND
    public Chase chase;
    public bool canbe = false;
    //

    // Use this for initialization
    void Start () {
        chase = GameObject.Find("Enemy").GetComponent<Chase>();
        keepdistance = 150;
    }

    // Update is called once per frame  
    void Update () {
        canbe = chase.canshotandbekilled;

        if (canbe)
        {
            FastChaseFunction();
        }
    }

    void FixedUpdate()
    {

    }

    void FastChaseFunction() {
        DistanceModular = Vector3.Distance(Player.transform.position, transform.position);
        if (DistanceModular > keepdistance && charge == false)
        {
            Distance = Player.position - transform.position;
            transform.position += Distance * intensity * Time.deltaTime;
        }
        else if (DistanceModular <= keepdistance && charge == false)
        {
            charge = true;
        }
        else if (charge == true)
        {
            time -= Time.deltaTime;

            if (time <= 0.0f)
            {
                letsattack = true;
                time = interpolationPeriod;
            }
        else if(letsattack == true && charge == true)
            {
                if (shortposition == false)
                {
                    ShortDistance = Player.position - transform.position;
                    shortposition = true;
                }
                transform.position += ShortDistance * 5 * Time.deltaTime;
                time2 -= Time.deltaTime;

                if (time2 <= 0.0f)
                {
                    letsattack = true;
                    charge = false;
                    shortposition = false;
                    time2 = interpolationPeriod2;
                }
            }
        }
    }
}
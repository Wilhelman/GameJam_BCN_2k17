using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointsText1 : MonoBehaviour
{ 
    public SpawnEnemyScript spawn;

    public bool do_once = true;

    public Text points1;
    public Bullet1 bullet1;

    public Animator anim;

    private GestionPuntos gp;

    // Use this for initialization
    void Awake()
    {
        gp = GameObject.Find("Points").GetComponent<GestionPuntos>();

        spawn = GameObject.Find("SpawnEnemyCore").GetComponent<SpawnEnemyScript>();

        anim = gameObject.GetComponent<Animator>();

        bullet1 = GameObject.Find("Bullet1").GetComponent<Bullet1>();
        points1 = gameObject.GetComponent<Text>();


    }

    void Start()
    {
        anim.Play("points1");
    }

    // Update is called once per frame
    void Update()
    {
        PrintCoins();
    }

    void PrintCoins()
    {

        if (spawn.endGame)
        {
            if (do_once)
            {
                points1.resizeTextMaxSize = 90;
                anim.Play("points1_end");
                do_once = false;
            }
        }
        else
        {

            if (gp.P1_points % 100 == 0 && gp.P1_points != 0)
            {
                points1.resizeTextMaxSize = 90;
            }
            else
            {
                points1.resizeTextMaxSize = 70;
            }

            points1.text = gp.P1_points.ToString();
        }
    }
    
}
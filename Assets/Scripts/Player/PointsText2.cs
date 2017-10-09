using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointsText2 : MonoBehaviour
{

    public Text points2;
    public Bullet2 bullet2;

    public SpawnEnemyScript spawn;

    public bool do_once = true;

    public Animator anim;

    private GestionPuntos gp;

    // Use this for initialization
    void Awake()
    {
        gp = GameObject.Find("Points").GetComponent<GestionPuntos>();


        anim = gameObject.GetComponent<Animator>();

        spawn = GameObject.Find("SpawnEnemyCore").GetComponent<SpawnEnemyScript>();

        bullet2 = GameObject.Find("Bullet2").GetComponent<Bullet2>();
        points2 = gameObject.GetComponent<Text>();
    }

    void Start()
    {
        anim.Play("points2");
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
                points2.resizeTextMaxSize = 90;
                anim.Play("points2_end");
                do_once = false;
            }
        }
        else
        {
            if (bullet2.points2 % 100 == 0 && bullet2.points2 != 0)
            {
                points2.resizeTextMaxSize = 90;
            }
            else
            {
                points2.resizeTextMaxSize = 70;
            }

           
            points2.text = gp.P2_points.ToString();
        }

    }
}
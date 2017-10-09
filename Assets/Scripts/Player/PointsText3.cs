using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointsText3 : MonoBehaviour
{

    public Text points3;
    public Bullet3 bullet3;

    public SpawnEnemyScript spawn;

    public bool do_once = true;

    public Animator anim;

    private GestionPuntos gp;

    // Use this for initialization
    void Awake()
    {
        gp = GameObject.Find("Points").GetComponent<GestionPuntos>();
        spawn = GameObject.Find("SpawnEnemyCore").GetComponent<SpawnEnemyScript>();

        anim = gameObject.GetComponent<Animator>();

        bullet3 = GameObject.Find("Bullet3").GetComponent<Bullet3>();
        points3 = gameObject.GetComponent<Text>();
    }

    void Start()
    {
        anim.Play("points3");
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
                points3.resizeTextMaxSize = 90;
                anim.Play("points3_end");
                do_once = false;
            }
        }
        else
        {
            if (bullet3.points3 % 100 == 0 && bullet3.points3 != 0)
            {
                points3.resizeTextMaxSize = 90;
            }
            else
            {
                points3.resizeTextMaxSize = 70;
            }

            points3.text = gp.P3_points.ToString();
        }

    }
}
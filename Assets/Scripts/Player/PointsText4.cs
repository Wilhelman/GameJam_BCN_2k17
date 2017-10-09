using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointsText4 : MonoBehaviour
{

    public Text points4;
    public Bullet4 bullet4;

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

        bullet4 = GameObject.Find("Bullet4").GetComponent<Bullet4>();
        points4 = gameObject.GetComponent<Text>();


    }

    void Start()
    {
        anim.Play("points4");
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
                points4.resizeTextMaxSize = 90;
                anim.Play("points4_end");
                do_once = false;
            }
        }
        else
        {
            if (bullet4.points4 % 100 == 0 && bullet4.points4 != 0)
            {
                points4.resizeTextMaxSize = 90;
            }
            else
            {
                points4.resizeTextMaxSize = 70;
            }

            points4.text = gp.P4_points.ToString();
        }

    }
}
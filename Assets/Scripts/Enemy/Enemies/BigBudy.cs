using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigBudy : MonoBehaviour {

    //public Vector3 anim_pos;

    Bullet1 bullet1;
    Bullet2 bullet2;
    Bullet3 bullet3;
    Bullet4 bullet4;

    public Vector3 vecRes;

    Transform player;

    float vel = 1.5f;

    public SpriteRenderer rendNormal;
    public SpriteRenderer rendContent;
    SpawnEnemyScript SpawnEnemyCore;
    int playerObjectiu;
    public int vida;
    private float tempo;

    private Bullet1 bull1;
    private Bullet2 bull2;
    private Bullet3 bull3;
    private Bullet4 bull4;

    P1 player1;
    P2 player2;
    P3 player3;
    P4 player4;

    //Fugida
    float velocityRun = 4.0f;
    Vector3 run;
    float module = 0;
    bool fugida = false;
    bool do_once = true;
    //
    public bool ent = false;

    GestionPuntos gp;

    void Start () {

        gp = GameObject.Find("Points").GetComponent<GestionPuntos>();

        bullet1 = GameObject.Find("Bullet1").GetComponent<Bullet1>();
        bullet2 = GameObject.Find("Bullet2").GetComponent<Bullet2>();
        bullet3 = GameObject.Find("Bullet3").GetComponent<Bullet3>();
        bullet4 = GameObject.Find("Bullet4").GetComponent<Bullet4>();
        SpawnEnemyCore = GameObject.Find("SpawnEnemyCore").GetComponent<SpawnEnemyScript>();

        playerObjectiu = Random.Range(1, 4);    // esta chapat a 1 per fer probes, haura de ser un 4
        FindAllPlayers();
        vida = 1;
        tempo = 5;

        rendContent.enabled = false;
        rendNormal.enabled = true;
    }

    void FixedUpdate()
    {
        //anim_pos = player.transform.position - this.transform.position;

        tempo += Time.deltaTime;

        if (!ent)
            Moviment();
        else if (ent || vida <=0)
            Fugida();

        /*
        if (vida == 0)
        {
            vida--;
            Destroy(gameObject, 100);
        }
        */
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.tag == "p1" && !ent)
        {
            player1 = collision.gameObject.GetComponent<P1>();
            player1.isSad = true;
            ent = true;
            vida--;
            tempo = 0;
        }
        if (collision.gameObject.tag == "p2" && !ent)
        {
            player2 = collision.gameObject.GetComponent<P2>();
            player2.isSad = true;
            ent = true;
            vida--;
            tempo = 0;
        }
        if (collision.gameObject.tag == "p3" && !ent)
        {
            player3 = collision.gameObject.GetComponent<P3>();
            player3.isSad = true;
            ent = true;
            vida--;
            tempo = 0;
        }
        if (collision.gameObject.tag == "p4" && !ent)
        {
            player4 = collision.gameObject.GetComponent<P4>();
            player4.isSad = true;
            ent = true;
            vida--;
            tempo = 0;
        }

        if (collision.gameObject.tag == "Bullet1"/* && EstaEnDefensa() == false*/)
        {
            bull1 = collision.gameObject.GetComponent<Bullet1>();
            
            if (bull1.rainbow)
            {
                ent = true;
                gp.P1_points+=10;
                vida--;
                tempo = 0;
            }

        }

        if (collision.gameObject.tag == "Bullet2"/* && EstaEnDefensa() == false*/)
        {
            bull2 = collision.gameObject.GetComponent<Bullet2>();
            
            if (bull2.rainbow)
            {
                ent = true;
                gp.P2_points += 10;
                vida--;
                tempo = 0;
            }

        }

        if (collision.gameObject.tag == "Bullet3"/* && EstaEnDefensa() == false*/)
        {
            bull3 = collision.gameObject.GetComponent<Bullet3>();
            
            if (bull3.rainbow)
            {
                ent = true;
                gp.P3_points += 10;
                vida--;
                tempo = 0;
            }

        }

        if (collision.gameObject.tag == "Bullet4" /*&& EstaEnDefensa() == false*/)
        {
            bull4 = collision.gameObject.GetComponent<Bullet4>();
            
            if (bull4.rainbow)
            {
                ent = true;
                gp.P4_points += 10;
                vida--;
                tempo = 0;
            }

        }

        if (ent && collision.gameObject.tag == "EndofZone")
        {
            Destroy(this, 5);
        }
    }

    void FindAllPlayers() {
        player = GameObject.Find("P"+playerObjectiu).GetComponent<Transform>();
    }

    void Moviment()
    {
        vecRes = this.transform.position - player.position;
        if (vecRes.x < 0)
        {
            if (vecRes.y < 0)
            {
                this.transform.Translate(vel * 1, vel * 1, 0);
            }
            else
            {
                this.transform.Translate(vel * 1, vel * -1, 0);
            }
        }
        else
        {
            if (vecRes.y < 0)
            {
                this.transform.Translate(vel * -1, vel * 1, 0);
            }
            else
            {
                this.transform.Translate(vel * -1, vel * -1, 0);
            }
        }
    }

    void Fugida()
    {
        if (do_once)
        {
            rendContent.enabled = true;
            rendNormal.enabled = false;
            run.x = this.transform.position.x * -1;
            run.y = this.transform.position.y * -1;
            run.z = this.transform.position.z;

            module = Vector3.Magnitude(run);
            run = run / module;

            SpawnEnemyCore.restarEnemiesVius();

            do_once = false;
        }

        this.transform.position += velocityRun * run;

        fugida = true;
    }

    IEnumerator DeadTime(float time)
    {
        yield return new WaitForSeconds(time);
        Destroy(this);
    }

    bool EstaEnDefensa()
    {
        //if (fugida == false)
        //{
        //    if (tempo > 5 && rendContent.enabled == true)
        //    {
        //        rendContent.enabled = false;
        //        rendNormal.enabled = true;
        //    }
        //    else if (tempo < 5 && rendNormal.enabled == true)
        //    {
        //        rendContent.enabled = true;
        //        rendNormal.enabled = false;
        //    }
        //}

        //if (tempo > 5)
        //    return false;
        //else
            return true;
        
    }
}
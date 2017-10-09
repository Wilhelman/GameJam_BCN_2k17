using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemyScript : MonoBehaviour
{
    public GameObject enemyChase;
    public GameObject enemyFastChase;
    public GameObject enemyDistance;
    Vector3 pos;

    public P1 player1;
    public P2 player2;
    public P3 player3;
    public P4 player4;

    float timer = 0f;
    float to_menu = 0f;

    public bool endGame = false;

    public bool ronda = true;

    void Start()
    {
        player1 = GameObject.Find("P1").GetComponent<P1>();
        player2 = GameObject.Find("P2").GetComponent<P2>();
        player3 = GameObject.Find("P3").GetComponent<P3>();
        player4 = GameObject.Find("P4").GetComponent<P4>();

    }

    void Update()
    {
      //  Debug.Log(controlMorts);
        if (player1.isSad && player2.isSad && player3.isSad && player4.isSad)
        {
            endGame = true;
            to_menu += Time.deltaTime;

            if (to_menu >= 12f)
            {
                //hacerlo en 3 seg

                Application.LoadLevel("Menu");
            }
        }
        else
        {
            ControlDeRonda();

            if (!player1.isSad && !player2.isSad && !player3.isSad && !player4.isSad)
            {
                timer += Time.deltaTime;
                if (Input.GetKeyDown(KeyCode.A))
                    generarRonda(3);

            }
        }

    }

    GameObject ReturnAnRandomEnemy()
    {
        GameObject ret = enemyDistance;
        int num = Random.Range(0, 2);
        Debug.Log(num);
        switch (num)
        {
            case 0:
                ret = enemyChase;
                break;
            case 1:
                ret = enemyFastChase;
                break;
        }
        return ret;
    }

    void generarRonda(int numeroDeEnemics)
    {
        for (int i = numeroDeEnemics; i > 0; i--)
        {
            int costat = Random.Range(0, 3);
            if (numeroDeEnemics > 0)
            {
                numeroDeEnemics--;
                if (costat <= 1)
                {
                    if (costat == 0)
                    {
                        pos = new Vector3(Random.Range(0, 1792), Random.Range(504, 650), -1);
                        GameObject shot = Instantiate(ReturnAnRandomEnemy(), pos, Quaternion.identity) as GameObject;
                    }
                    else
                    {
                        pos = new Vector3(Random.Range(0, 1792), Random.Range(-650, -504), -1);
                        GameObject shot = Instantiate(ReturnAnRandomEnemy(), pos, Quaternion.identity) as GameObject;
                    }
                }
                else
                {
                    if (costat == 2)
                    {
                        pos = new Vector3(Random.Range(-1000, -896), Random.Range(0, 1008), -1);
                        GameObject shot = Instantiate(ReturnAnRandomEnemy(), pos, Quaternion.identity) as GameObject;
                    }
                    else
                    {
                        pos = new Vector3(Random.Range(896, 1000), Random.Range(0, 1008), -1);
                        GameObject shot = Instantiate(ReturnAnRandomEnemy(), pos, Quaternion.identity) as GameObject;
                    }
                }
            }
        }
    }
    public int controlMorts = 0;
    public int controlDeRondes = 0;

    void ControlDeRonda()
    {
        if (controlMorts <= 0)  // nova ronda
        {
            ronda = true;
            
            controlDeRondes++;
            controlMorts = controlDeRondes * 2;
            generarRonda(controlMorts);
            reviveAllPlayers();
        }
        else
        {
            ronda = false;
        }

    }

    void reviveAllPlayers()
    {
        player1.GetComponent<P1>().isSad = false;
        player2.GetComponent<P2>().isSad = false;
        player3.GetComponent<P3>().isSad = false;
        player4.GetComponent<P4>().isSad = false;

    }

    public void restarEnemiesVius()
    {
        controlMorts--;
    }
}
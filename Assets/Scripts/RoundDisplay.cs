using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoundDisplay : MonoBehaviour
{
    public Text roundsText;

    public Animator anim;

    string name;

    public float time = 0;

    SpawnEnemyScript spawnEnemyScript;

    public bool yes = false;

    // Use this for initialization
    void Awake()
    {
        spawnEnemyScript = GameObject.Find("SpawnEnemyCore").GetComponent<SpawnEnemyScript>();

        roundsText = gameObject.GetComponent<Text>();
        anim = GetComponent<Animator>();
    }

    void Start()
    {
        anim.Play("round_non");
    }

    // Update is called once per frame
    void Update()
    {
        if (spawnEnemyScript.ronda)
        {
            Debug.Log("E");
            name = "ROUND " + spawnEnemyScript.controlDeRondes.ToString();
            roundsText.text = name;
            anim.Play("round_yes");
            yes = true;
        }

        if (yes)
        {
            time += Time.deltaTime;
        }
        
        if (time >= 5.0f)
        {
            anim.Play("round_non");
            time = 0;
            yes = false;
        }

    }
}

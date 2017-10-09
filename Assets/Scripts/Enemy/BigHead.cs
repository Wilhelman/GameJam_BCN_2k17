using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigHead : MonoBehaviour {

   public Sprite n1;
    public Sprite n2;
    public Sprite n3;
    public Sprite n4;

    public Sprite n5;
    public Sprite n6;
    public Sprite n7;

    BigBudy big;

    SpriteRenderer r;

    // Use this for initialization
    void Start()
    {
        big = GameObject.Find("BigBudy").GetComponent<BigBudy>();

        r = gameObject.GetComponent<SpriteRenderer>();

    }

    // Update is called once per frame
    void Update()
    {

        //if () { //NOT HAPPY
        if (big.vecRes.x < 0 && big.vecRes.y > -0.5 && big.vecRes.y < 0.5)
        {
            r.sprite = n1;
        }
        else if (big.vecRes.x > 0 && big.vecRes.y > -0.5 && big.vecRes.y < 0.5)
        {
            r.sprite = n2;
        }
        else if (big.vecRes.y < 0 && big.vecRes.x > -0.5 && big.vecRes.x < 0.5)
        {
            r.sprite = n3;
        }
        else if (big.vecRes.y > 0 && big.vecRes.x > -0.5 && big.vecRes.x < 0.5)
        {
            r.sprite = n4;
        }
        // }

    }
}

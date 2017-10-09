using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDoneHead : MonoBehaviour
{
    public Sprite up;
    public Sprite down;
    public Sprite left;
    public Sprite right;

    SpriteRenderer rend;

    float module = 0;
    Vector3 anim_p;
    public Vector3 inputDirection;

    // Use this for initialization
    void Start()
    {
        rend = gameObject.GetComponent<SpriteRenderer>();

        anim_p = GameObject.Find("EnemyBullet").GetComponent<StayDistant>().anim_pos;

        module = Vector3.Magnitude(anim_p);
        inputDirection = anim_p / module;
    }

    // Update is called once per frame
    void Update()
    {
        Animate();
    }


    void Animate()
    {
        if (inputDirection.x < 0.5f && inputDirection.x > -0.5f &&
            inputDirection.y > 0)
        {
            //DOWN
            rend.sprite = down;
        }
        else if (inputDirection.x < 0.5f && inputDirection.x > -0.5f &&
            inputDirection.y < 0)
        {
            //UP
            rend.sprite = up;
        }
        else if (inputDirection.y < 0.5f && inputDirection.y > -0.5f &&
            inputDirection.x < 0)
        {
            //LEFT
            rend.sprite = left;
        }
        else if (inputDirection.y < 0.5f && inputDirection.y > -0.5f &&
             inputDirection.x > 0)
        {
            //RIGHT
            rend.sprite = right;
        }

    }
}
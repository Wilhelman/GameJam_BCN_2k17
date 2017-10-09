using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bar3 : MonoBehaviour
{
	//
	public Sprite empty;
	public Sprite one;
	public Sprite two;
	public Sprite three;
	public Sprite four;

    public P3 P3;

	public float time = 0;

	public Image image;

	// Use this for initialization
	void Start()
	{
        P3 = GameObject.Find("P3").GetComponent<P3>();
		image = gameObject.GetComponent<Image>();
	}

	// Update is called once per frame
	void Update()
	{

        if (P3.dashState == P3.DashState.Dashing || P3.dashState == P3.DashState.Cooldown && P3.enter)
		{
			if (time == 0.0f)
			{
				image.sprite = empty;
				//Animación base
			}

			time += Time.deltaTime;

			if (time >= 1.5f && time < 3.0f)
			{
				image.sprite = one;
				//Animación 1
			}

			if (time >= 3.0f && time < 4.5f)
			{
				image.sprite = two;
				//Animación 2
			}

			if (time >= 4.5f && time < 6.0f)
			{
				image.sprite = three;
				//Animación 3
			}

			if (time >= 6.0f)
			{
				image.sprite = four;
				//Animación 4
				time = 0;
                P3.enter = false;
			}
		}

	}
}

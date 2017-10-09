using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Text4 : MonoBehaviour
{
	public Text text;

    public Bullet4 bullet;

	int color = 0;
	int name = 0;

	bool do_once = true;

	string[] names;

	// Use this for initialization
	void Start()
	{
		//bullet = GameObject.Find("Bullet").GetComponent<Bullet1>();
        bullet = GetComponentInParent<Bullet4>();
		text = gameObject.GetComponent<Text>();
		do_once = true;
		color = Random.Range(0, 4);
		name = Random.Range(0, 6);

		names = new string[6];

		names[0] = "SEXY";
		names[1] = "KAWAII";
		names[2] = "LOVE";
		names[3] = "PRETTY";
		names[4] = "NICE";
		names[5] = "U\nROCK!";
	}

	// Update is called once per frame
	void Update()
	{
		if (bullet.rainbow)
		{
			ChangeColor();
			ChangeName();
			do_once = false;
		}
	}

	void ChangeColor()
	{
		if (color == 0)
			text.color = Color.blue;
		else if (color == 1)
			text.color = Color.green;
		else if (color == 2)
			text.color = Color.yellow;
		else if (color == 3)
			text.color = Color.red;

	}

	void ChangeName()
	{

		text.text = names[name];

	}
}

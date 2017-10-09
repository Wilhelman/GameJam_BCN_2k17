using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Head3 : MonoBehaviour
{
	//
	Animator animator;
    P3 player;

	// Use this for initialization
	void Start()
	{
		animator = GetComponent<Animator>();

        player = GetComponentInParent<P3>();
	}

	// Update is called once per frame
	void Update()
	{
		Animation();
	}

	void Animation()
	{
        if (player.dashState == P3.DashState.Dashing)
		{
			animator.SetBool("dashing", true);
		}
		else
		{
			animator.SetBool("dashing", false);
		}

		if (player.isSad)
		{
			animator.SetBool("isSad", true);
		}
		else
		{
			animator.SetBool("isSad", false);
		}

		if (Input.GetAxis("P3_RightJoystickHorizontal") > 0 && Input.GetAxis("P3_RightJoystickVertical") > 0)
		{
			//DownRight
			animator.SetBool("downright", true);

			animator.SetBool("topright", false);
			animator.SetBool("right", false);
			animator.SetBool("left", false);
			animator.SetBool("front", false);
			animator.SetBool("back", false);
			animator.SetBool("downleft", false);
			animator.SetBool("topleft", false);
		}
		else if (Input.GetAxis("P3_RightJoystickHorizontal") > 0 && Input.GetAxis("P3_RightJoystickVertical") < 0)
		{
			//TopRight
			animator.SetBool("topright", true);

			animator.SetBool("downright", false);
			animator.SetBool("right", false);
			animator.SetBool("left", false);
			animator.SetBool("front", false);
			animator.SetBool("back", false);
			animator.SetBool("downleft", false);
			animator.SetBool("topleft", false);
		}
		else if (Input.GetAxis("P3_RightJoystickHorizontal") > 0 && Input.GetAxis("P3_RightJoystickVertical") == 0)
		{
			//Right
			animator.SetBool("right", true);

			animator.SetBool("topright", false);
			animator.SetBool("downright", false);
			animator.SetBool("left", false);
			animator.SetBool("front", false);
			animator.SetBool("back", false);
			animator.SetBool("downleft", false);
			animator.SetBool("topleft", false);
		}
		else if (Input.GetAxis("P3_RightJoystickHorizontal") < 0 && Input.GetAxis("P3_RightJoystickVertical") == 0)
		{
			//Left
			animator.SetBool("left", true);

			animator.SetBool("topright", false);
			animator.SetBool("right", false);
			animator.SetBool("downright", false);
			animator.SetBool("front", false);
			animator.SetBool("back", false);
			animator.SetBool("downleft", false);
			animator.SetBool("topleft", false);
		}
		else if (Input.GetAxis("P3_RightJoystickHorizontal") == 0 && Input.GetAxis("P3_RightJoystickVertical") > 0)
		{
			//Front
			animator.SetBool("front", true);

			animator.SetBool("topright", false);
			animator.SetBool("right", false);
			animator.SetBool("left", false);
			animator.SetBool("downright", false);
			animator.SetBool("back", false);
			animator.SetBool("downleft", false);
			animator.SetBool("topleft", false);
		}
		else if (Input.GetAxis("P3_RightJoystickHorizontal") == 0 && Input.GetAxis("P3_RightJoystickVertical") < 0)
		{
			//Back
			animator.SetBool("back", true);

			animator.SetBool("topright", false);
			animator.SetBool("right", false);
			animator.SetBool("left", false);
			animator.SetBool("front", false);
			animator.SetBool("downright", false);
			animator.SetBool("downleft", false);
			animator.SetBool("topleft", false);
		}
		else if (Input.GetAxis("P3_RightJoystickHorizontal") < 0 && Input.GetAxis("P3_RightJoystickVertical") > 0)
		{
			//DownLeft
			animator.SetBool("downleft", true);

			animator.SetBool("topright", false);
			animator.SetBool("right", false);
			animator.SetBool("left", false);
			animator.SetBool("front", false);
			animator.SetBool("back", false);
			animator.SetBool("downright", false);
			animator.SetBool("topleft", false);
		}
		else if (Input.GetAxis("P3_RightJoystickHorizontal") < 0 && Input.GetAxis("P3_RightJoystickVertical") < 0)
		{
			//TopLeft
			animator.SetBool("topleft", true);

			animator.SetBool("topright", false);
			animator.SetBool("right", false);
			animator.SetBool("left", false);
			animator.SetBool("front", false);
			animator.SetBool("back", false);
			animator.SetBool("downleft", false);
			animator.SetBool("downright", false);
		}
		else
		{
			animator.SetBool("front", true);

			animator.SetBool("topleft", false);
			animator.SetBool("topright", false);
			animator.SetBool("right", false);
			animator.SetBool("left", false);
			animator.SetBool("back", false);
			animator.SetBool("downleft", false);
			animator.SetBool("downright", false);
		}
	}
}

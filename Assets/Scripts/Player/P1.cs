using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P1 : MonoBehaviour
{
    public AudioSource source;
    public AudioClip clip;

    public AudioSource sourceshoot;
    public AudioClip clipshoot;

    public Vector3 inputDirection;
	public Vector3 bulletDirection;
	public Vector3 bulletPosition;

	public GameObject bullet;
	public int movementVelocity = 2;

	public float time = 0.0f;
	private float interpolationPeriod = 1.0f;

    //VARIABLES

    public bool isSad = false;

	public Directions movementDirection;
	public DashState dashState;

	public float dashTimer;
	public float maxDash = 20f;

	//shield
	public GameObject shieldHorizontal;
	public GameObject shieldVertical;
	public GameObject shieldLeftRightDiagonal;
	public GameObject shieldRightLeftDiagonal;

    private GameObject currentShield;

    private Animator shieldAnim;

    private BigBudy buddy;

    public bool enter = false;

	public enum DashState
	{
		Ready,
		Dashing,
		Cooldown
	}

	public enum Directions
	{
		DownRight,
		Down,
		DownLeft,
		Left,
		TopLeft,
		Top,
		TopRight,
		Right,
		None
	}

	// Use this for initialization
	void Start()
	{
        sourceshoot.clip = clipshoot;

        source.clip = clip;

		inputDirection = Vector3.zero;

        bullet = GameObject.Find("Bullet1");

        isSad = false;
	}

	void FixedUpdate()
	{
        if(!isSad){
			if (dashState != DashState.Dashing)
				Movement();

			switch (dashState)
			{
				case DashState.Ready:
					enter = false;
                    if (Input.GetKey(KeyCode.Space))
                    {
						CreateShield();
						dashState = DashState.Dashing;
					}
					break;
				case DashState.Dashing:
					enter = true;
					dashTimer += Time.deltaTime * 4;
					Dash();
					if (dashTimer >= maxDash)
					{
						dashTimer = maxDash;

						dashState = DashState.Cooldown;
					}
					break;
				case DashState.Cooldown:
					dashTimer -= Time.deltaTime;
					if (dashTimer <= -5)
					{
						dashTimer = 0;
						dashState = DashState.Ready;
					}
					break;
			}
        }
		
	}

	// Update is called once per frame
	void Update()
	{
        if(!isSad){
			if (Input.GetAxis("P1_RightJoystickHorizontal") != 0 || Input.GetAxis("P1_RightJoystickVertical") != 0)
			{
				time -= Time.deltaTime;

				if (time <= 0.0f)
				{
					Shoot();
					time = interpolationPeriod;
				}
			}
        }
		

	}

    void CreateShield(){

        Vector3 shieldPosition = transform.position;

		switch (movementDirection)
		{
			case Directions.Top:
				shieldPosition += new Vector3(0, 140, 0);
                currentShield = Instantiate(shieldVertical, shieldPosition, Quaternion.identity);
                transform.position += new Vector3(0, 20, 0);
				break;
			case Directions.TopRight:
				shieldPosition += new Vector3(140, 140, 0);
				currentShield = Instantiate(shieldRightLeftDiagonal, shieldPosition, Quaternion.identity);
				transform.position += new Vector3(20, 20, 0);
				break;
			case Directions.TopLeft:
				shieldPosition += new Vector3(-140, 140, 0);
				currentShield = Instantiate(shieldLeftRightDiagonal, shieldPosition, Quaternion.identity);
				transform.position += new Vector3(-20, 20, 0);
				break;
			case Directions.Right:
                shieldPosition += new Vector3(140, 0, 0);
                currentShield = Instantiate(shieldHorizontal, shieldPosition, Quaternion.identity);
				transform.position += new Vector3(20, 0, 0);

				break;
			case Directions.DownRight:

				shieldPosition += new Vector3(140, -140, 0);
                currentShield = Instantiate(shieldLeftRightDiagonal, shieldPosition, Quaternion.identity);
				transform.position += new Vector3(20, -20, 0);
				break;
			case Directions.Down:
				shieldPosition += new Vector3(0, -140, 0);
				currentShield = Instantiate(shieldVertical, shieldPosition, Quaternion.identity);
				transform.position += new Vector3(0, -20, 0);
				break;
			case Directions.DownLeft:

				shieldPosition += new Vector3(-140, -140, 0);
                currentShield = Instantiate(shieldRightLeftDiagonal, shieldPosition, Quaternion.identity);
				transform.position += new Vector3(-20, -20, 0);
				break;
			case Directions.Left:
				shieldPosition += new Vector3(-140, 0, 0);
				currentShield = Instantiate(shieldHorizontal, shieldPosition, Quaternion.identity);
				transform.position += new Vector3(-20, 0, 0);

				break;
			default:
				break;
		}
        PrepareForShieldDeath();
    }

    void PrepareForShieldDeath(){
        StartCoroutine(DeadTime(3f));
    }

	void Movement()
	{
		GetMovementDirection();
		inputDirection.x = Input.GetAxis("P1_LeftJoystickHorizontal");
		inputDirection.y = (-1) * Input.GetAxis("P1_LeftJoystickVertical");
        if (this.transform.position.y >= 474 && inputDirection.y > 0 || this.transform.position.y <= -474 && inputDirection.y < 0)
            inputDirection.y = 0;
		if (this.transform.position.x >= 880 && inputDirection.x > 0 || this.transform.position.x <= -880 && inputDirection.x < 0)
			inputDirection.x = 0;
		transform.position += movementVelocity * inputDirection;
	}

	void Shoot()
	{
        sourceshoot.Play();
        //Instantiate(GameObject.Find("EnemyDone"), new Vector3(0,0,-1), Quaternion.identity);

		bulletDirection.x = Input.GetAxis("P1_RightJoystickHorizontal");
		bulletDirection.y = (-1) * Input.GetAxis("P1_RightJoystickVertical");

		bulletPosition = transform.position;

		Instantiate(bullet, bulletPosition, Quaternion.identity);
    }

	void GetMovementDirection()
	{
		if (Input.GetAxis("P1_LeftJoystickHorizontal") > 0 && Input.GetAxis("P1_LeftJoystickVertical") > 0)
		{
			//DownRight
			movementDirection = Directions.DownRight;

		}
		else if (Input.GetAxis("P1_LeftJoystickHorizontal") > 0 && Input.GetAxis("P1_LeftJoystickVertical") < 0)
		{
			//TopRight
			movementDirection = Directions.TopRight;
		}
		else if (Input.GetAxis("P1_LeftJoystickHorizontal") > 0 && Input.GetAxis("P1_LeftJoystickVertical") == 0)
		{
			//Right
			movementDirection = Directions.Right;
		}
		else if (Input.GetAxis("P1_LeftJoystickHorizontal") < 0 && Input.GetAxis("P1_LeftJoystickVertical") == 0)
		{
			//Left
			movementDirection = Directions.Left;
		}
		else if (Input.GetAxis("P1_LeftJoystickHorizontal") == 0 && Input.GetAxis("P1_LeftJoystickVertical") > 0)
		{
			//Front
			movementDirection = Directions.Down;
		}
		else if (Input.GetAxis("P1_LeftJoystickHorizontal") == 0 && Input.GetAxis("P1_LeftJoystickVertical") < 0)
		{
			//Back
			movementDirection = Directions.Top;
		}
		else if (Input.GetAxis("P1_LeftJoystickHorizontal") < 0 && Input.GetAxis("P1_LeftJoystickVertical") > 0)
		{
			//DownLeft
			movementDirection = Directions.DownLeft;
		}
		else if (Input.GetAxis("P1_LeftJoystickHorizontal") < 0 && Input.GetAxis("P1_LeftJoystickVertical") < 0)
		{
			//TopLeft
			movementDirection = Directions.TopLeft;
		}
		else
		{
			//no dir
			movementDirection = Directions.None;
		}
	}

	void Dash()
	{
        source.Play();
		switch (movementDirection)
		{
			case Directions.Top:
                if (this.transform.position.y >= 474 && inputDirection.y > 0 || this.transform.position.y <= -474 && inputDirection.y < 0){
                    
                }else
					transform.position += new Vector3(0, 20, 0);
				
				break;
			case Directions.TopRight:
                if ((this.transform.position.y >= 474 && inputDirection.y > 0 || this.transform.position.y <= -474 && inputDirection.y < 0) || (this.transform.position.x >= 880 && inputDirection.x > 0 || this.transform.position.x <= -880 && inputDirection.x < 0)){
                    
                }else
					transform.position += new Vector3(20, 20, 0);
				break;
			case Directions.TopLeft:
				if ((this.transform.position.y >= 474 && inputDirection.y > 0 || this.transform.position.y <= -474 && inputDirection.y < 0) || (this.transform.position.x >= 880 && inputDirection.x > 0 || this.transform.position.x <= -880 && inputDirection.x < 0))
				{

				}
				else
					transform.position += new Vector3(-20, 20, 0);
				break;
			case Directions.Right:
				if ((this.transform.position.y >= 474 && inputDirection.y > 0 || this.transform.position.y <= -474 && inputDirection.y < 0) || (this.transform.position.x >= 880 && inputDirection.x > 0 || this.transform.position.x <= -880 && inputDirection.x < 0))
				{

				}
				else
					transform.position += new Vector3(20, 0, 0);
				break;
			case Directions.DownRight:
				if ((this.transform.position.y >= 474 && inputDirection.y > 0 || this.transform.position.y <= -474 && inputDirection.y < 0) || (this.transform.position.x >= 880 && inputDirection.x > 0 || this.transform.position.x <= -880 && inputDirection.x < 0))
				{

				}
				else
					transform.position += new Vector3(20, -20, 0);
				break;
			case Directions.Down:
				if ((this.transform.position.y >= 474 && inputDirection.y > 0 || this.transform.position.y <= -474 && inputDirection.y < 0) || (this.transform.position.x >= 880 && inputDirection.x > 0 || this.transform.position.x <= -880 && inputDirection.x < 0))
				{

				}
				else
					transform.position += new Vector3(0, -20, 0);
				break;
			case Directions.DownLeft:
				if ((this.transform.position.y >= 474 && inputDirection.y > 0 || this.transform.position.y <= -474 && inputDirection.y < 0) || (this.transform.position.x >= 880 && inputDirection.x > 0 || this.transform.position.x <= -880 && inputDirection.x < 0))
				{

				}
				else
					transform.position += new Vector3(-20, -20, 0);
				break;
			case Directions.Left:
				if ((this.transform.position.y >= 474 && inputDirection.y > 0 || this.transform.position.y <= -474 && inputDirection.y < 0) || (this.transform.position.x >= 880 && inputDirection.x > 0 || this.transform.position.x <= -880 && inputDirection.x < 0))
				{

				}
				else
					transform.position += new Vector3(-20, 0, 0);
				break;
			default:
				break;
		}
	}

	IEnumerator DeadTime(float time)
	{
		yield return new WaitForSeconds(time);
        shieldAnim = currentShield.GetComponent<Animator>();
        shieldAnim.SetBool("hasToDissapear",true);
        StartCoroutine(animTime(0.5f));
	}

	IEnumerator animTime(float time)
	{
		yield return new WaitForSeconds(time);
		Destroy(currentShield);
	}

	private void OnTriggerEnter2D(Collider2D col)
	{

        //enemigo toca al player
		if (col.gameObject.tag == "Enemy")
		{
            buddy = col.gameObject.GetComponent<BigBudy>();
            if (!buddy.ent)
                isSad = true;
		}

		if (col.gameObject.tag == "EnemyBullet")
		{
					isSad = true;
		}


		
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
	public GameObject GameControl;
	public bool InCountdown = false;
	public bool InFinish = false;

	private Rigidbody2D playerRigidbody2D;
	private GameControl gameControlScript;
	private float SnailSpeed;
	private float ExtraSpeedCoefficient;
	private float ExtraSpeedx4Coefficient;
	private float PowerUpTime;
	private bool moveRegisteredSnail1 = false;
	private bool moveRegisteredSnail2 = false;

	// Use this for initialization
	void Start ()
	{
		gameControlScript = GameControl.GetComponent<GameControl>();
		playerRigidbody2D = GetComponent<Rigidbody2D>();

		SnailSpeed = gameControlScript.SnailSpeed;
		ExtraSpeedCoefficient = gameControlScript.ExtraSpeedCoefficient;
		ExtraSpeedx4Coefficient = gameControlScript.ExtraSpeedx4Coefficient;
		PowerUpTime = gameControlScript.PowerUpTime;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (!InCountdown && !InFinish)
		{
			if (gameObject.tag == "Player1")
			{
				if (Input.GetKeyDown(KeyCode.A))
				{
					moveRegisteredSnail1 = true;
				}
			}
			else if (gameObject.tag == "Player2")
			{
				if (Input.GetKeyDown(KeyCode.L))
				{
					moveRegisteredSnail2 = true;
				}
			}
		}

		if (Input.GetKeyDown(KeyCode.Escape))
		{
			Application.Quit();
		}
	}

	void FixedUpdate()
	{
		if (moveRegisteredSnail1)
		{
			playerRigidbody2D.velocity = new Vector2(SnailSpeed, 0);

			moveRegisteredSnail1 = false;
		}

		if (moveRegisteredSnail2)
		{
			playerRigidbody2D.velocity = new Vector2(SnailSpeed, 0);

			moveRegisteredSnail2 = false;
		}
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Finish")
		{
			gameControlScript.StartFinish(gameObject);
		}
	}

	public void PickedUpExtraSpeed()
	{
		SnailSpeed *= ExtraSpeedCoefficient;

		StartCoroutine(BackToNormalSpeed(ExtraSpeedCoefficient));
	}

	public void PickedUpExtraSpeedx4()
	{
		SnailSpeed *= ExtraSpeedx4Coefficient;

		StartCoroutine(BackToNormalSpeed(ExtraSpeedx4Coefficient));
	}

	public void EnterFrenzy()
	{
		SnailSpeed *= ExtraSpeedx4Coefficient;

		StartCoroutine(BackToNormalSpeed(ExtraSpeedx4Coefficient));
	}

	IEnumerator BackToNormalSpeed(float coefficient)
	{
		yield return new WaitForSeconds(PowerUpTime);

		SnailSpeed /= coefficient;
	}
}

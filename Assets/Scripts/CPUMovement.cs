using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CPUMovement : MonoBehaviour
{
	public GameObject GameControl;
	public bool InCountdown = false;
	public bool InFinish = false;

	private Rigidbody2D cpuRigidbody2D;
	private GameControl gameControlScript;
	private float SnailSpeed;
	private float cpuSnailSpeed;
	private float ExtraSpeedCoefficient;
	private float ExtraSpeedx4Coefficient;
	private float PowerUpTime;

	// Use this for initialization
	void Start ()
	{
		gameControlScript = GameControl.GetComponent<GameControl>();
		cpuRigidbody2D = GetComponent<Rigidbody2D>();

		SnailSpeed = gameControlScript.SnailSpeed;
		cpuSnailSpeed = gameControlScript.CPUSnailSpeed;
		ExtraSpeedCoefficient = gameControlScript.ExtraSpeedCoefficient;
		ExtraSpeedx4Coefficient = gameControlScript.ExtraSpeedx4Coefficient;
		PowerUpTime = gameControlScript.PowerUpTime;
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}

	void FixedUpdate()
	{
		if (!InCountdown && !InFinish)
		{
			if (Random.value > cpuSnailSpeed)
			{
				cpuRigidbody2D.velocity = new Vector2(SnailSpeed, 0);
			}
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

	IEnumerator BackToNormalSpeed(float coefficient)
	{
		yield return new WaitForSeconds(PowerUpTime);

		SnailSpeed /= coefficient;
	}
}

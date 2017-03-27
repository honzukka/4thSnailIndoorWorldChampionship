using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtraSpeedPowerUp : MonoBehaviour
{
	public GameObject ExtraSpeedPickedUp;
	
	// Use this for initialization
	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "Player1" || other.gameObject.tag == "Player2")
		{
			other.gameObject.GetComponent<PlayerMovement>().PickedUpExtraSpeed();
		}
		else
		{
			other.gameObject.GetComponent<CPUMovement>().PickedUpExtraSpeed();
		}

		ExtraSpeedPickedUp.SetActive(true);
		ExtraSpeedPickedUp.gameObject.GetComponent<PowerUpPickedUp>().ReactToInitiator(other.gameObject.tag);
		gameObject.SetActive(false);
	}
}

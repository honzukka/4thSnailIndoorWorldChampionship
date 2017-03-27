using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtraSpeedx4PowerUp : MonoBehaviour
{
	public GameObject ExtraSpeedx4PickedUp;
	
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
			other.gameObject.GetComponent<PlayerMovement>().PickedUpExtraSpeedx4();
		}
		else
		{
			other.gameObject.GetComponent<CPUMovement>().PickedUpExtraSpeedx4();
		}

		ExtraSpeedx4PickedUp.SetActive(true);
		ExtraSpeedx4PickedUp.gameObject.GetComponent<PowerUpPickedUp>().ReactToInitiator(other.gameObject.tag);
		gameObject.SetActive(false);
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpPickedUp : MonoBehaviour
{
	private AudioSource audioSource;
	
	// Use this for initialization
	public void Start ()
	{

	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}

	public void ReactToInitiator(string initiatior)
	{
		audioSource = GetComponent<AudioSource>();
		GetComponentInParent<GameControl>().PowerUpPickedUp(initiatior, gameObject.name);

		// play sound based on the power-up type
		switch (gameObject.name)
		{
			case "ANicePhotoPickedUp":
				audioSource.clip = Resources.Load("pickup1") as AudioClip;
				audioSource.Play();
				break;
			case "BusTicketPickedUp":
				audioSource.clip = Resources.Load("pickup2") as AudioClip;
				audioSource.Play();
				break;
			case "HeadphonesPickedUp":
				audioSource.clip = Resources.Load("pickup3") as AudioClip;
				audioSource.Play();
				break;
			case "HealthPickedUp":
				audioSource.clip = Resources.Load("pickup4") as AudioClip;
				audioSource.Play();
				break;
			case "ExtraSpeedPickedUp":
				audioSource.clip = Resources.Load("pickupspeed1") as AudioClip;
				audioSource.Play();
				break;
			case "ExtraSpeedx4PickedUp":
				audioSource.clip = Resources.Load("pickupspeed2") as AudioClip;
				audioSource.Play();
				break;
			default:
				break;
		}

		switch (initiatior)
		{
			case "Player1":
				gameObject.transform.position = new Vector3(-4.65f, 1.26f, 0);
				GetComponent<Animation>().Play("PowerUpPickUpAnimation");
				break;
			case "Player2":
				gameObject.transform.position = new Vector3(0.25f, 1.26f, 0);
				GetComponent<Animation>().Play("PowerUpPickUpAnimation");
				break;
			default:
				//gameObject.GetComponent<SpriteRenderer>().enabled = false;
				gameObject.SetActive(false);
				break;
		}
	}

	public void Deactivate()
	{
		gameObject.SetActive(false);
	}
}

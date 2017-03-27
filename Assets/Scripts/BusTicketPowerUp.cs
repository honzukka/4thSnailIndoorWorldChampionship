using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BusTicketPowerUp : MonoBehaviour
{
	public GameObject BusTicketPickedUp;
	
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
		BusTicketPickedUp.SetActive(true);
		BusTicketPickedUp.gameObject.GetComponent<PowerUpPickedUp>().ReactToInitiator(other.gameObject.tag);
		gameObject.SetActive(false);
	}
}

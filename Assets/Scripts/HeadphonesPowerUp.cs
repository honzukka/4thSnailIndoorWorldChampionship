using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadphonesPowerUp : MonoBehaviour
{
	public GameObject HeadphonesPickedUp;
	
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
		HeadphonesPickedUp.SetActive(true);
		HeadphonesPickedUp.gameObject.GetComponent<PowerUpPickedUp>().ReactToInitiator(other.gameObject.tag);
		gameObject.SetActive(false);
	}
}

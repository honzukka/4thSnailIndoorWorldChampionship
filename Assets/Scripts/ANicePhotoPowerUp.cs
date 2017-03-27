using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ANicePhotoPowerUp : MonoBehaviour
{
	public GameObject ANicePhotoPickedUp;
	
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
		ANicePhotoPickedUp.SetActive(true);
		ANicePhotoPickedUp.gameObject.GetComponent<PowerUpPickedUp>().ReactToInitiator(other.gameObject.tag);
		gameObject.SetActive(false);
	}
}

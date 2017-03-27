using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinishControl : MonoBehaviour
{
	public GameObject GameControl;
	public Image FinishImage;

	private GameControl gameControlScript;
	private AudioSource audioSource;

	// Use this for initialization
	void Start ()
	{
		gameControlScript = GameControl.GetComponent<GameControl>();
		audioSource = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}

	public void ShowFinish()
	{
		FinishImage.gameObject.SetActive(true);
		audioSource.Play();
	}

	public void ShowQuitMessage()
	{
		gameControlScript.ShowQuitMessage();
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountdownControl : MonoBehaviour
{
	public GameObject GameControl;
	public AudioClip CountdownSound1;
	public AudioClip CountdownSound2;
	public Image Countdown3;
	public Image Countdown2;
	public Image Countdown1;
	public Image CountdownGo;

	private GameControl gameControlScript;
	private AudioSource audioSource;
	private Image panelImage;
	private Animation countdownAnimation;

	// Use this for initialization
	void Start ()
	{
		gameControlScript = GameControl.GetComponent<GameControl>();
		audioSource = GetComponent<AudioSource>();
		panelImage = GetComponent<Image>();

		countdownAnimation = GetComponent<Animation>();
		countdownAnimation.Play("CountdownAnimation");
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}

	public void Three()
	{
		Countdown3.gameObject.SetActive(true);
		audioSource.clip = CountdownSound1;
		audioSource.Play();
	}

	public void Two()
	{
		Countdown3.gameObject.SetActive(false);
		Countdown2.gameObject.SetActive(true);
		audioSource.clip = CountdownSound1;
		audioSource.Play();
	}

	public void One()
	{
		Countdown2.gameObject.SetActive(false);
		Countdown1.gameObject.SetActive(true);
		audioSource.clip = CountdownSound1;
		audioSource.Play();
	}

	public void Go()
	{
		Color panelColor = panelImage.color;
		panelColor.a = 0;
		panelImage.color = panelColor;

		Countdown1.gameObject.SetActive(false);
		CountdownGo.gameObject.SetActive(true);

		audioSource.clip = CountdownSound2;
		audioSource.Play();

		gameControlScript.StopCountdown();
	}

	public void Deactivate()
	{
		gameObject.SetActive(false);
	}
}

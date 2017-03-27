using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrenzyBarControl : MonoBehaviour
{
	public GameObject GameControl;
	public GameObject Player1Snail;
	public GameObject Player2Snail;
	public GameObject FrenzyImage;
	public Material RedMaterial;
	public Material WhiteMaterial;

	private LineRenderer bar;
	private Animation barAnimation;
	private AudioSource audioSource;
	private GameControl gameObjectScript;
	private PlayerMovement player1SnailScript;
	private PlayerMovement player2SnailScript;
	private bool countdownIsOver = false;
	private bool winnerIsKnown = false;
	private bool inFrenzy = false;
	private float barStep;
	private float barDecreaseStepTime;

	// Use this for initialization
	void Start ()
	{
		bar = GetComponent<LineRenderer>();
		barAnimation = GetComponent<Animation>();
		audioSource = GetComponent<AudioSource>();
		gameObjectScript = GameControl.GetComponent<GameControl>();
		player1SnailScript = Player1Snail.GetComponent<PlayerMovement>();
		player2SnailScript = Player2Snail.GetComponent<PlayerMovement>();
		bar.material = RedMaterial;

		barStep = gameObjectScript.FrenzyBarStep;
		barDecreaseStepTime = gameObjectScript.FrenzyBarDecreaseStepTime;

		StartCoroutine(DecreaseGradually());
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (countdownIsOver && !winnerIsKnown && !inFrenzy)
		{
			if (gameObject.tag == "Bar1")
			{
				if (Input.GetKeyDown(KeyCode.A))
				{
					Vector3 position2 = bar.GetPosition(1);
					position2.x += barStep;

					bar.SetPosition(1, position2);

					if (position2.x >= -2.82f)
					{
						EnterFrenzy("Player1");
					}
				}
			}
			else if (gameObject.tag == "Bar2")
			{
				if (Input.GetKeyDown(KeyCode.L))
				{
					Vector3 position2 = bar.GetPosition(1);
					position2.x += barStep;

					bar.SetPosition(1, position2);

					if (position2.x >= 2.12f)
					{
						EnterFrenzy("Player2");
					}
				}
			}
		}
	}

	IEnumerator DecreaseGradually()
	{
		// until the end of the race
		while (!winnerIsKnown && !inFrenzy)
		{
			// if the bar isn't at zero
			if (bar.GetPosition(0).x < bar.GetPosition(1).x)
			{
				Vector3 position2 = bar.GetPosition(1);
				position2.x -= barStep;

				bar.SetPosition(1, position2);
			}

			yield return new WaitForSeconds(barDecreaseStepTime);
		}
	}

	public void SetCountdownIsOver(bool value)
	{
		countdownIsOver = value;
	}

	public void SetWinnerIsKnown(bool value)
	{
		winnerIsKnown = value;
	}

	public void SwitchMaterialToRed()
	{
		bar.material = RedMaterial;
	}

	public void SwitchMaterialToWhite()
	{
		bar.material = WhiteMaterial;
	}

	private void EnterFrenzy(string snail)
	{
		inFrenzy = true;
		gameObjectScript.FrenzyModeEntered(snail);

		// the effect is equal to extra speed x4
		if (snail == "Player1")
		{
			player1SnailScript.EnterFrenzy();
		}
		else if (snail == "Player2")
		{
			player2SnailScript.EnterFrenzy();
		}
		else
		{
			print("FIX THE BUG!");
		}

		audioSource.Play();
		barAnimation.Play("FrenzyBarAnimation");
		FrenzyImage.gameObject.SetActive(true);

		StartCoroutine(StopFrenzy());
	}

	IEnumerator StopFrenzy()
	{
		yield return new WaitForSeconds(gameObjectScript.PowerUpTime);

		inFrenzy = false;
		bar.SetPosition(1, bar.GetPosition(0));
		barAnimation.Stop();
		FrenzyImage.gameObject.SetActive(false);

		// it must have ended previously because the loop inside breaks when inFrenzy == true
		StartCoroutine(DecreaseGradually());
	}
}

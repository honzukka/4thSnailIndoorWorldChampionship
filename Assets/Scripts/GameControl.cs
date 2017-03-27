using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

enum EventType
{
	Empty,
	Random,
	Start,
	NewLeader,
	PowerUp,
	Frenzy
}

public class GameControl : MonoBehaviour
{
	public float SnailSpeed;
	public float CPUSnailSpeed;
	public float ExtraSpeedCoefficient;
	public float ExtraSpeedx4Coefficient;
	public float PowerUpTime;
	public float FrenzyBarStep;
	public float FrenzyBarDecreaseStepTime;
	public float CommentTime;

	public GameObject Player1Snail;
	public GameObject Player2Snail;
	public GameObject CPU1Snail;
	public GameObject CPU2Snail;
	public GameObject Countdown;
	public GameObject Finish;
	public Text InfoBarText;
	public GameObject FrenzyBar1;
	public GameObject FrenzyBar2;

	public GameObject[] PowerUpPrefabs;

	public AudioClip[] CommentaryClips;

	private PlayerMovement player1SnailScript;
	private PlayerMovement player2SnailScript;
	private CPUMovement cpu1SnailScript;
	private CPUMovement cpu2SnailScript;
	private TextDatabase textDatabaseScript;
	private FrenzyBarControl frenzyBar1Script;
	private FrenzyBarControl frenzyBar2Script;

	private AudioSource audioSource;

	private EventType recentEvent = EventType.Empty;
	private GameObject currentLeader = null;
	private bool winnerKnown = false;
	private string recentPowerUp = "";
	private string recentPoweredUpSnail = "";
	private string recentFrenziedSnail = "";

	// Use this for initialization
	void Start ()
	{
		player1SnailScript = Player1Snail.GetComponent<PlayerMovement>();
		player2SnailScript = Player2Snail.GetComponent<PlayerMovement>();
		cpu1SnailScript = CPU1Snail.GetComponent<CPUMovement>();
		cpu2SnailScript = CPU2Snail.GetComponent<CPUMovement>();
		textDatabaseScript = GetComponent<TextDatabase>();
		frenzyBar1Script = FrenzyBar1.GetComponent<FrenzyBarControl>();
		frenzyBar2Script = FrenzyBar2.GetComponent<FrenzyBarControl>();

		audioSource = GetComponent<AudioSource>();

		InstantiatePowerUps();

		StartCountdown();
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (ThereIsANewLeader())
		{
			recentEvent = EventType.NewLeader;
		}
	}

	// the very beginning of the game, start the countdown
	public void StartCountdown()
	{
		player1SnailScript.InCountdown = true;
		player2SnailScript.InCountdown = true;
		cpu1SnailScript.InCountdown = true;
		cpu2SnailScript.InCountdown = true;

		Countdown.SetActive(true);
	}

	// winner (initiator) has been registered, show commentary and finish animation
	public void StartFinish(GameObject initiator)
	{
		if (!winnerKnown)
		{
			InfoBarText.text = textDatabaseScript.GetFinishLineCommentary(initiator.tag);

			audioSource.Stop();
			audioSource.clip = CommentaryClips[textDatabaseScript.GetLastLineNumber()];
			audioSource.Play();

			Finish.gameObject.SetActive(true);
			winnerKnown = true;
		}

		player1SnailScript.InFinish = true;
		player2SnailScript.InFinish = true;
		cpu1SnailScript.InFinish = true;
		cpu2SnailScript.InFinish = true;
		frenzyBar1Script.SetWinnerIsKnown(true);
		frenzyBar2Script.SetWinnerIsKnown(true);
	}

	// the end
	public void ShowQuitMessage()
	{
		InfoBarText.text = textDatabaseScript.GetQuitGameMessage();

		audioSource.Stop();
		audioSource.clip = CommentaryClips[textDatabaseScript.GetLastLineNumber()];
		audioSource.Play();
	}

	// countdown has stopped and we should tell snails to go
	public void StopCountdown()
	{
		player1SnailScript.InCountdown = false;
		player2SnailScript.InCountdown = false;
		cpu1SnailScript.InCountdown = false;
		cpu2SnailScript.InCountdown = false;
		frenzyBar1Script.SetCountdownIsOver(true);
		frenzyBar2Script.SetCountdownIsOver(true);

		recentEvent = EventType.Start;
		StartCoroutine("GenerateCommentary");
	}

	public void PowerUpPickedUp(string snail, string powerUp)
	{
		recentEvent = EventType.PowerUp;
		recentPoweredUpSnail = snail;
		recentPowerUp = powerUp;
	}

	public void FrenzyModeEntered(string snail)
	{
		recentEvent = EventType.Frenzy;
		recentFrenziedSnail = snail;
	}

	IEnumerator GenerateCommentary()
	{
		string lineToShow = "";

		while (winnerKnown == false)
		{
			if (recentEvent == EventType.NewLeader)
			{
				lineToShow = textDatabaseScript.GetNewLeaderCommentary(currentLeader.tag);

			}
			else if (recentEvent == EventType.Frenzy)
			{
				lineToShow = textDatabaseScript.GetFrenzyCommentary(recentFrenziedSnail);
			}
			else if (recentEvent == EventType.PowerUp)
			{
				lineToShow = textDatabaseScript.GetPowerUpCommentary(recentPoweredUpSnail, recentPowerUp);
			}
			else if (recentEvent == EventType.Start)
			{
				lineToShow = textDatabaseScript.GetStartCommentary();
			}
			else if (recentEvent == EventType.Random)
			{
				lineToShow = textDatabaseScript.GetRandomCommentary();
			}

			if (lineToShow != "")
			{
				InfoBarText.text = lineToShow;

				int clipIndex = textDatabaseScript.GetLastLineNumber();
				audioSource.Stop();
				audioSource.clip = CommentaryClips[clipIndex];
				audioSource.Play();
			}

			recentEvent = EventType.Random;

			yield return new WaitForSeconds(CommentTime);
		}
	}

	private bool ThereIsANewLeader()
	{
		float leadingPos;

		if (currentLeader == null)
		{
			leadingPos = -50f;
		}
		else
		{
			leadingPos = currentLeader.transform.position.x;
		}

		GameObject newLeader = currentLeader;

		if (Player1Snail.transform.position.x > leadingPos)
		{
			leadingPos = Player1Snail.transform.position.x;
			newLeader = Player1Snail;
		}

		if (Player2Snail.transform.position.x > leadingPos)
		{
			leadingPos = Player2Snail.transform.position.x;
			newLeader = Player2Snail;
		}

		if (CPU1Snail.transform.position.x > leadingPos)
		{
			leadingPos = CPU1Snail.transform.position.x;
			newLeader = CPU1Snail;
		}

		if (CPU2Snail.transform.position.x > leadingPos)
		{
			leadingPos = CPU2Snail.transform.position.x;
			newLeader = CPU2Snail;
		}

		if (newLeader == currentLeader)
		{
			return false;
		}
		else
		{
			currentLeader = newLeader;
			return true;
		}
	}

	private void InstantiatePowerUps()
	{
		// nice y-coordinates (of lanes 1 to 4)
		float[] yCoordinates = { -1.17f, -1.8f, -2.57f, -3.36f };

		for (int i = 0; i < PowerUpPrefabs.Length; i++)
		{
			int numberOfPrefabs = Random.Range(0, 40) / 10;

			for (int j = 0; j < numberOfPrefabs; j++)
			{
				float x = Random.Range(-2.5f, 4f);

				int randomYIndex = Random.Range(0, 40) / 10;
				float y = yCoordinates[randomYIndex];

				Instantiate(PowerUpPrefabs[i], new Vector3(x, y, 0), Quaternion.identity, gameObject.transform);
	
			}
		}
	}
}

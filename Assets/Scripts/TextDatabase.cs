using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextDatabase : MonoBehaviour
{
	private string quitGameMessage;
	private Dictionary<string, List<string>> finishLineCommentary;
	private Dictionary<string, List<string>> newLeaderCommentary;
	private Dictionary<string, Dictionary<string, string>> powerUpCommentary;
	private Dictionary<string, string> frenzyCommentary;
	private List<string> startCommentary;
	private List<string> randomCommentary;

	private Dictionary<string, int> lineToClipMapping;
	private string lastLine;

	void Start()
	{
		finishLineCommentary = new Dictionary<string, List<string>>();
		newLeaderCommentary = new Dictionary<string, List<string>>();
		powerUpCommentary = new Dictionary<string, Dictionary<string, string>>();
		frenzyCommentary = new Dictionary<string, string>();
		startCommentary = new List<string>();
		randomCommentary = new List<string>();

		lineToClipMapping = new Dictionary<string, int>();
		lastLine = "";

		initializeQuitGameMessage();
		initializeFinishLine();
		initializeNewLeader();
		initializePowerUp();
		initializeFrenzy();
		initializeStart();
		initializeRandomCommentary();

		initializeLineToClipMapping();
	}

	public string GetQuitGameMessage()
	{
		lastLine = quitGameMessage;

		return lastLine;
	}

	public string GetFinishLineCommentary(string winner)
	{
		int randomIndex = Random.Range(0, finishLineCommentary[winner].Count * 10) / 10;
		lastLine = finishLineCommentary[winner][randomIndex];

		return lastLine;
	}

	public string GetNewLeaderCommentary(string newLeader)
	{
		int randomIndex = Random.Range(0, newLeaderCommentary[newLeader].Count * 10) / 10;
		lastLine = newLeaderCommentary[newLeader][randomIndex];

		return lastLine;
	}

	public string GetPowerUpCommentary(string snail, string powerUp)
	{
		lastLine = powerUpCommentary[snail][powerUp];

		return lastLine;
	}

	public string GetFrenzyCommentary(string snail)
	{
		lastLine = frenzyCommentary[snail];

		return lastLine;
	}

	public string GetStartCommentary()
	{
		int randomIndex = (Random.Range(0, startCommentary.Count * 10) / 10);
		lastLine = startCommentary[randomIndex];

		return lastLine;
	}

	public string GetRandomCommentary()
	{
		int randomIndex = (Random.Range(0, randomCommentary.Count * 10) / 10);
		lastLine = randomCommentary[randomIndex];

		return lastLine;
	}

	public int GetLastLineNumber()
	{
		return lineToClipMapping[lastLine];
	}

	private void initializeQuitGameMessage()
	{
		quitGameMessage = "Press ESC to quit";
	}

	private void initializeFinishLine()
	{
		finishLineCommentary.Add("Player1", new List<string>());
		finishLineCommentary["Player1"].Add("Player 1 has dominated today!");
		finishLineCommentary["Player1"].Add("Player 1 is the fastest snail in the world!");

		finishLineCommentary.Add("Player2", new List<string>());
		finishLineCommentary["Player2"].Add("Ladies and gentlemen, we've just seen Player 2 rush through the finish line as the winner!");
		finishLineCommentary["Player2"].Add("Player 2 won so quickly we almost couldn't see it!");

		finishLineCommentary.Add("White House", new List<string>());
		finishLineCommentary["White House"].Add("A CPU snail has won this time! Her name is White House!");
		finishLineCommentary["White House"].Add("White House's white house is the house of a winner!");

		finishLineCommentary.Add("One-Eyed Jack", new List<string>());
		finishLineCommentary["One-Eyed Jack"].Add("One-Eyed Jack has toyed with the spectators one more time! He's the winner!");
		finishLineCommentary["One-Eyed Jack"].Add("One-Eyed Jack! Never have I seen such an amazing win!");
	}

	private void initializeNewLeader()
	{
		newLeaderCommentary.Add("Player1", new List<string>());
		newLeaderCommentary["Player1"].Add("Player 1 has gone in the lead!");
		newLeaderCommentary["Player1"].Add("Player 1 is flying towards victory!");

		newLeaderCommentary.Add("Player2", new List<string>());
		newLeaderCommentary["Player2"].Add("We have a new leader, ladies and gentlemen! It's Player 2!");
		newLeaderCommentary["Player2"].Add("Player 2 is in the lead!");

		newLeaderCommentary.Add("White House", new List<string>());
		newLeaderCommentary["White House"].Add("White House is rapidly escaping her opponents!");
		newLeaderCommentary["White House"].Add("White House is leading the race at the moment.");

		newLeaderCommentary.Add("One-Eyed Jack", new List<string>());
		newLeaderCommentary["One-Eyed Jack"].Add("One-Eyed Jack is the fastest snail on the track now!");
		newLeaderCommentary["One-Eyed Jack"].Add("One-Eyed Jack is peeking out of the crowd!");
	}

	private void initializePowerUp()
	{
		powerUpCommentary.Add("Player1", new Dictionary<string, string>());
		powerUpCommentary["Player1"].Add("ANicePhotoPickedUp", "Player 1 has picked up a nice photo.");
		powerUpCommentary["Player1"].Add("BusTicketPickedUp", "Player 1 is now ready to take a bus.");
		powerUpCommentary["Player1"].Add("ExtraSpeedPickedUp", "Unbelievable! Player 1 has obtained extra speed!");
		powerUpCommentary["Player1"].Add("ExtraSpeedx4PickedUp", "I think the race is over, ladies and gentlemen. Player 1 has quadruple extra speed!");
		powerUpCommentary["Player1"].Add("HeadphonesPickedUp", "Player 1 has found headphones on the track.");
		powerUpCommentary["Player1"].Add("HealthPickedUp", "A health power up has been picked up by Player 1.");

		powerUpCommentary.Add("Player2", new Dictionary<string, string>());
		powerUpCommentary["Player2"].Add("ANicePhotoPickedUp", "Player 2 can now slow down to enjoy the nice photo they picked up.");
		powerUpCommentary["Player2"].Add("BusTicketPickedUp", "A bus ticket has fallen into the hands of Player 2!");
		powerUpCommentary["Player2"].Add("ExtraSpeedPickedUp", "Beware! Player 2 has extra speed!");
		powerUpCommentary["Player2"].Add("ExtraSpeedx4PickedUp", "The only actually useful power-up has just been picked up by Player 2!");
		powerUpCommentary["Player2"].Add("HeadphonesPickedUp", "Player 2 has confessed earlier that his favourite band is Autechre.");
		powerUpCommentary["Player2"].Add("HealthPickedUp", "Player 2 is healthy now.");

		powerUpCommentary.Add("White House", new Dictionary<string, string>());
		powerUpCommentary["White House"].Add("ANicePhotoPickedUp", "White House has a nice photo and she has it bad.");
		powerUpCommentary["White House"].Add("BusTicketPickedUp", "White House ran into a bus ticket.");
		powerUpCommentary["White House"].Add("ExtraSpeedPickedUp", "4 words. White. House. Extra. Speed. Hell yea.");
		powerUpCommentary["White House"].Add("ExtraSpeedx4PickedUp", "White House should now move faster than the White House! She has a power-up!");
		powerUpCommentary["White House"].Add("HeadphonesPickedUp", "White House doesn't know what headphones are, I think.");
		powerUpCommentary["White House"].Add("HealthPickedUp", "White House has just healed her wounds from the trip from the Rockies to this event.");

		powerUpCommentary.Add("One-Eyed Jack", new Dictionary<string, string>());
		powerUpCommentary["One-Eyed Jack"].Add("ANicePhotoPickedUp", "One-Eyed Jack once told me that a nice photo is his favorite power-up.");
		powerUpCommentary["One-Eyed Jack"].Add("BusTicketPickedUp", "One-Eyed Jack has a bus ticket now.");
		powerUpCommentary["One-Eyed Jack"].Add("ExtraSpeedPickedUp", "One-Eyed Jack is gonna fly now!");
		powerUpCommentary["One-Eyed Jack"].Add("ExtraSpeedx4PickedUp", "Extra speed x4 and One-Eye Jack on it.");
		powerUpCommentary["One-Eyed Jack"].Add("HeadphonesPickedUp", "One-Eyed Jack has found headphones during the race.");
		powerUpCommentary["One-Eyed Jack"].Add("HealthPickedUp", "And health goes to One-Eyed Jack! Cheers!");
	}

	private void initializeFrenzy()
	{
		frenzyCommentary.Add("Player1", "Player1 is on fire!");
		frenzyCommentary.Add("Player2", "Player2 got an advantage!");
	}

	private void initializeStart()
	{
		startCommentary.Add("Ladies and gentlemen, the race has begun! It is recommended to keep hitting A and L like crazy!");
		startCommentary.Add("Welcome to the room, this is the 4th Snail Indoor World Championship. It higly recommended to use A and L throughout the whole race.");
		startCommentary.Add("What a start! Oh boy, I love snail races! Hit your A and L keys, folks.");
		startCommentary.Add("The situation isn't clear at all, many snails have started quickly at once. I think we should all start pressing A and L now.");
	}

	private void initializeRandomCommentary()
	{
		randomCommentary.Add("The weather is lovely and the race is fast. What a day!");
		randomCommentary.Add("Player 1 seems to have polished his house more thoroughly than usual today.");
		randomCommentary.Add("Here's a fun fact: An average snail is as big as a slightly bigger matchbox.");
		randomCommentary.Add("When I asked One-Eyed Jack before the race if he likes casinos, he answered: The owls are not what they seem.");
		randomCommentary.Add("I wanted to tell you about One-Eyed Jack's only eye but my editor said it would be inappropriate.");
		randomCommentary.Add("This is the first time the championship takes place in one room and next year it will be somewhere else again.");
		randomCommentary.Add("I have a fun fact for you: No snails have ever been fined for speeding in our state.");
		randomCommentary.Add("What a manoeuvre!");

		randomCommentary.Add("Did you know, that snails are actually smaller than they seem?");
		randomCommentary.Add("The current world snail leader has a salary over 3 million dollars per year.");
		randomCommentary.Add("There is an ongoing rumor that One-Eyed Jack has a snailfriend.");
		randomCommentary.Add("Fun fact: Snails, unlike tigers, are hermaphrodites.");
		randomCommentary.Add("I've heard it's a real tragedy for a snail to get wet in the rain.");
		randomCommentary.Add("In case you were wondering, my name is System.Speech.Synthesis.");
		randomCommentary.Add("I have a joke for you: Two snails are walking until they reach the forest.");
	}

	private void initializeLineToClipMapping()
	{
		lineToClipMapping.Add("Press ESC to quit", 0);

		lineToClipMapping.Add("Player 1 has dominated today!", 1);
		lineToClipMapping.Add("Player 1 is the fastest snail in the world!", 2);
		lineToClipMapping.Add("Ladies and gentlemen, we've just seen Player 2 rush through the finish line as the winner!", 3);
		lineToClipMapping.Add("Player 2 won so quickly we almost couldn't see it!", 4);
		lineToClipMapping.Add("A CPU snail has won this time! Her name is White House!", 5);
		lineToClipMapping.Add("White House's white house is the house of a winner!", 6);
		lineToClipMapping.Add("One-Eyed Jack has toyed with the spectators one more time! He's the winner!", 7);
		lineToClipMapping.Add("One-Eyed Jack! Never have I seen such an amazing win!", 8);
		
		lineToClipMapping.Add("Player 1 has gone in the lead!", 9);
		lineToClipMapping.Add("Player 1 is flying towards victory!", 10);
		lineToClipMapping.Add("We have a new leader, ladies and gentlemen! It's Player 2!", 11);
		lineToClipMapping.Add("Player 2 is in the lead!", 12);
		lineToClipMapping.Add("White House is rapidly escaping her opponents!", 13);
		lineToClipMapping.Add("White House is leading the race at the moment.", 14);
		lineToClipMapping.Add("One-Eyed Jack is the fastest snail on the track now!", 15);
		lineToClipMapping.Add("One-Eyed Jack is peeking out of the crowd!", 16);

		lineToClipMapping.Add("The weather is lovely and the race is fast. What a day!", 17);
		lineToClipMapping.Add("Player 1 seems to have polished his house more thoroughly than usual today.", 18);
		lineToClipMapping.Add("Here's a fun fact: An average snail is as big as a slightly bigger matchbox.", 19);
		lineToClipMapping.Add("When I asked One-Eyed Jack before the race if he likes casinos, he answered: The owls are not what they seem.", 20);
		lineToClipMapping.Add("I wanted to tell you about One-Eyed Jack's only eye but my editor said it would be inappropriate.", 21);
		lineToClipMapping.Add("This is the first time the championship takes place in one room and next year it will be somewhere else again.", 22);
		lineToClipMapping.Add("I have a fun fact for you: No snails have ever been fined for speeding in our state.", 23);
		lineToClipMapping.Add("What a manoeuvre!", 24);

		lineToClipMapping.Add("Ladies and gentlemen, the race has begun! It is recommended to keep hitting A and L like crazy!", 25);
		lineToClipMapping.Add("Welcome to the room, this is the 4th Snail Indoor World Championship. It higly recommended to use A and L throughout the whole race.", 26);
		lineToClipMapping.Add("What a start! Oh boy, I love snail races! Hit your A and L keys, folks.", 27);
		lineToClipMapping.Add("The situation isn't clear at all, many snails have started quickly at once. I think we should all start pressing A and L now.", 28);

		lineToClipMapping.Add("Player1 is on fire!", 29);
		lineToClipMapping.Add("Player2 got an advantage!", 30);

		lineToClipMapping.Add("Player 1 has picked up a nice photo.", 31);
		lineToClipMapping.Add("Player 1 is now ready to take a bus.", 32);
		lineToClipMapping.Add("Unbelievable! Player 1 has obtained extra speed!", 33);
		lineToClipMapping.Add("I think the race is over, ladies and gentlemen. Player 1 has quadruple extra speed!", 34);
		lineToClipMapping.Add("Player 1 has found headphones on the track.", 35);
		lineToClipMapping.Add("A health power up has been picked up by Player 1.", 36);

		lineToClipMapping.Add("Player 2 can now slow down to enjoy the nice photo they picked up.", 37);
		lineToClipMapping.Add("A bus ticket has fallen into the hands of Player 2!", 38);
		lineToClipMapping.Add("Beware! Player 2 has extra speed!", 39);
		lineToClipMapping.Add("The only actually useful power-up has just been picked up by Player 2!", 40);
		lineToClipMapping.Add("Player 2 has confessed earlier that his favourite band is Autechre.", 41);
		lineToClipMapping.Add("Player 2 is healthy now.", 42);

		lineToClipMapping.Add("White House has a nice photo and she has it bad.", 43);
		lineToClipMapping.Add("White House ran into a bus ticket.", 44);
		lineToClipMapping.Add("4 words. White. House. Extra. Speed. Hell yea.", 45);
		lineToClipMapping.Add("White House should now move faster than the White House! She has a power-up!", 46);
		lineToClipMapping.Add("White House doesn't know what headphones are, I think.", 47);
		lineToClipMapping.Add("White House has just healed her wounds from the trip from the Rockies to this event.", 48);

		lineToClipMapping.Add("One-Eyed Jack once told me that a nice photo is his favorite power-up.", 49);
		lineToClipMapping.Add("One-Eyed Jack has a bus ticket now.", 50);
		lineToClipMapping.Add("One-Eyed Jack is gonna fly now!", 51);
		lineToClipMapping.Add("Extra speed x4 and One-Eye Jack on it.", 52);
		lineToClipMapping.Add("One-Eyed Jack has found headphones during the race.", 53);
		lineToClipMapping.Add("And health goes to One-Eyed Jack! Cheers!", 54);

		lineToClipMapping.Add("Did you know, that snails are actually smaller than they seem?", 55);
		lineToClipMapping.Add("The current world snail leader has a salary over 3 million dollars per year.", 56);
		lineToClipMapping.Add("There is an ongoing rumor that One-Eyed Jack has a snailfriend.", 57);
		lineToClipMapping.Add("Fun fact: Snails, unlike tigers, are hermaphrodites.", 58);
		lineToClipMapping.Add("I've heard it's a real tragedy for a snail to get wet in the rain.", 59);
		lineToClipMapping.Add("In case you were wondering, my name is System.Speech.Synthesis.", 60);
		lineToClipMapping.Add("I have a joke for you: Two snails are walking until they reach the forest.", 61);
	}
}

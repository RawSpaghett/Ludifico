using Godot;
using System;

public static partial class EventBus
{
	//events
	// public static event Action<char> OnPlayerLetter;
	public static event Action<string, ulong> OnWordFinished;

	//methods
	/*
	public static void BroadcastPlayerLetter(char letter)
	{
		OnPlayerLetter?.Invoke(letter);
	}
	*/

	public static void BroadcastFinishedWord(string word, ulong timestamp)
	{
		OnWordFinished?.Invoke(word, timestamp);
	}
	
	 
}

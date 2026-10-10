using Godot;
using System;

public static partial class EventBus
{
	//events
	// public static event Action<char> OnPlayerLetter;
	public static event Action<ulong, string> OnWordFinished;

	//methods
	/*
	public static void BroadcastPlayerLetter(char letter)
	{
		OnPlayerLetter?.Invoke(letter);
	}
	*/

	public static void BroadcastFinishedWord(ulong timestamp, string word)
	{
		OnWordFinished?.Invoke(timestamp, word);
	}
	
	 
}

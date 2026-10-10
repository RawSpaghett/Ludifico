using Godot;
using System;

public static partial class EventBus
{
	//events
	// public static event Action<char> OnPlayerLetter;
	public static event Action<ulong, string, int> OnWordFinished;
	public static event Action<ulong> OnPlayerStart;
	public static event Action<string> OnWordGenerated;
	public static event Action OnPlayerMiss;

	//methods
	/*
	public static void BroadcastPlayerLetter(char letter)
	{
		OnPlayerLetter?.Invoke(letter);
	}
	*/

	public static void BroadcastFinishedWord(ulong timestamp, string word, int combo)
	{
		OnWordFinished?.Invoke(timestamp, word, combo);
	}

	public static void BroadcastPlayerStart(ulong timestamp)
	{
		OnPlayerStart?.Invoke(timestamp);
	}

	public static void BroadcastWordGenerated(string word)
	{
		OnWordGenerated?.Invoke(word);
	}
	
	public static void BroadcastPlayerMiss()
	{
		OnPlayerMiss?.Invoke();
	}
	 
}

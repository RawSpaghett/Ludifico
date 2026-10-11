using Godot;
using System;

public static partial class EventBus
{
	//events
	// public static event Action<char> OnPlayerLetter;
	public static event Action<ulong, string> OnWordFinished;
	public static event Action<int> OnWordFinishedCombo;
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

	public static void BroadcastFinishedWord(ulong timestamp, string word)
	{
		OnWordFinished?.Invoke(timestamp, word);
	}
	public static void BroadcastFinishedWordCombo(int combo)
	{
		OnWordFinishedCombo?.Invoke(combo);
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

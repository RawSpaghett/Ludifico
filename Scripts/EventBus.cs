using Godot;
using System;

public static partial class EventBus
{
	//events
	public static event Action<char> OnPlayerLetter;


	//methods
	public static void BroadcastPlayerLetter(char letter)
	{
		OnPlayerLetter?.Invoke(letter);
	}

}

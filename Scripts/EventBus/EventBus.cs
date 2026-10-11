using Godot;
using System;

public static partial class EventBus
{
	//events
	public static event Action<char> OnPlayerLetter;
	public static event Action<float> OnWPMChange;

	//methods
	public static void BroadcastPlayerLetter(char letter)
	{
		OnPlayerLetter?.Invoke(letter);
	}
	
	public static void BroadcastWPMChange (float  WPM)
	{
		OnWPMChange?.Invoke(WPM);
	}

}

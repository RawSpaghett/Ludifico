using Godot;
using System;

public partial class WPM : Node
{
	public float rawWPM { get; private set; }

	private float startTimeMinutes;

	
	
	//Needs number of characters and elapsed time
	
	public override void _EnterTree()
	{
		EventBus.OnWordFinished += RawWPM;
		EventBus.OnPlayerStart += StartTime;
		base._EnterTree();
	}

	public override void _ExitTree()
	{
		EventBus.OnWordFinished -= RawWPM;
		EventBus.OnPlayerStart -= StartTime;
		base._ExitTree();
	}

	/*
	public override void _Process(double delta)
	{
		RawWPM();
		base._Process(delta);
	}
	*/

	private void StartTime(Int64 timeStamp)
	{
		float timeInSeconds = (float)timeStamp / 1000f;
		startTimeMinutes = timeInSeconds / 60f;
	}
	
	private void ProcessBroadcast(Int64 time, string word)
	{
		float timeInSeconds = (float)time / 1000f;
		float timeInMinutes = timeInSeconds / 60f;
		float elapsed = timeInMinutes - startTimeMinutes;
		startTimeMinutes = timeInMinutes;
		RawWPM(word.Length,timeInMinutes);
	}
	
	private void RawWPM(int chars, float elapsedMin) //(Total chars / Five)/(time in mins)
	{
		rawWPM = (chars / 5f) / elapsedMin;
		EventBus.BroadcastWPMChange(rawWPM);
	}
	
	
	
	
}

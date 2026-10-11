using Godot;
using System;

public partial class WPM : Label
{
	public float rawWPM { get; private set; }
	public float netWPM { get; private set; }
	private int mistakes = 0;

	private float startTimeMinutes;
	
	//Needs number of characters and elapsed time
	public override void _EnterTree()
	{
		EventBus.OnWordFinished += ProcessBroadcast;
		EventBus.OnPlayerStart += StartTime;
		EventBus.OnPlayerMiss += HandleMiss;
		base._EnterTree();
	}

	public override void _ExitTree()
	{
		EventBus.OnWordFinished -= ProcessBroadcast;
		EventBus.OnPlayerStart -= StartTime;
		EventBus.OnPlayerMiss += HandleMiss;
		base._ExitTree();
	}

	private void HandleMiss()
	{
		mistakes++;
	}

	private void UpdateNumber()
	{
		this.Text.Remove(0);
		this.Text += netWPM;
	}
	/*
	public override void _Process(double delta)
	{
		RawWPM();
		base._Process(delta);
	}
	*/

	private void StartTime(ulong timeStamp)
	{
		float timeInSeconds = (float)timeStamp / 1000f;
		startTimeMinutes = timeInSeconds / 60f;
	}
	
	private void ProcessBroadcast(ulong time, string word)
	{
		float timeInSeconds = (float)time / 1000f;
		float timeInMinutes = timeInSeconds / 60f;
		float elapsed = timeInMinutes - startTimeMinutes;
		startTimeMinutes = timeInMinutes;
		RawWPM(word.Length,elapsed);
	}
	
	private void RawWPM(int chars, float elapsedMin) //(Total chars / Five)/(time in mins)
	{
		rawWPM = (chars / 5f) / elapsedMin;
		EventBus.BroadcastWPMChange(rawWPM);
	}
	
	private void NetWPM(int chars, float elapsedMin) // [(chars - mistakes) / 5] / (time in mins) 
	{
		netWPM = ( (chars - mistakes) / 5f ) / elapsedMin; 
	}
	
	
}

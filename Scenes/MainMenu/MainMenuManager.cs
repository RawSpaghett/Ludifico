using Godot;
using System;

public partial class MainMenuManager : Node
{
	public override void _Ready()
	{
		Button startButton = GetNode<Button>("%Start");
		Button optionsButton = GetNode<Button>("%Options");
		Button statsButton = GetNode<Button>("%Statistics");
		Button creditsButton = GetNode<Button>("%Credits");
		Button exitButton = GetNode<Button>("%Exit");
		
		startButton.Pressed += OnStartButton;
		optionsButton.Pressed += OnOptionsButton;
		statsButton.Pressed += OnStatsButton;
		creditsButton.Pressed += OnCreditsButton;
		exitButton.Pressed += OnExitButton;
	} 
		public void OnStartButton()
		{
			GetTree().ChangeSceneToFile("res://Scenes/GameScenes/Rounds/LevelBase.tscn");
			GD.Print("Start");
		}
		public void OnOptionsButton()
		{}
		public void OnStatsButton()
		{}
		public void OnCreditsButton()
		{}
		public void OnExitButton()
		{
			GD.Print("Exit");
			GetTree().Quit();
		}
		
		
	
	
	
}

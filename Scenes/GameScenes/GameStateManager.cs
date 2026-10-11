using Godot;
using System;

public partial class GameStateManager : Node
{
	private float difficultyMulti = 1f;
	private float passIndex = 0f;
	private string LevelName { get; set; }
	private float BaseTargetScore { get; set; } = 100;
	public float CurTargetScore;
	private float BaseTimeLimit { get; set; } = 60.0f;
	public float CurTimeLimit;
	private ScoreManager scoreManager;

	public override void _Ready()
	{
		CurTargetScore = BaseTargetScore;
		CurTimeLimit = BaseTimeLimit;
		LevelName = $"Pass {passIndex}";
		scoreManager = GetNode<ScoreManager>("/root/ScoreManager");
	}

	private void LevelStart() //created
	{
		//boot up level
	}

	private void LevelBegin() //actual player input
	{
		//start timer
	}

	private void LevelEnd()
	{
		if (scoreManager.total < CurTargetScore)
		{
			GetTree().Quit();
		}
		else
		{
			ScaleLevel();
		}
	}

	private void ScaleLevel()
	{
		difficultyMulti += 0.1f;
		passIndex++;
		LevelName = $"Pass {passIndex}";
		CurTargetScore = BaseTargetScore * difficultyMulti;
		CurTimeLimit = BaseTimeLimit / difficultyMulti;
	}
}

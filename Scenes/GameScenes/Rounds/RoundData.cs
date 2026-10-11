using Godot;

[GlobalClass]
public partial class RoundData : Resource
{
	[Export] public string LevelName { get; set; }
	[Export] public int TargetScore { get; set; } = 100;
	[Export] public float TimeLimit { get; set; } = 60.0f;
	
}

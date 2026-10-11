using System;
using Godot;

public partial class BaseCap : Cap
{
	[Export] public override string ItemName { get; set; } = "Base Cap";
	[Export] public override string CompanyName { get; set; } = "Vanilla Peripherals";
	[Export] public override string PressIcon { get; set; }
	[Export] public override string NormIcon { get; set; }

	public BaseCap(string keyLetter)
	{
		NormIcon = $"res://Assets/Sprites/NormKeys/keyboard_{keyLetter}_outline.png";
		PressIcon = $"res://Assets/Sprites/PressKeys/keyboard_{keyLetter}.png";
	}


}

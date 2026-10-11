using System;
using Godot;

public partial class BaseCap : Cap
{
	[Export] public override string ItemName { get; set; } = "Base Cap";
	[Export] public override string CompanyName { get; set; } = "Vanilla Peripherals";
	[Export] public override string PressIcon { get; set; } = null;
	[Export] public override string NormIcon { get; set; } = "res://Assets/Sprites/Troll.png";


}

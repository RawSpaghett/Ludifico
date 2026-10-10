using System;
using Godot;

public partial class BaseSwitch : Switch
{
	[Export] public override string ItemName { get; set; } = "Base Switch";
	[Export] public override string CompanyName { get; set; } = "Vanilla Peripherals";
	
	
}

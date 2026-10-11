using Godot;
using System;
[GlobalClass]
public abstract partial class Cap: Resource
{
	[Export] public virtual string ItemName { get; set; } = "";
	[Export] public virtual string CompanyName { get; set; } = "";
	[Export] public virtual float Multi { get; set; } = 0;
	[Export] public virtual float Score { get; set; } = 0;
	[Export] public virtual string PressIcon { get; set; }
	[Export] public virtual string NormIcon { get; set; }
	[Export] public int MaxStackSize { get; set; } = 1;
}

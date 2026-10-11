using Godot;
using System;

[GlobalClass]
public abstract partial class Switch: Resource
{
	[Export] public virtual string ItemName { get; set; } = "";
	[Export] public virtual string CompanyName { get; set; } = "";
	[Export] public virtual float Multi { get; set; } = 0;
	[Export] public virtual float Score { get; set; } = 0;
	[Export] public Texture2D Icon { get; set; }
	[Export] public int MaxStackSize { get; set; } = 1;
}

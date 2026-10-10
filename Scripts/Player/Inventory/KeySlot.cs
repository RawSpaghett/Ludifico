using Godot;
using System;

public partial class KeySlot: Resource
{
	public Switch KeySwitchSlot { get; set; }
	public Cap CapSlot {get; set; }
	public char Letter {get; private set; }
	
	public KeySlot(Switch keySwitch, Cap cap, char letter)
	{
		KeySwitchSlot = keySwitch;
		CapSlot = cap;
		Letter = letter;
	}
}

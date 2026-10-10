using Godot;
using System;

public partial class PlayerKeyboard: Resource
{
	private int keyboardSize = 26;
	private int artisanSize = 4;

	private char[] alphabet =
	{
		'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z'
	};
	
	[Export] public Godot.Collections.Array<KeySlot> Slots { get; set; } 
		= new Godot.Collections.Array<KeySlot>();
	
	private void IntiateFreshKeyboard()
	{
		Slots.Clear();
		foreach (char letter in alphabet)
		{
			Slots.Add(new KeySlot(new BaseSwitch(),new BaseCap(),letter));
		}
	}

	public KeySlot GetKey() //get keyslot values
	{
		return null;
	}

	public void ReplaceKey() // replace a keyslots switch or cap
	{
	}
}

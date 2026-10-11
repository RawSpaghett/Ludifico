using Godot;
using System;

[GlobalClass]
public partial class PlayerKeyboard: Resource
{
	private static PlayerKeyboard instance;
	private const string SavePath = "user://player_keyboard.tres";
	
	public static PlayerKeyboard Instance 
	{ 
		get 
		{
			if (instance == null)
			{
				if (ResourceLoader.Exists(SavePath))
				{
					instance = ResourceLoader.Load<PlayerKeyboard>(SavePath);
				}
				else
				{
					
					instance = new PlayerKeyboard();
					instance.IntiateFreshKeyboard();
				}
			}
			return instance;
		} 
	}
	
	private int artisanSize = 4;

	private char[] alphabet =
	{
		'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z'
	};
	
	[Export] public Godot.Collections.Array<KeySlot> Slots { get; set; } 
		= new Godot.Collections.Array<KeySlot>();
	
	[Export] public Godot.Collections.Array<Artisan> ArtisanArr { get; set; } 
		= new Godot.Collections.Array<Artisan>();

	public PlayerKeyboard()
	{
		IntiateFreshKeyboard();
	}
	
	private void IntiateFreshKeyboard()
	{
		Slots.Clear();
		foreach (char letter in alphabet)
		{
			Slots.Add(new KeySlot(new BaseSwitch(),new BaseCap(),letter));
		}
		
	}

	public KeySlot GetKey(char letterID) //get keyslot values
	{
		foreach (KeySlot slot in Slots)
		{
			if (slot.Letter == letterID) 
			{
				return slot;
			}
		}
		return null;
	}

	public void ReplaceKey() // replace a keyslots switch or cap
	{
	}

	public void AddArtisan(Artisan newArtisan)
	{
		if (ArtisanArr.Count <= 5)
		{
			ArtisanArr.Add(newArtisan);
		}
		else
		{
			
		}
	}
}

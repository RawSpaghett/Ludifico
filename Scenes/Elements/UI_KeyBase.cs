using Godot;
using System;

public partial class UI_KeyBase : TextureButton
{
	public override void _EnterTree()
	{
		EventBus.OnPlayerLetter += PressKey;
	}

	public override void _ExitTree()
	{
		EventBus.OnPlayerLetter -= PressKey;
	}

	private void PressKey(char key)
	{
		foreach (Node row in GetChildren())
		{
			if (row is HBoxContainer hbox)
			{
				foreach (Node child in hbox.GetChildren())
				{
					if (child is UI_KeyBase keyNode && child.Name == key.ToString())
					{
						
					}
				}
			}
	}
	

	public void SetupKey(char letter, KeySlot slotData)
	{
		this.Name = letter.ToString();
		//base texture
		this.TextureNormal = GD.Load<Texture2D>(slotData.CapSlot.NormIcon);
		//pressed texture
		//this.TexturePress = GD.Load<Texture2D>(slotData.CapSlot.PressIcon);
	}
}

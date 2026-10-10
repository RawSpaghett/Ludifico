using Godot;
using System;

public partial class UI_KeyBase : TextureButton
{
	//Key press down logic here
	
	public void SetupKey(char letter, KeySlot slotData)
	{
		this.Name = letter.ToString();
		//base texture
		this.TextureNormal = slotData.CapSlot.NormIcon;
		//pressed texture
		this.TextureNormal = slotData.CapSlot.PressIcon;
	}
}

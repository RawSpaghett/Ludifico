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

	private async void PressKey(char key)
	{
		if (key.ToString().ToLower() == this.Name)
		{
			this.EmitSignal(SignalName.Pressed);
			this.ButtonPressed = true;  //go down
			
			await ToSignal(GetTree().CreateTimer(0.1f), SceneTreeTimer.SignalName.Timeout); //wait
			
			this.ButtonPressed = false;  //popup
		}
	}
	

	public void SetupKey(char letter, KeySlot slotData)
	{
		this.Name = letter.ToString();
		//base texture
		this.TextureNormal = GD.Load<Texture2D>(slotData.CapSlot.NormIcon);
		//pressed texture
		this.TexturePressed = GD.Load<Texture2D>(slotData.CapSlot.PressIcon);
	}
}

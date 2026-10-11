using Godot;
using System;

public partial class InputLabel : Label
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		EventBus.OnPlayerLetter += UpdateLabel;
		// EventBus.OnPlayerMiss += SetCharColor;
		// EventBus.OnFreezeEnd += UpdateLabel;
		EventBus.OnWordFinished += ClearText;
	}

	private void UpdateLabel(char letter)
	{
		this.Text += letter;
	}

	private void ClearText(ulong _, string __)
	{
		this.Text = this.Text.Remove(0);
	}

	private void SetCharColor() {
		// this.Text[^1]
		// this.Set("theme_override_colors/font_color", Colors.Red);
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{

	}

	public override void _ExitTree()
	{
		EventBus.OnPlayerLetter -= UpdateLabel;
		// EventBus.OnPlayerMiss -= SetCharColor;
		// EventBus.OnFreezeEnd -= UpdateLabel;
		EventBus.OnWordFinished -= ClearText;
	}
}

using Godot;
using System;

public partial class InputManager : Node
{
	private string _typedText;

	public override void _Ready()
	{
		ProcessMode = ProcessModeEnum.Always;
	}

	public override void _Input(InputEvent @event)
	{
		// ignore non key inputs
		if (@event is not InputEventKey keyEvent) return;
		// ignore release and echoes	
		if (!keyEvent.Pressed || keyEvent.Echo) return; 

		if (keyEvent.Unicode != 0) 
		{
			HandleChar((char)keyEvent.Unicode);
		}
		else 
		{
			HandleSpecials(keyEvent.Keycode);
		}
		
	}
	
	private void HandleChar(char character)
	{
		// do some handling
		_typedText += character;

		EventBus.BroadcastPlayerLetter(character);
		GD.Print(character);	
	}
	
	private void HandleSpecials(Key key)
	{
		switch(key)
		{
			case Key.Backspace:
				if (_typedText.Length > 0) 
				{
					_typedText = _typedText[..^1]; // range operator + ^1 = everything except last character
				}
				break;
			case Key.Escape:
				break;
			case Key.Tab:
				break;
		}
	}
}

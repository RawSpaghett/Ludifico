using Godot;
using System;
using System.Text;

public partial class KeyLogger : Node
{
	private StringBuilder _currentWord = new();
	
	// subscribe
	public override void _EnterTree()
	{
		GD.Print("Entered Tree!!!!");
		EventBus.OnPlayerLetter += HandlePlayerletter;
	}

	private void HandlePlayerletter(char letter)
	{
		if (Char.IsWhiteSpace(letter))
		{
			GD.Print("Hello from handleplayerletter");
			FinishWord();
			return;
		}

		_currentWord.Append(letter);
		GD.Print("Hello from handleplayerletter, appending letter to sb");
	}

	// hypothetically runs @ whitespace
	private void FinishWord()
	{
		if(_currentWord.Length == 0) return;
		
		string word = _currentWord.ToString();
		ulong time = Time.GetTicksMsec();

		EventBus.BroadcastFinishedWord(time,word);
		
		GD.Print($"Broadcasting finished word: {word}");
		_currentWord.Clear();
	}
	
	// unsubscribe @ scene end
	public override void _ExitTree()
	{
		EventBus.OnPlayerLetter -= HandlePlayerletter;
	}

}

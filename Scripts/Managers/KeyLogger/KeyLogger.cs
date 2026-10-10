using Godot;
using System;
using System.Text;
using System.Collections.Generic;

public partial class KeyLogger : Node
{
	private StringBuilder _currentWord = new();
	private List<string> _targetString = new();
	private int _userCombo = 0;
	
	// subscribe
	public override void _EnterTree()
	{
		EventBus.OnPlayerLetter += HandlePlayerletter;
		EventBus.OnWordGenerated += AddToTarget;
	}

	private void HandlePlayerletter(char letter)
	{
		int count = 0;

		if (count == 0) {
			EventBus.BroadcastPlayerStart(Time.GetTicksMsec());
		}

		if (Char.IsWhiteSpace(letter))
		{
			FinishWord();
			return;
		}

		// if (/* compare to target */)
		// 		increment combo

		_currentWord.Append(letter);
		count++;
	}

	private void AddToTarget(string word)
	{

	}

	// hypothetically runs @ whitespace
	private void FinishWord()
	{
		if(_currentWord.Length == 0) return;
		
		string word = _currentWord.ToString();

		EventBus.BroadcastFinishedWord(Time.GetTicksMsec(),word);
		
		_currentWord.Clear();
	}
	
	// unsubscribe @ scene end
	public override void _ExitTree()
	{
		EventBus.OnPlayerLetter -= HandlePlayerletter;
		EventBus.OnWordGenerated -= AddToTarget;
	}

}

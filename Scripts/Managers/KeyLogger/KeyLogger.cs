using Godot;
using System;
using System.Text;
using System.Collections.Generic;

public partial class KeyLogger : Node
{
	private StringBuilder _currentUserWord = new(); 
	private List<string> _targetStrings = new();
	private int userCombo = 0;
	private int count = 0; // global count of characters input from user
	private int targetWordIdx = 0;

	
	// subscribe
	public override void _EnterTree()
	{
		EventBus.OnPlayerLetter += HandlePlayerletter;
		EventBus.OnWordGenerated += AddToTarget;
	}

	private void HandlePlayerletter(char letter)
	{		
		// make sure word exists
		if (targetWordIdx >= _targetStrings.Count) return;

		string target = _targetStrings[targetWordIdx];

		// Player starts typing
		if (count == 0) EventBus.BroadcastPlayerStart(Time.GetTicksMsec());

		// only allow user to finish word when all chars have been typed
		if (Char.IsWhiteSpace(letter))
		{
			if(_currentUserWord.Length == target.Length)
			{
				FinishWord();	
			} 
			else if (_currentUserWord.Length > 0)
			{
				userCombo = 0;
				EventBus.BroadcastPlayerMiss();
			} 
			return;	
		}

		if (_currentUserWord.Length >= target.Length) 
		{
			userCombo = 0;
			EventBus.BroadcastPlayerMiss();
			return;
		}

		char expected = target[_currentUserWord.Length];

		if (letter == expected)
		{
			_currentUserWord.Append(letter);
			userCombo++;
		}
		else 
		{
			userCombo = 0;
			EventBus.BroadcastPlayerMiss();
		}

		count++;
	}

	private void AddToTarget(string word)
	{
		_targetStrings.Add(word);
	}

	private void FinishWord()
	{
		if(_currentUserWord.Length == 0) return;
		
		string word = _currentUserWord.ToString();
		ulong timestamp = Time.GetTicksMsec();

		EventBus.BroadcastFinishedWord(timestamp ,word, userCombo);
		
		_currentUserWord.Clear();
		targetWordIdx++;
	}
	
	// unsubscribe @ scene end
	public override void _ExitTree()
	{
		EventBus.OnPlayerLetter -= HandlePlayerletter;
		EventBus.OnWordGenerated -= AddToTarget;
	}
}

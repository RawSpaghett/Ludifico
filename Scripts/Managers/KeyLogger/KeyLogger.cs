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
	private int curWordLen = 0; // length of target string
	private int curUserLetterIdx = 0;
	private int targetWordIdx = 0;

	
	// subscribe
	public override void _EnterTree()
	{
		EventBus.OnPlayerLetter += HandlePlayerletter;
		EventBus.OnWordGenerated += AddToTarget;
	}

	private void HandlePlayerletter(char letter)
	{		
		if (count == 0) EventBus.BroadcastPlayerStart(Time.GetTicksMsec());
		if (curWordLen == 0) curWordLen = _targetStrings[targetWordIdx].Length;

		// only allow user to finish word when all chars have been typed
		if (Char.IsWhiteSpace(letter) && curUserLetterIdx == curWordLen)
		{
			FinishWord();
			return;
		}

		// if letter matches 
		if (letter == _targetStrings[targetWordIdx][curUserLetterIdx]) {
			userCombo++;
			_currentUserWord.Append(letter);
		} else {
			userCombo = 0;
			EventBus.BroadcastPlayerMiss();
			// broadcast failure
		}

		
		count++;
	}

	private void AddToTarget(string word)
	{
		_targetStrings.Add(word);
	}

	// hypothetically runs @ whitespace
	private void FinishWord()
	{
		if(_currentUserWord.Length == 0) return;
		
		string word = _currentUserWord.ToString();

		EventBus.BroadcastFinishedWord(Time.GetTicksMsec(),word, userCombo);
		
		_currentUserWord.Clear();
	}
	
	// unsubscribe @ scene end
	public override void _ExitTree()
	{
		EventBus.OnPlayerLetter -= HandlePlayerletter;
		EventBus.OnWordGenerated -= AddToTarget;
	}

}

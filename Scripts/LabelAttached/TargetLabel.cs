using Godot;
using System;
using System.Collections.Generic;

public partial class TargetLabel : Label
{
	IWordGenerator _wordGen = new WordGenerator();
	List<String> _words = new();
	private const int visibleWordCount = 5;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		this.HorizontalAlignment = HorizontalAlignment.Center;

		// generate and render first n words
		_words.AddRange(_wordGen.GenerateWords(visibleWordCount));
		RefreshText();

		EventBus.OnWordFinished += UpdateTargetText;
	}

	private void UpdateTargetText(ulong _, string __) 
	{
		if (_words.Count == 0)
			return;

		// Remove the first target word.
		_words.RemoveAt(0);

		// Append a new word at the end.
		_words.Add(_wordGen.GenerateWord());
 
		// Update the displayed text.
		RefreshText();
	}

	private void RefreshText()
	{
		Text = string.Join(" ", _words);
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	public override void _ExitTree()
	{
		EventBus.OnWordFinished -= UpdateTargetText;
	}
}

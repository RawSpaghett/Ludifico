using Godot;
using System;
using System.Collections.Generic;

public partial class TargetLabel : Label
{
	IWordGenerator wordGen = new WordGenerator();
	List<String> words;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		EventBus.OnWordFinished += UpdateTargetText;

		this.HorizontalAlignment = HorizontalAlignment.Center;

		// generate and render first n words
		int n = 5;
		List<String> words = wordGen.GenerateWords(n);

		for (int i = 0; i < n; i++) {
			this.Text += words[i] + " ";
		}

	}

	private void UpdateTargetText(ulong _, string __) 
	{
		string newString = wordGen.GenerateWord(); 
		this.Text.Remove(0 ,words[0].Length + 1);
		this.Text += newString;
		words.Add(newString);
		words.RemoveAt(0);
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

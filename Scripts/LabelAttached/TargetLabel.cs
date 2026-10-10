using Godot;
using System;
using System.Collections.Generic;

public partial class TargetLabel : Label
{
	IWordGenerator wordGen = new WordGenerator();

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		this.HorizontalAlignment = HorizontalAlignment.Center;

		int n = 5;
		List<String> words = wordGen.GenerateWords(n);

		for (int i = 0; i < n; i++) {
			this.Text += words[i] + " ";
		}

	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}

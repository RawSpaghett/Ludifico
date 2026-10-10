using Godot;
using System;
using System.Collections.Generic;

public partial class WordGenTest : Label
{
	IWordGenerator wordGen = new WordGenerator();

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		var random = new RandomNumberGenerator();
		random.Seed = 69;

		List<String> words = wordGen.GenerateWords(100);
		for(int i = 0; i < 10; i++) {
			for (int j = 0; j < 10; j++) {
				this.Text += words[(i * 10 )+ j] + " ";		
			}
			this.Text += '\n';
		}
		
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}

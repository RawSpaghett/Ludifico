using Godot;
using System;

public partial class ScoreManager : Node
{
	
	
	//Boss -> Cap -> Switch -> Artisan -> ScoreXMulti
	public float total { get; private set; }

	public override void _EnterTree()
	{
		//on word completed
		base._EnterTree();
	}

	public override void _ExitTree()
	{
		base._ExitTree();
	}

	private void CrunchScore(string word) //Boss -> Cap -> Switch -> Artisan -> ScoreXMulti
	{
		char[] letters = word.ToCharArray();
		float totalScore = 0;
		float totalMulti = 0;
		float output = 0;
		
		foreach (char letter in letters)
		{
			KeySlot slot = PlayerKeyboard.Instance.GetKey(letter);
			Cap cap = slot.CapSlot;
			Switch keySwitch = slot.KeySwitchSlot;
			totalScore += (cap.Score + keySwitch.Score);
			totalMulti += (cap.Multi + keySwitch.Multi);
		}

		foreach (Artisan artisanCap in PlayerKeyboard.Instance.ArtisanArr)
		{
			totalScore += artisanCap.Score;
			totalMulti += artisanCap.Multi;
		}

		output = totalScore * totalMulti;

		total += output;
	}




}

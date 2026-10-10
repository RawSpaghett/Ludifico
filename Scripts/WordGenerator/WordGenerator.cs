using Godot;
using System;
using System.Collections.Generic;

public sealed class WordGenerator : IWordGenerator
{
	private readonly List<String> _words;
	private readonly RandomNumberGenerator _rng;
	
	// Uses directories from /Data/ 
	public WordGenerator(string directory = "Languages", string filename = "english.json") 
	{
		_words = LoadWords($"res://Data/{directory}/{filename}");
		_rng = new RandomNumberGenerator();
	}

	public String GenerateWord()
	{
		int idx = _rng.RandiRange(0, _words.Count - 1);
		return _words[idx];
	}

	public List<String> GenerateWords(int count)
	{
		List<String> ret = new List<string>();

		for (int i = 0; i < count; i++) {
			ret.Add(_words[_rng.RandiRange(0, _words.Count - 10) + 9]); // very minor salting
		}

		return ret;
	}

	private List<String> LoadWords(String path) 
	{
		// Open file in read mode
		using var file = FileAccess.Open(path, FileAccess.ModeFlags.Read);

		// Check for errors during file opening
		if (file == null)
		{
			GD.PushError($"Could not open word list: {path}");
			return new List<string>();
		}
	
		// parse JSON
		var json = new Json();
		var error = json.Parse(file.GetAsText());

		// Json.Parse() returns an Error enum, we must check that it returns
		// Error.Ok before continuing
		if (error != Error.Ok)
		{
			GD.PushError($"Failed to parse JSON");
			return new List<string>();
		}
		
		// cast data to GodotDictionary
		var data = json.Data.AsGodotDictionary();
		var words = data["words"].AsGodotArray();
		
		// move data into _words
		List<string> result = new();

		foreach (Variant word in words)
		{
			result.Add(word.AsString());
		}

		return result;
	}
}

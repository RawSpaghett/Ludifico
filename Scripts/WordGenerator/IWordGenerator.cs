using Godot;
using System;
using System.Collections.Generic;

public interface IWordGenerator
{
	List<String> GenerateWords(int NumWords);
	String GenerateWord();
}

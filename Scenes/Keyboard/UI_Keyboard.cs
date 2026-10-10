using Godot;
using System;

public partial class KeyboardUI : Control // or VBoxContainer based on your root node
{
    // Standard QWERTY layout to match your 3 visual rows
    private char[] qwertyLayout = {
        'q', 'w', 'e', 'r', 't', 'y', 'u', 'i', 'o', 'p',
        'a', 's', 'd', 'f', 'g', 'h', 'j', 'k', 'l',
        'z', 'x', 'c', 'v', 'b', 'n', 'm'
    };

    public override void _Ready()
    {
        UpdateKeyboardUI();
    }

    public void UpdateKeyboardUI()
    {
        int letterIndex = 0;
        
        foreach (Node row in GetChildren())
        {
            if (row is HBoxContainer hbox)
            {
                foreach (Node child in hbox.GetChildren())
                {
                    if (child is UI_KeyBase keyNode && letterIndex < qwertyLayout.Length)
                    {
                        char targetLetter = qwertyLayout[letterIndex];
                        KeySlot slotData = PlayerKeyboard.Instance.GetKey(targetLetter);
                        keyNode.SetupKey(targetLetter, slotData);
                        letterIndex++;
                    }
                }
            }
        }
    }
}
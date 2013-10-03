using UnityEngine;
using System.Collections;

/// <summary>
/// Input reciever, this class to attached to the GUIText Object in Unity.
/// Access the function during runtime on the GUIText on the screen with adjusted position.
/// </summary>
public class InputReciever : MonoBehaviour {
	
	string outputValue;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		foreach(char c in Input.inputString) {
			// Backspace - Remove the last character
			if (c == "\b"[0]) {
				if (guiText.text.Length != 0)
					guiText.text = guiText.text.Substring(0, guiText.text.Length - 1);
			}
			// End of entry
			else if (c == "\n"[0] || c == "\r"[0]) {// "\n" for Mac, "\r" for windows.
				outputValue = HeroesDataBase.SearchName(guiText.text);
				guiText.text = outputValue;
				print("User entered his name: " + outputValue);
			}
			// Normal text input - just append to the end
			else {
				guiText.text += c;
			}
		}
	}
}

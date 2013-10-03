using UnityEngine;
using System.Collections;

public class InputReciever : MonoBehaviour {
	
	private uint[,] array2D = new uint[5, 8];
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
				
				//HERE : THE output value by calculating user's input
				outputValue = Coordinate2D.CoordinateToIndex(guiText.text, (uint)(array2D.Length / 5)).ToString();
				//display out in the same input guitext
				guiText.text = outputValue;
				print ("User entered his name: " + outputValue);
			}
			// Normal text input - just append to the end
			else {
				guiText.text += c;
			}
		}
	}
}

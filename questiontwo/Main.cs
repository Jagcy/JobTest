using UnityEngine;
using System.Collections;

public class Main : MonoBehaviour {
	
	private uint[,] array2D = new uint[5, 8];
	
	string inputValue = "";
	string outputValue = "";
	
	// Use this for initialization
	void Start () {
		//the main outvalur from the input
		outputValue = Coordinate2D.CoordinateToIndex(inputValue, (uint)(array2D.Length / 5)).ToString();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
}

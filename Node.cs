using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class Node : MonoBehaviour
{
	//connecting nodes
	public Dictionary<Node, float> linkNodes = new Dictionary<Node, float>();
	//color
	//0 - white, 1 - gray, 2 - black
	public uint color;
	//predecessor which is previous node
	public Node predecessor = null;
	//distance that are being travelled
	public float distance = 0f;
	//name for display
	public string nm;
	
	// Use this for initialization
	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}
	
	/// <summary>
	/// Adds connecting node.
	/// </summary>
	/// <param name='pNode'>
	/// node.
	/// </param>
	/// <param name='pDist'>
	/// distance.
	/// </param>
	public void AddNode(Node pNode, float pDist)
	{
		//push the node to the Dictionary
		linkNodes.Add(pNode, pDist);
	}

}
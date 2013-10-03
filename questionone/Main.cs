using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/*	Question 1:
 *	This system is to find the shortest path from point A to point B which has several different possible paths
 *	Author:	Goh Chee Yang
 */

public class Main : MonoBehaviour {
	
	//for shortest path
	private Node A;
	private Node B;
	private Node C;
	private Node D;
	private Node E;
	private Node F;
	private Node G;
	private Node H;
	
	//for longest path
	private Node AL;
	private Node BL;
	private Node CL;
	private Node DL;
	private Node EL;
	private Node FL;
	private Node GLz;
	private Node HL;
	
	// Use this for initialization
	void Start () {
		
		//intiatiate all the nodes
		A = gameObject.AddComponent<Node>();A.nm = "A";
		B = gameObject.AddComponent<Node>();B.nm = "B";
		C = gameObject.AddComponent<Node>();C.nm = "C";
		D = gameObject.AddComponent<Node>();D.nm = "D";
		E = gameObject.AddComponent<Node>();E.nm = "E";
		F = gameObject.AddComponent<Node>();F.nm = "F";
		G = gameObject.AddComponent<Node>();G.nm = "G";
		H = gameObject.AddComponent<Node>();H.nm = "H";
		
		AL = gameObject.AddComponent<Node>();AL.nm = "A";
		BL = gameObject.AddComponent<Node>();BL.nm = "B";
		CL = gameObject.AddComponent<Node>();CL.nm = "C";
		DL = gameObject.AddComponent<Node>();DL.nm = "D";
		EL = gameObject.AddComponent<Node>();EL.nm = "E";
		FL = gameObject.AddComponent<Node>();FL.nm = "F";
		GLz = gameObject.AddComponent<Node>();GLz.nm = "G";
		HL = gameObject.AddComponent<Node>();HL.nm = "H";
		
		//connecting all the nodes
		A.AddNode(C, 5.0f);
		A.AddNode(D, 9.0f);
		B.AddNode(D, 7.0f);
		B.AddNode(F, 5.0f);
		C.AddNode(A, 5.0f);
		C.AddNode(D, 4.0f);
		C.AddNode(E, 3.0f);
		C.AddNode(G, 5.5f);
		C.AddNode(H, 6.0f);
		D.AddNode(A, 9.0f);
		D.AddNode(B, 7.0f);
		D.AddNode(C, 4.0f);
		E.AddNode(C, 3.0f);
		E.AddNode(F, 0.8f);
		F.AddNode(B, 5.0f);
		F.AddNode(E, 0.8f);
		F.AddNode(G, 4.0f);
		G.AddNode(C, 5.5f);
		G.AddNode(F, 4.0f);
		G.AddNode(H, 2.0f);
		H.AddNode(C, 6.0f);
		H.AddNode(G, 2.0f);
		
		AL.AddNode(CL, 5.0f);
		AL.AddNode(DL, 9.0f);
		BL.AddNode(DL, 7.0f);
		BL.AddNode(FL, 5.0f);
		CL.AddNode(AL, 5.0f);
		CL.AddNode(DL, 4.0f);
		CL.AddNode(EL, 3.0f);
		CL.AddNode(GLz, 5.5f);
		CL.AddNode(HL, 6.0f);
		DL.AddNode(AL, 9.0f);
		DL.AddNode(BL, 7.0f);
		DL.AddNode(CL, 4.0f);
		EL.AddNode(CL, 3.0f);
		EL.AddNode(FL, 0.8f);
		FL.AddNode(BL, 5.0f);
		FL.AddNode(EL, 0.8f);
		FL.AddNode(GLz, 4.0f);
		GLz.AddNode(CL, 5.5f);
		GLz.AddNode(FL, 4.0f);
		GLz.AddNode(HL, 2.0f);
		HL.AddNode(CL, 6.0f);
		HL.AddNode(GLz, 2.0f);
		
		//displaying on console
		Debug.Log("shortest:");
		List<Node> shortestPath = DijkstraSearch(A, B);
		Debug.Log("longest:");
		List<Node> longestPath = DijkstraSearch(AL, BL, false);
		int i = shortestPath.Count;
		int j = longestPath.Count;
		
		//display the path on the MainGUIText Object in Unity
		GUIText mainGuiText = GameObject.Find("MainGUIText").GetComponent<GUIText>();
		mainGuiText.text = "shortest path:";
		while(i-- > 0)
		{
			mainGuiText.text += shortestPath[i].nm;
		}
		
		mainGuiText.text += "\nlongest path:";
		
		while(j-- > 0)
		{
			mainGuiText.text += longestPath[j].nm;
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	/// <summary>
	/// Dijksta Search Method
	/// </summary>
	/// <returns>
	/// a list of nodes as in decending form
	/// </returns>
	/// <param name='pNode1'>
	/// start node
	/// </param>
	/// <param name='pNode2'>
	/// end node
	/// </param>
	/// <param name='shortest'>
	/// to find the shortest trigger
	/// </param>
	private List<Node> DijkstraSearch(Node pNode1, Node pNode2, bool shortest = true)
	{
		//initiate the start node into the queue
		Dictionary<Node, float> queue = new Dictionary<Node, float> {{pNode1, 0}};
		
		//create an array for index access purpose, always access the first position of node
		Node[] edgeNode = new Node[queue.Count];
		queue.Keys.CopyTo(edgeNode, 0);
		
		//while there are things in the queue, then check it
		while(queue.Count > 0)
		{
			//loop all the connecting nodes in the checking node
			foreach(KeyValuePair<Node, float> kv in edgeNode[0].linkNodes)
			{
				//if the color is empty, then set the predecessor, distance, and color
				if(kv.Key.color == 0)
				{
					kv.Key.predecessor = edgeNode[0];
					kv.Key.distance = edgeNode[0].distance + kv.Value;
					kv.Key.color = 1;
				}//if the node is accessed once, replace the existing value
				else if(kv.Key.color == 1)
				{
					if((shortest && edgeNode[0].distance + kv.Value < kv.Key.distance) || (!shortest && edgeNode[0].distance + kv.Value > kv.Key.distance))
					{
						kv.Key.predecessor = edgeNode[0];
						kv.Key.distance = edgeNode[0].distance + kv.Value;
						kv.Key.color = 1;
					}
				}
				
				//if the color is not 2, push it into queue
				if(kv.Key.color != 2 && kv.Key != pNode2 && !queue.ContainsKey(kv.Key))
				{
					queue.Add(kv.Key, kv.Value);
				}
			}
			edgeNode[0].color = 2;
			
			//remove checked node
			queue.Remove(edgeNode[0]);
			
			//remain for nodes and distances
			Node[] remain = new Node[queue.Count];
			float[] remainDist = new float[queue.Count];
			//copy all values to the remains
			queue.Keys.CopyTo(remain, 0);
			queue.Values.CopyTo(remainDist, 0);
			queue.Clear();
			
			//because dictionary still got space in the position and not able to sort, so it must be force to clear everything and reassign the values
			for(int j = 0; j < remain.Length; ++j)
				queue.Add(remain[j], remainDist[j]);
			
			//redo the same as the declaration
			edgeNode = null;
			edgeNode = new Node[queue.Count];
			queue.Keys.CopyTo(edgeNode, 0);
		}
		
		//if end node has predecessor, show the path in console and return the List<Node> path.
		if(pNode2.predecessor != null)
		{
			Debug.Log("found");
			Node node = pNode2;
			List<Node> path = new List<Node>();
			while(node != null)
			{
				Debug.Log(node.nm);
				path.Add(node);
				node = node.predecessor;
			}
			return path;
		}
		else
			Debug.Log("not found");
		
		return null;
	}
	
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeSelector : MonoBehaviour {

    public Vector2 startPosition;
    public Vector2 endPosition;
    List<Vector2> nodes;

	// Use this for initialization
	void Start () {
        nodes = NodeFiller(startPosition, endPosition); //Runs NodeFiller method using the first and last position. -Tobias
	}
	
	// Update is called once per frame
	void Update () {
        for (int i = 0; i < nodes.Count; i++)
        {
            Debug.Log(nodes[i]); //Gives the console each position in the list for debugging purposes. -Tobias
        }
	}

    List<Vector2> NodeFiller(Vector2 startNode, Vector2 endNode) //Method for finding each position between the first and last position. -Tobias
    {
        List<Vector2> nodes = new List<Vector2>(); //Creates variable list that will be returned later. -Tobias

        /*
         *  The next part checks if the end node is either left or right of the start node.
         *  It will then run a function for every x between the start node (inclusive) and ende node (inclusive).
         *  This list of vector2s will be added to the nodes list.
         */ 
        if (endNode.x >= startNode.x)
        {
            for (int x = (int)startNode.x; x <= endNode.x; x++)
            {
                nodes.AddRange(AddNode(endNode, startNode, x));
            }
        }
        else
        {
            for (int x = (int)endNode.x; x <= startNode.x; x++)
            {
                nodes.AddRange(AddNode(endNode, startNode, x));
            }
        }
        return nodes; //Returns the list of all the positions. -Tobias
    }

    /* Function that checks if the start position is above or below the end position.
     * It then adds the positions between the end and start to a list.
     * Lastly it returns aforementioned list.
     */

    List<Vector2> AddNode(Vector2 biggestNode, Vector2 smallestNode, int x)
    {
        
        List<Vector2> newNode = new List<Vector2>();
        
            if (biggestNode.y >= smallestNode.y)
            {
                for (int y = (int)smallestNode.y; y <= biggestNode.y; y++)
                {
                    newNode.Add( new Vector2(x, y));
                }
            }
            else
            {
                for (int y = (int)biggestNode.y; y <= smallestNode.y; y++)
                {
                    newNode.Add(new Vector2(x, y));
                }
            }
        return newNode;
    }
}

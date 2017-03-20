using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeSelector : MonoBehaviour {
    public Vector2 startPosition; //First position that is inputed. -Tobias
    public Vector2 endPosition; //Last postition that is inputed. -Tobias
    List<Vector2> nodes; //variable for the list of positions that are between the first and last position. -Tobias

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
        if (endNode.x >= startNode.x) //If the end position is right of the start position. -Tobias
        {
            for (int x = (int)startNode.x; x <= endNode.x; x++) //For every x position when x is less than or equal to the last positions x value. -Tobias
            {
                if (endNode.y >= startNode.y) //If the end position is above the start position. -Tobias
                {
                    for (int y = (int)startNode.y; y <= endNode.y; y++) //For every y position when y is less than or equal to the last positions y value. -Tobias
                    {
                        nodes.Add(new Vector2(x, y)); //Adds the current position to the list. -Tobias
                    }
                }
                else //If the end position is below the start position. -Tobias
                {
                    for (int y = (int)endNode.y; y <= startNode.y; y++) //For every y position when y is more than or equal to the start positions y value. -Tobias
                    {
                        nodes.Add(new Vector2(x, y));//Adds the current position to the list. -Tobias
                    }
                }
            }
        }
        else //If the end position is left of the start position. -Tobias
        {
            for (int x = (int)endNode.x; x <= startNode.x; x++) //For every x position when x is less than or equal to the last positions x value. -Tobias
            {
                if (endNode.y >= startNode.y) //If the end position is above the start position. -Tobias
                {
                    for (int y = (int)startNode.y; y <= endNode.y; y++) //For every y position when y is less than or equal to the last positions y value. -Tobias
                    {
                        nodes.Add(new Vector2(x, y)); //Adds the current position to the list. -Tobias
                    }
                }
                else //If the end position is below the start position. -Tobias
                {
                    for (int y = (int)endNode.y; y <= startNode.y; y++) //For every y position when y is more than or equal to the start positions y value. -Tobias
                    {
                        nodes.Add(new Vector2(x, y)); //Adds the current position to the list. -Tobias
                    }
                }
            }
        }
        return nodes; //Returns the list of all the positions. -Tobias
    }
}

using UnityEngine;
using System.Collections;

using ALK_PathFinder; // Namespace of the PathMap;

public class ExamplePlayerInMap : MonoBehaviour
{
    // Using the path:
    protected PathMap path; // The map;
    protected PositionNode myNode; // My current node;

    public float targetX, targetY;

    // Finds the closest node to the given X and Y:
    public PositionNode FindMyNodeInAllNodes (float X, float Y)
    {
        return myNode;

        Debug.Log(myNode);
    }

    // Returns the closest node from targetX and targetY in the currentNode's children:
    public PositionNode FindClosestNode (float targetX, float targetY, PositionNode currentNode)
    {
        return myNode;

        Debug.Log(myNode);
    }

    public void Start()
    {
        // Instanciate the PathMap object:
        this.path = new PathMap();
        // Load map:
        this.path.LoadMap(@"myPathMap");
        // Acha meu nodo;
        this.myNode = this.path.FindMyNodeInAllNodes(transform.position.x, transform.position.y);

        Debug.Log("Bob löysi kartan");
        Debug.Log(myNode);
    }

    void Update()
    {
        PositionNode node = this.path.FindClosestNode(targetX, targetY, myNode); // Find the closest node of the position (x, y) from the children of myNode;
    }
}

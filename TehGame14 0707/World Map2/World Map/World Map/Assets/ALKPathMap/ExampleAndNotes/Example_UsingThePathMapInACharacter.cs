using UnityEngine;
using System.Collections;

using ALK_PathFinder; // Namespace of the PathMap;

public class UsingThePathMapInACharacter : MonoBehaviour
{
    // Using the path:
    protected PathMap path; // The map;
    protected PositionNode myNode; // My current node;

    public float targetX, targetY;

    public void Start()
    {
        // Instanciate the PathMap object:
        this.path = new PathMap();
        // Load map:
        this.path.LoadMap(@"myPathMap");
        // Acha meu nodo;
        this.myNode = this.path.FindMyNodeInAllNodes(transform.position.x, transform.position.y);
    }

    void Update()
    {
        PositionNode node = this.path.FindClosestNode(targetX, targetY, myNode); // Find the closest node of the position (x, y) from the children of myNode;
    }
}

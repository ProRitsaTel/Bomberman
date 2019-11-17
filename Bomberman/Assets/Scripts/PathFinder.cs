using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PathFinder : MonoBehaviour
{
	public List<Vector2> PathToTarget;
	public List<Node> CheckedNodes = new List<Node>();
	public List<Node> FreeNodes = new List<Node>();
	public	List<Node> WaitingNodes = new List<Node>();
	public GameObject Target;
	public LayerMask SolidLayer;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        //PathToTarget = GetPath(Target.transform.position);
    }
    public List<Vector2> GetPath(Vector2 target)
    {
    	PathToTarget = new List<Vector2>();
        CheckedNodes = new List<Node>();
		WaitingNodes = new List<Node>();

		Vector2 StartPosition = new Vector2(Mathf.Round(transform.position.x),Mathf.Round(transform.position.y));
		Vector2 TargerPosition = new Vector2(Mathf.Round(target.x),Mathf.Round(target.y));

		if(StartPosition == TargerPosition) return PathToTarget;

		Node startNode = new Node(0,StartPosition,TargerPosition, null);
		CheckedNodes.Add(startNode);
		WaitingNodes.AddRange(GetNeighbourNodes(startNode));

		while(WaitingNodes.Count > 0)
		{
			Node nodeToCheck = WaitingNodes.Where(x => x.F == WaitingNodes.Min(y => y.F)).FirstOrDefault();
			if(nodeToCheck.Position == TargerPosition)
			{
				return CalculatePathFromNode(nodeToCheck);
			}
			var walkable = Physics2D.OverlapCircle(nodeToCheck.Position, 0.1f,SolidLayer);
			if(walkable)
			{
				WaitingNodes.Remove(nodeToCheck);
				CheckedNodes.Add(nodeToCheck);


			} else if(!walkable)
			{
				WaitingNodes.Remove(nodeToCheck);
				if(!CheckedNodes.Where(x => x.Position == nodeToCheck.Position).Any())
				{
					CheckedNodes.Add(nodeToCheck);
					WaitingNodes.AddRange(GetNeighbourNodes(nodeToCheck));
				}


			}
		}
		
		FreeNodes = CheckedNodes;
    	return PathToTarget;
    }


    public List<Vector2> CalculatePathFromNode(Node node)
    {
    	var path = new List<Vector2>();
    	Node currentNode = node;

    	while(currentNode.PreviousNode != null)
    	{
    		path.Add(new Vector2(currentNode.Position.x,currentNode.Position.y));
    		 currentNode = currentNode.PreviousNode;
    	}
    	return path;
    }
    List<Node> GetNeighbourNodes (Node node)
    {
    	var Neighbours = new List<Node>();
    	Neighbours.Add(new Node(node.G+1,new Vector2(node.Position.x-1,node.Position.y),node.TargerPosition,node));

    	Neighbours.Add(new Node(node.G+1,new Vector2(node.Position.x+1,node.Position.y),node.TargerPosition,node));
    	Neighbours.Add(new Node(node.G+1,new Vector2(node.Position.x,node.Position.y-1),node.TargerPosition,node));
    	Neighbours.Add(new Node(node.G+1,new Vector2(node.Position.x,node.Position.y+1),node.TargerPosition,node));

    	return Neighbours;
    }

    void OnDrawGizmos()
    {
    	foreach (var item in CheckedNodes)
    	{
    		Gizmos.color = Color.green;
    		Gizmos.DrawSphere(new Vector2(item.Position.x,item.Position.y), 0.1f);
    	}
    	if(PathToTarget != null)
    	foreach(var item in PathToTarget)
    	{
    		Gizmos.color = Color.red;
    		Gizmos.DrawSphere(new Vector2(item.x,item.y), 0.2f);
    	}
    }
}


public class Node
{
	public Vector2 Position;
	public Vector2 TargerPosition;
	public Node PreviousNode;
	public int F;// F=G+H
	public int G;// расстояние от старта до ноды
	public int H;// расстояние от ноды до цели
    public Node(int g, Vector2 nodePosition, Vector2 targerPosition, Node previousNode)
    {
    	Position = nodePosition;
    	TargerPosition = targerPosition;
    	PreviousNode = previousNode;
    	G = g;
    	H = (int)Mathf.Abs(targerPosition.x - Position.x) + (int)Mathf.Abs(targerPosition.y - Position.y);
    	F = G + H;
    }
}

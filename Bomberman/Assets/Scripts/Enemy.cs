using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
	private List<Vector2> PathToBomberman = new List<Vector2>();
	public GameObject Bomberman;
	private bool isMoving;
	public float MoveSpeed;
	private PathFinder PathFinder;
    // Start is called before the first frame update
    void Start()
    {
    	if(Bomberman != null)
    	{    	
    		PathFinder = GetComponent<PathFinder>();
        	PathToBomberman = PathFinder.GetPath(Bomberman.transform.position);
        	isMoving = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Bomberman == null ) return;

         if(PathToBomberman.Count == 0 && Vector2.Distance(transform.position,Bomberman.transform.position) > 0.5f )
         {
         	PathToBomberman = PathFinder.GetPath(Bomberman.transform.position);
        	isMoving = true;
         }
        if(PathToBomberman.Count == 0)
        {
        	return;
        }

        if(isMoving)
        {
        	if(Vector2.Distance(transform.position,PathToBomberman[PathToBomberman.Count - 1]) > 0.1f)
        	{     
        		isMoving = true;   		
        		transform.position = Vector2.MoveTowards(transform.position,PathToBomberman[PathToBomberman.Count - 1], MoveSpeed * Time.deltaTime);        		
        	}
        	if(Vector2.Distance(transform.position,PathToBomberman[PathToBomberman.Count - 1]) <= 0.1f)
        	{
        		isMoving = false;         		
            }
            else
            {
            	PathToBomberman = PathFinder.GetPath(Bomberman.transform.position);
            	isMoving = true;
            }
        }
    }
}

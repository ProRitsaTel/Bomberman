using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
	private List<Vector2> PathToBomberman = new List<Vector2>();
	private List<Vector2> RandomPath = new List<Vector2>();
	private List<Vector2> CurrentPath = new List<Vector2>();
	public GameObject Bomberman;
	public GameObject DeathEffect;
	private bool isMoving;
	private bool qwe = false;
	public float MoveSpeed;
	private PathFinder PathFinder;
	private bool SeeBomberman;
	private float seconds;
	public LayerMask SolidLayer;
	public float i =2;

    // Start is called before the first frame update
    void Start()
    {
    	if(Bomberman != null)
    	{    	
    		PathFinder = GetComponent<PathFinder>();
        	CurrentPath = PathFinder.GetPath(Bomberman.transform.position);
        	isMoving = true;
        }
    }
   
    public void ReCalculatePath()
    {
   	
    	PathToBomberman = PathFinder.GetPath(Bomberman.transform.position);
    	
    	if(PathToBomberman.Count == 0) 
         	{	
         		SeeBomberman = false;
         		if(!SeeBomberman )
         		{         		         			        			
         			var r = Random.Range(0,PathFinder.FreeNodes.Count);         											
	         		RandomPath = PathFinder.GetPath(PathFinder.FreeNodes[r].Position);	         		
		         	CurrentPath = RandomPath;
		         	print(CurrentPath.Count);		         		         			         			         				         						         	
         		}
         	}
         	else
         	{
         		CurrentPath = PathToBomberman;
         		SeeBomberman = true;
         	}
         
    }

    public void Damage(int source)
    {
    	if(source == 1)
    	{
    		Instantiate(DeathEffect,transform.position,transform.rotation);
    		Destroy(gameObject);
    	}
    }
    // Update is called once per frame
    void Update()
    {
        if(Bomberman == null ) return;

         if(CurrentPath.Count == 0 && Vector2.Distance(transform.position,Bomberman.transform.position) > 0.5f )
         {
         	         	
         	ReCalculatePath();
         	
        	isMoving = true;
         }
        if(CurrentPath.Count == 0)
        {
        	return;
        }

        if(isMoving)
        {
        	if(Vector2.Distance(transform.position,CurrentPath[CurrentPath.Count - 1]) > 0.1f)
        	{     
        				
        		transform.position = Vector2.MoveTowards(transform.position,CurrentPath[CurrentPath.Count - 1], MoveSpeed * Time.deltaTime);        		
        	}
        	if(Vector2.Distance(transform.position,CurrentPath[CurrentPath.Count - 1]) <= 0.1f)
        	{
        		isMoving = false;         		
            }
            else
            {
            	ReCalculatePath();
            	isMoving = true;
            }
        }
    }
}

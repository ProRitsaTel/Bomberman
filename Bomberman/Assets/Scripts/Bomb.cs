using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
	public GameObject Fire;
	public float Delay;
	public float Counter;
	public LayerMask StoneLayer;
	public LayerMask BrickLayer;

	public List<Vector2> CellsToBlowRight;
	public List<Vector2> CellsToBlowLeft;
	public List<Vector2> CellsToBlowUp;
	public List<Vector2> CellsToBlowDown;

	private int FireLength;
    // Start is called before the first frame update
    void Start()
    {
        Counter = Delay;
        CellsToBlowRight = new List<Vector2>();
        CellsToBlowLeft = new List<Vector2>();
        CellsToBlowUp = new List<Vector2>();
        CellsToBlowDown = new List<Vector2>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Counter > 0) Counter -= Time.deltaTime;
        else
        {
        	Blow();
        }
    }

    void Blow()
    {
    	FireLength = FindObjectOfType<Bomberman>().GetFireLength();
    	//LEFT
    	for(int i = 1; i <= FireLength; i++)
    	{
    		if(Physics2D.OverlapCircle(new Vector2(transform.position.x - i,transform.position.y), 0.1f, StoneLayer))
    		{
    			break;
    		}
    		if(Physics2D.OverlapCircle(new Vector2(transform.position.x - i,transform.position.y), 0.1f, BrickLayer))
    		{
    			CellsToBlowLeft.Add(new Vector2(transform.position.x - i,transform.position.y));
    			break;
    		}
    		CellsToBlowLeft.Add(new Vector2(transform.position.x - i,transform.position.y));
    	}
    	//RIGTH
    	for(int i = 1; i <= FireLength; i++)
    	{
    		if(Physics2D.OverlapCircle(new Vector2(transform.position.x + i,transform.position.y), 0.1f, StoneLayer))
    		{
    			break;
    		}
    		if(Physics2D.OverlapCircle(new Vector2(transform.position.x + i,transform.position.y), 0.1f, BrickLayer))
    		{
    			CellsToBlowRight.Add(new Vector2(transform.position.x + i,transform.position.y));
    			break;
    		}
    		CellsToBlowRight.Add(new Vector2(transform.position.x + i,transform.position.y));
    	}
    	//UP
    	for(int i = 1; i <= FireLength; i++)
    	{
    		if(Physics2D.OverlapCircle(new Vector2(transform.position.x ,transform.position.y + i), 0.1f, StoneLayer))
    		{
    			break;
    		}
    		if(Physics2D.OverlapCircle(new Vector2(transform.position.x,transform.position.y + i), 0.1f, BrickLayer))
    		{
    			CellsToBlowUp.Add(new Vector2(transform.position.x,transform.position.y + i));
    			break;
    		}
    		CellsToBlowUp.Add(new Vector2(transform.position.x,transform.position.y + i));
    	}
    	//DOWN
    	for(int i = 1; i <= FireLength; i++)
    	{
    		if(Physics2D.OverlapCircle(new Vector2(transform.position.x ,transform.position.y - i), 0.1f, StoneLayer))
    		{
    			break;
    		}
    		if(Physics2D.OverlapCircle(new Vector2(transform.position.x,transform.position.y - i), 0.1f, BrickLayer))
    		{
    			CellsToBlowDown.Add(new Vector2(transform.position.x,transform.position.y - i));
    			break;
    		}
    		CellsToBlowDown.Add(new Vector2(transform.position.x,transform.position.y - i));
    	}

    }
    void OnDrawGizmos()
    {   	
    	foreach(var item in CellsToBlowLeft)
    	{
    		Gizmos.color = Color.yellow;
    		Gizmos.DrawSphere(item, 0.2f);   		
    	}
    	foreach(var item in CellsToBlowRight)
    	{
    		Gizmos.color = Color.green;
    		Gizmos.DrawSphere(item, 0.2f);   		
    	}  
    	foreach(var item in CellsToBlowDown)
    	{
    		Gizmos.color = Color.black;
    		Gizmos.DrawSphere(item, 0.2f);   		
    	}  
    	foreach(var item in CellsToBlowUp)
    	{
    		Gizmos.color = Color.blue;
    		Gizmos.DrawSphere(item, 0.2f);   		
    	}      	
    }
}

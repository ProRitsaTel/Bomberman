using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
	public GameObject FireMid;
	public GameObject FireHorizontal;
	public GameObject FireHorizontalRigth;
	public GameObject FireHorizontalLeft;
	public GameObject FireVertical;
	public GameObject FireVerticalDown;
	public GameObject FireVerticalUp;
	
	public float Delay;
	public float Counter;

	public LayerMask StoneLayer;
	public LayerMask BrickLayer;

	public List<Vector2> CellsToBlowRight;
	public List<Vector2> CellsToBlowLeft;
	public List<Vector2> CellsToBlowUp;
	public List<Vector2> CellsToBlowDown;

	private int FireLength;
	private bool CanTick;

	private Bomberman bomberman;
    // Start is called before the first frame update
    void Start()
    {
    	bomberman = FindObjectOfType<Bomberman>();
    	if(bomberman.CheakDetonator()) CanTick = true;
    	else CanTick = false;
        Counter = Delay;
        CellsToBlowRight = new List<Vector2>();
        CellsToBlowLeft = new List<Vector2>();
        CellsToBlowUp = new List<Vector2>();
        CellsToBlowDown = new List<Vector2>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Counter > 0 )
		{
			if(!CanTick)Counter -= Time.deltaTime;
		}        
        else
        {
        	Blow();      	
        }
    }

     public void OnTriggerEnter2D(Collider2D other)
    {
    	if(other.gameObject.tag == "Fire")
    	{
    		Blow();   		
    	}
    }

    public  void Blow()
    {
    	CalculateFireDiraction();
    	Instantiate(FireMid,transform.position,transform.rotation);
    	//Left
    	if(CellsToBlowLeft.Count > 0)
     	    for(int i = 0; i < CellsToBlowLeft.Count; i++)
    		{
    			if(i == CellsToBlowLeft.Count - 1) Instantiate(FireHorizontalLeft,CellsToBlowLeft[i],transform.rotation);
    			else Instantiate(FireHorizontal,CellsToBlowLeft[i],transform.rotation);
    		}  		
   		//Rigth
    	if(CellsToBlowRight.Count > 0)    	
    		for(int i = 0; i < CellsToBlowRight.Count; i++)
    		{
    			if(i == CellsToBlowRight.Count - 1) Instantiate(FireHorizontalRigth,CellsToBlowRight[i],transform.rotation);
    			else Instantiate(FireHorizontal,CellsToBlowRight[i],transform.rotation);
    		}
    	//Up
    	if(CellsToBlowUp.Count > 0)    	
    		for(int i = 0; i < CellsToBlowUp.Count; i++)
    		{
    			if(i == CellsToBlowUp.Count - 1) Instantiate(FireVerticalUp,CellsToBlowUp[i],transform.rotation);
    			else Instantiate(FireVertical,CellsToBlowUp[i],transform.rotation);
    		}
    	//Down  	
    	if(CellsToBlowDown.Count > 0)    	
    		for(int i = 0; i < CellsToBlowDown.Count; i++)
    		{
    			if(i == CellsToBlowDown.Count - 1) Instantiate(FireVerticalDown,CellsToBlowDown[i],transform.rotation);
    			else Instantiate(FireVertical,CellsToBlowDown[i],transform.rotation);
    		}  	  		
   		Destroy(gameObject);

    }
    void CalculateFireDiraction()
    {
    	FireLength = bomberman.GetFireLength();
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

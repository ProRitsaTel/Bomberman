using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomberman : MonoBehaviour
{
	private bool ButtonLeft;
	private bool ButtonRight;
	private bool ButtonUp;
	private bool ButtonDown;
	private bool ButtonBomb;
	private bool ButtonDetonate;
	
	private bool CanMove;
	private bool InsideBomd;

	private int BombsAllowed;
	private int FireLength;

	public int Diraction; // 8-вверх 6 вправо 2 -вниз 4-влево 

	public Transform Sensor;
	public float SensorSize = 0.4f ;
	public float SensorRange = 0.4f;
	public float MoveSpeed = 2;

	
	public LayerMask StoneLayer;
	public LayerMask BombLayer;

	public GameObject Bomb;


	


    // Start is called before the first frame update
    void Start()
    {
    	BombsAllowed = 2;
    	FireLength = 5;
    }
    // Update is called once per frame
    void Update()
    {
       GetInput();
       GetDiraction(); 
       HandleSensor();
       HandleBombs();
       Move();
    }

    private void HandleBombs()
    {
    	if(ButtonBomb && GameObject.FindGameObjectsWithTag("Bomb").Length < BombsAllowed)
    	{
    		Instantiate(Bomb, new Vector2(Mathf.Round(transform.position.x),Mathf.Round(transform.position.y)), transform.rotation); 
    	}
    }

    private void Move()
    {
    	if(!CanMove) return;

    	switch(Diraction)
    	{
    		case 2:
    			transform.position = new Vector2(Mathf.Round(transform.position.x), transform.position.y - MoveSpeed * Time.deltaTime);
    			break;
    		case 4:
    			transform.position = new Vector2(transform.position.x - MoveSpeed * Time.deltaTime, Mathf.Round(transform.position.y));	
    			break;
    		case 6:
    			transform.position = new Vector2(transform.position.x + MoveSpeed * Time.deltaTime, Mathf.Round(transform.position.y));	
    			break;
    		case 8:
    			transform.position = new Vector2(Mathf.Round(transform.position.x), transform.position.y + MoveSpeed * Time.deltaTime);	
    			break;   		    	    				
    	}

    }

    void HandleSensor()
    {
    	Sensor.transform.localPosition = new Vector2(0, 0);
    	InsideBomd = Physics2D.OverlapBox(Sensor.position, new Vector2(SensorSize, SensorSize), 0, BombLayer);
    	switch(Diraction)
    	{
    		case 2:
    			Sensor.transform.localPosition = new Vector2(0, -SensorRange);	
    			break;
    		case 4:
    			Sensor.transform.localPosition = new Vector2(-SensorRange, 0);	
    			break;
    		case 6:
    			Sensor.transform.localPosition = new Vector2(SensorRange, 0);	
    			break;
    		case 8:
    			Sensor.transform.localPosition = new Vector2(0, SensorRange);	
    			break;   		    	    				
    	}
    	
    	CanMove = !Physics2D.OverlapBox(Sensor.position, new Vector2(SensorSize, SensorSize), 0, StoneLayer);
    	if(CanMove && !InsideBomd)
    	   CanMove = !Physics2D.OverlapBox(Sensor.position, new Vector2(SensorSize, SensorSize), 0, BombLayer);
    }

    void GetDiraction()
    {
    	Diraction = 5;
    	if(ButtonLeft) Diraction = 4;
    	if(ButtonRight) Diraction = 6;
    	if(ButtonUp) Diraction = 8;
    	if(ButtonDown) Diraction = 2;
    }


    void GetInput()
    {
    	ButtonLeft = Input.GetKey(KeyCode.LeftArrow) && !Input.GetKey(KeyCode.RightArrow) && !Input.GetKey(KeyCode.DownArrow) && !Input.GetKey(KeyCode.UpArrow);
    	ButtonRight = !Input.GetKey(KeyCode.LeftArrow) && Input.GetKey(KeyCode.RightArrow) && !Input.GetKey(KeyCode.DownArrow) && !Input.GetKey(KeyCode.UpArrow); 
    	ButtonUp = !Input.GetKey(KeyCode.LeftArrow) && !Input.GetKey(KeyCode.RightArrow) && !Input.GetKey(KeyCode.DownArrow) && Input.GetKey(KeyCode.UpArrow); 
    	ButtonDown = !Input.GetKey(KeyCode.LeftArrow) && !Input.GetKey(KeyCode.RightArrow) && Input.GetKey(KeyCode.DownArrow) && !Input.GetKey(KeyCode.UpArrow); 

    	ButtonBomb = Input.GetKey(KeyCode.Z);
    	ButtonDetonate = Input.GetKey(KeyCode.Y);
    }

    public void AddBomb()
    {
    	BombsAllowed++;
    }
    public void AddFireLenght()
    {
    	FireLength++;
    }
    public int GetFireLength()
    {
    	return FireLength;
    }
}

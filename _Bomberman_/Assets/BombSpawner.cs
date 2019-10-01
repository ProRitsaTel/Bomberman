using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombSpawner : MonoBehaviour
{
	public GameObject bomb;

	public int firePower = 1;
	int numberOfBombs = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {    
    	//При нажатии на кнопку пробел спавнится бамба,и если у игрока есть хот бы одна бомба
        if(Input.GetButtonDown("Jump") && numberOfBombs >= 1)
        {
        	//Добавление позиции для бомбы 
        	Vector2 spawnPos = new Vector2(Mathf.Round(transform.position.x),Mathf.Round(transform.position.y));
        	//Добавление картинки бомбы при нажатии 
        	var newBomb = Instantiate(bomb, spawnPos, Quaternion.identity) as GameObject;
        	//Устанавливается сила взрыва
        	newBomb.GetComponent<Bomb>().firePower = firePower;
        	//Уменьшение бомбы 
        	numberOfBombs--;
        	//Добавление бомбы через 1 секунду
        	Invoke("AddBomb", 1);
        }
    }
    //Добавление бомбы
    public void AddBomb()
    {
    	numberOfBombs++;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
	public GameObject fire;
	public int firePower;
	public float fuse;
    // Start is called before the first frame update
    void Start()
    {
    	//Задержка до взрыва
        Invoke("Exploide", fuse);
    }

       void Exploide()
    {
        Debug.Log("Boom: " + firePower);
        //Создание центра огня
        Instantiate(fire, transform.position, Quaternion.identity);
        
        //Создание остальной длинны огня 
        for(int i = 0; i < firePower; i++)
        {
        	SpawnFire(Vector3(i + 1, 0, 0));
        	SpawnFire(Vector3(i - 1, 0, 0));
        	SpawnFire(Vector3(0, i + 1, 0));
        	SpawnFire(Vector3(0, i - 1, 0));
        }
        //Уничтожение огня
        Destroy(gameObject);
    }
    //Функия для спавна огня
    private void SpawnFire(Vector offset)
    {
    	if(true)
    	{       
    			Instantiate(fire, transform.position + offset, Quaternion.identity);
    	else
    	{
    		return ;
    	}	
    }
    //Добавление бомбе структуры
    public void OnTriggerExit2D(Collider2D collision)
    {
    	GetComponent<BoxCollider2D>().isTrigger = false;
    }
}

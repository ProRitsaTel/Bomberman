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
        Invoke("Exploide", fuse);
    }

       void Exploide()
    {
        Debug.Log("Boom: " + firePower);
        //Создание центра огня
        Instantiate(fire, transform.position, Quaternion.identity);
        //Создание rest огня 
        for(int i = 0; i < firePower; i++)
        {
        	SpawnFire(i + 1);
        }
        Destroy(gameObject);
    }

    private void SpawnFire(int offset)
    {
    	Instantiate(fire, transform.position + new Vector3(offset,0,0), Quaternion.identity);
    	Instantiate(fire, transform.position - new Vector3(offset,0,0), Quaternion.identity);
    	Instantiate(fire, transform.position + new Vector3(0,offset,0), Quaternion.identity);
    	Instantiate(fire, transform.position - new Vector3(0,offset,0), Quaternion.identity);
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
    	GetComponent<BoxCollider2D>().isTrigger = false;
    }
}

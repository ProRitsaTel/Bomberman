using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
	public GameObject BrickDeathEffect;
     // Start is called before the first frame update
    public void DestroySelf()
    {
    	Destroy(gameObject);
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
    	if(other.gameObject.tag == "Brick")
    	{
    		Destroy(other.gameObject);
    		Instantiate(BrickDeathEffect,transform.position,transform.rotation);
    	}
    }
}

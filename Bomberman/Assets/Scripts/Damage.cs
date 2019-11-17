using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{	
	public static int FIRE_DAMAGE = 1;
	public static int ENEMY_DAMAGE = 2;

	public int source;
    // Start is called before the first frame update
   	void OnTriggerEnter2D(Collider2D other)
    {
    	if(other.gameObject.tag == "Player")
    	{	
    		other.GetComponent<Bomberman>().Damage(source);
    	}
    	if(other.gameObject.tag == "Enemy")
    	{	
    		other.GetComponent<Enemy>().Damage(source);
    	}
    }
}

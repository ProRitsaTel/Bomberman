using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    //Длительность огня
       void Start()
    {
       Destroy(gameObject,0.3f);
    }

    //Эффект поворота 
   void Update()
   {
   		transform.Rotate(0,0,-45);
   }
   public void OnTriggerEnter2D(Collider2D collision)
   {
   		Destroy(collision.gameObject);
   }
}

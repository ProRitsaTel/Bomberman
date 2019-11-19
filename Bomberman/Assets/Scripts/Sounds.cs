using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Sounds : MonoBehaviour
{
    // Start is called before the first frame update
 	public Slider slider;
 	Enemy enemy = new Enemy();
 	void Start()
 	{
 		 slider.value = Value() ;
 	}
 	void Update () 
 	{  
   		AudioListener.volume = slider.value;
 	}

 	public float Value()
 	{
 	    float Value1 =  AudioListener.volume;
 		return(Value1);
 	}

  		public void Menu()
    {
    	SceneManager.LoadScene("MainMenu");    	
    }

}

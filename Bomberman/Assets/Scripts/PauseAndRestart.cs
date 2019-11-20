using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PauseAndRestart : MonoBehaviour
{
    // Start is called before the first frame update
   public bool pause = true;
   public GameObject panel;
   public GameObject Bomberman;
   Sounds sounds = new Sounds();
   public void pause1()
   {
   		if(pause)
   		{
   			Time.timeScale = 0;
   			pause = false;
   			panel.SetActive(true);
   		}
   		else
   		{
   			Time.timeScale = 1;
   			pause = true;
   			panel.SetActive(false);
   		}
  
   }
    public void MainMenu()
    {
    	Time.timeScale = 1;
    	pause = true;
        SceneManager.LoadScene("MainMenu");
        AudioListener.volume = sounds.Value();
    }
    public void StartGame()
    {
    	Time.timeScale = 1;
        SceneManager.LoadScene("qwe");
        AudioListener.volume = sounds.Value();
        
    }
    public void Update()
    {
    	if(Bomberman == null )
    	{
    		panel.SetActive(true);
    	}
    }
  
}

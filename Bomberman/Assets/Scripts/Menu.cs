using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{

    Sounds sounds = new Sounds();
    // Start is called before the first frame update
    public void StartGame()
    {
        SceneManager.LoadScene("qwe");
        AudioListener.volume = sounds.Value();
    }
    public void SettingsGame()
    {
        SceneManager.LoadScene("Settings");
        AudioListener.volume = sounds.Value();
    }
    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
        AudioListener.volume = sounds.Value();
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}
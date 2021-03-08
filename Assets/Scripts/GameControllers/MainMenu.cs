using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public string levelToLoad = "Pantanal";

    public void Play(){
        Debug.Log("Loading " + levelToLoad);
        SceneManager.LoadScene(levelToLoad);
    }

    public void Quit(){
        Debug.Log("Exiting...");
        Application.Quit();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public string levelToLoad = "Pantanal";
    public GameObject SelectModeUI;

    public void Play(){
        Debug.Log("Loading " + levelToLoad);
        SceneManager.LoadScene(levelToLoad);
    }

    public void SelectMode(){
        SelectModeUI.SetActive(true);
    }

    public void Normal(){
        GameManager.zenMode = false;
        Play();
    }

    public void ZenMode(){
        GameManager.zenMode = true;
        Play();
    }

    public void Quit(){
        Debug.Log("Exiting...");
        Application.Quit();
    }
}

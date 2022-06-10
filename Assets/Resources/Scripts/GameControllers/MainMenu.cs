using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public string levelToLoad = "Pantanal";
    public GameObject selectModeUI;
    public GameObject creditosUI;

    public void Play(){
        Debug.Log("Loading " + levelToLoad);
        SceneManager.LoadScene(levelToLoad);
    }

    public void SelectMode(){
        selectModeUI.SetActive(true);
    }

    public void Normal(){
        GameManager.zenMode = false;
        Play();
    }

    public void ZenMode(){
        GameManager.zenMode = true;
        Play();
    }

    public void Creditos(){
        creditosUI.SetActive(true);
    }

    public void Voltar(){
        creditosUI.SetActive(false);
    }

    public void Quit(){
        Debug.Log("Exiting...");
        Application.Quit();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static bool gameIsOver;
    public GameObject gameOverUI;
    public GameObject shopUI;
    public GameObject gameInfosUI;
    public GameObject pauseUI;

    private bool isPaused = false;
    public static bool zenMode = false;
    //public PauseMenu pauseMenuUI;
    
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        gameIsOver = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        if(gameIsOver == true){
            return;
        }

        if(Input.GetKeyDown("e")){
            EndGame();
        }

        if(Input.GetKeyDown(KeyCode.Escape)){
            if(isPaused){ 
                isPaused = false;
                Resume();
            }
            else if(!isPaused){
                isPaused = true;
                Pause();
            }
        }

        if(PlayerStats.lives <= 0){
            EndGame();
        }
    }

    void EndGame(){
        gameIsOver = true;
        gameOverUI.SetActive(true);
        shopUI.SetActive(false);
        gameInfosUI.SetActive(false);
    }

    public static void Retry(){
        //reload the current scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public static void Menu(){
        SceneManager.LoadScene("MainMenu");
    }

    public static void Quit(){
        Application.Quit();
    }

    public void Pause(){
        pauseUI.SetActive(true);
        shopUI.SetActive(false);
        Time.timeScale = 0;
    }

    public void Resume(){
        pauseUI.SetActive(false);
        shopUI.SetActive(true);
        Time.timeScale = 1;
    }
}

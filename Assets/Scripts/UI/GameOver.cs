using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    public Text roundsText;
    
    void OnEnable(){
        roundsText.text = PlayerStats.rounds.ToString();
    }

    public void Retry(){
        //reload the current scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Menu(){
        //SceneManager.LoadScene("MainMenu");
    }
}

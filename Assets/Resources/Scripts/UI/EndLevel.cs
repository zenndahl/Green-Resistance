using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndLevel : MonoBehaviour
{
    //public Text roundsText;
    public Text goldText;
    public Text enemiesText;
    public GameObject shopUI;
    public GameObject infosUI;

    void OnEnable(){
        // roundsText.text = PlayerStats.rounds.ToString();
        shopUI.SetActive(false);
        infosUI.SetActive(false);
        goldText.text = PlayerStats.money.ToString();
        enemiesText.text = PlayerStats.enemiesKilled.ToString();
    }

    public void PlayAgain(){
        //reload the current scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Menu(){
        SceneManager.LoadScene("MainMenu");
    }
}

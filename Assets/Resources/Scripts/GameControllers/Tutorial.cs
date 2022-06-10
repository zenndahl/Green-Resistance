using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour
{
    public GameObject plantarUI;
    public GameObject instructionsUI;
    public GameObject instructionsUI2;
    private bool instructionsState = true;
    // Start is called before the first frame update
    void Awake()
    {
        Time.timeScale = 0;
    }

    public void ShowHide(){
        instructionsUI.SetActive(!instructionsState);
        instructionsUI2.SetActive(instructionsState);
        instructionsState = !instructionsState;
    }

    public void Sair(){
        Time.timeScale = 1;
        plantarUI.SetActive(false);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class GameOver : MonoBehaviour
{
    public TextMeshProUGUI nOfRoundsText;
    
    void OnEnable(){
        nOfRoundsText.text = PlayerStats.rounds.ToString();
    }
}

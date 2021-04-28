using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    public Text roundsText;
    
    void OnEnable(){
        roundsText.text = PlayerStats.rounds.ToString();
    }
}

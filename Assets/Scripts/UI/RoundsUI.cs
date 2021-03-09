using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class RoundsUI : MonoBehaviour
{
    public Text roundsText;
    
    void Update(){
        roundsText.text = PlayerStats.rounds.ToString();
    }
}
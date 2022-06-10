using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class LifesUI : MonoBehaviour
{
    public TextMeshProUGUI livesText;
    
    void Update(){
        livesText.text = PlayerStats.lives.ToString();
    }
}

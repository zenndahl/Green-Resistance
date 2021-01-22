using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class LifesUI : MonoBehaviour
{
    public Text livesText;
    void Update(){
        livesText.text = "Vidas: " + PlayerStats.lives.ToString();
    }
}

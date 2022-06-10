using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;


public class AbatesUI : MonoBehaviour
{
    public TextMeshProUGUI enemiesText;
    void Update(){
        enemiesText.text = PlayerStats.enemiesKilled.ToString();
    }
}

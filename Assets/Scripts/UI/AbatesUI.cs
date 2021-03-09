using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;


public class AbatesUI : MonoBehaviour
{
    public Text enemiesText;
    void Update(){
        enemiesText.text = PlayerStats.enemiesKilled.ToString();
    }
}

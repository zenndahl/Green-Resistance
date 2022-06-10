using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour{
    
    //TODO MAKE THIS A SCRIPTABLE OBJECT

    public static int money;
    public static int lives;
    public int startMoney = 200;
    public int startLives = 5;
    public static int rounds;
    public static int enemiesKilled;

    // Start is called before the first frame update
    void Start(){
        money = startMoney;
        lives = startLives;
        rounds = 0;
        enemiesKilled = 0;
    }
}

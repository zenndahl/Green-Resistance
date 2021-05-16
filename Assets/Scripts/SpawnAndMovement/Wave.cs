using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave : MonoBehaviour{
    public GameObject[] enemies;//vector of enemies that will be in the level
    public int initialCount; //initial quantity of enemies in the wave
    public int modifier; //number of enemies increment
    public float rate; //frequency of enemies spawn
    [HideInInspector]
    public int[] count; //vector to trace the count of each type of enemy
    public int indexOfIncrement = 1; //indicates wich enemy to add each time it increments

    private void Awake(){
        count = new int[5];
        for(int i = 1; i < 5; i++){
            count[i] = 0;
        }
        count[0] = initialCount;
    }

    //on evens indexes of the wave, calls this function and starts the spawning cicle of next enemy
    public void AddEnemyType(){
        count[indexOfIncrement] = initialCount;
        if(indexOfIncrement >= 4) return;
        indexOfIncrement++;
    }

    //increases the number of enemies of the spawning types on each odd index of the wave
    public void Increment(){
        for(int i = 0; i < 5; i++){
            if(count[i] != 0){
                count[i] += modifier;
            }
        }
    }

    //ads the boss to the wave spawner
    public void CallBoss(){
        for(int i = 0; i < 5; i++){
            count[4] = initialCount;
        }
    }
}

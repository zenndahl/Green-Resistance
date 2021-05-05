using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    public Wave wave;
    public static int enemiesAlive = 0;
    public float initialCountdownTime = 10f;
    public float betweenTime = 7f;
    public Transform spawnPoint;
    public Text waveCountdownTimer;
    public GameObject endLevel;
    public int waveCount = 100;

    private float countdown = 10f;
    private int waveIndex = 0;

    private void Start() {
        betweenTime = initialCountdownTime;
    }

    private void Update() {

        //if there is at leat one enemy alive, the next countdown will not begin
        if(enemiesAlive > 0){
            waveCountdownTimer.enabled = false;
            return;
        }
        else{
            waveCountdownTimer.enabled = true;
        }

        //when the coutdown ends, a coroutine will begin and instantiate the enemies
        if(countdown <= 0f){
            StartCoroutine(spawnWave());
            countdown = betweenTime; //reset the countdown
            return;
        }
        //update the time between waves
        countdown -= Time.deltaTime;
        countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);

        //update the timer UI
        waveCountdownTimer.text = Mathf.Round(countdown).ToString();
        waveCountdownTimer.text = string.Format("{0:00.00}", countdown);

        //fazer a contagem desaparecer enquanto tiver inimigos na tela
    }

    IEnumerator spawnWave(){
        //if the game is in normal mode, the game ends when the waves reach the total count of the level
        if(!GameManager.zenMode){
            if(waveIndex == waveCount){
                endLevel.SetActive(true);
                yield return 0;
            }
        }
        int index = 0; //to access the index of the enemies vector 
        foreach(int enemyQuantity in wave.count){ //for each enemy, it gets its quantity to spawn
            if(enemyQuantity != 0){
                for (int i = 0; i < enemyQuantity; i++){
                    spawnEnemy(wave.enemies[index]);
                    yield return new WaitForSeconds(1f / wave.rate);
                }
            }
            index++;
        }

        //for each even wave, a new enemy type will spawn, if it has not spawned yet
        if(waveIndex % 2 == 0 && wave.indexOfIncrement <= 5) wave.AddEnemyType();
        //for each odds wave, the spawning enemy types will spawn more units
        if(waveIndex % 2 != 0) wave.Increment();
        //after the 15 wave, at every 5 waves, more bosses will spawn
        if(waveIndex % 5 == 0 && waveIndex >= 15) wave.CallBoss();

        waveIndex++;
        PlayerStats.rounds = waveIndex;
    }

    void spawnEnemy(Transform enemy){
        //instantiate an enemy and add it to the list of alive enemies
        Instantiate(enemy, spawnPoint.position, spawnPoint.rotation);
        enemiesAlive++;
    }
}

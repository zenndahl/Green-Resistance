using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class WaveSpawner : MonoBehaviour
{
    public Wave wave;
    public float initialCountdownTime = 10f;
    public float betweenTime = 30f;
    public Transform spawnPoint;
    public TextMeshProUGUI waveCountdownTimer;
    public GameObject endLevel;
    public int waveCount = 100;

    private float countdown = 10f;
    private int waveIndex = 0;
    private bool levelEnded = false;
    private int totalEnemies = 0;
    private int enemiesSpawned = 0;
    public static int enemiesAlive = 0;

    private void Start() {
        betweenTime = initialCountdownTime;
    }

    private void Update() {

        //if the game is in normal mode, the game ends when the waves reach the total count of the level
        if(!GameManager.zenMode){
            if(waveIndex == waveCount && enemiesAlive == 0){
                endLevel.SetActive(true);
                FindObjectOfType<AudioManager>().PlayAudio("LevelCompleted");
                levelEnded = true;
                return;
            }
        }

        //if there is at leat one enemy alive, the next countdown will not begin
        if(enemiesSpawned < totalEnemies){
            waveCountdownTimer.enabled = false;
            return;
        }
        else{
            waveCountdownTimer.enabled = true;
        }

        //verifying if the next wave has stronger enemies to play the right audio cue
        if(countdown <= 1){
            if((waveIndex % 2 == 0 || waveIndex % 3 == 0) && waveIndex != 0){
                FindObjectOfType<AudioManager>().PlayAudio("StrongerEnemies");
            }
            else FindObjectOfType<AudioManager>().PlayAudio("WaveAlert");
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

        //TODO fazer a contagem desaparecer enquanto tiver inimigos na tela
    }

    IEnumerator spawnWave(){
        if(levelEnded){
            yield return 0;
        }
        else{
            int index = 0; //to access the index of the enemies vector 
            //each 3 waves, enemies will have a health upgrade
            if (waveIndex % 3 == 0 && waveIndex != 0) {
                EnemyStats.instance.UpgradeHealth();
            }

            //for each enemy type, it gets its quantity to spawn for that type
            foreach(int enemyQuantity in wave.count){
                totalEnemies += enemyQuantity;
                if(enemyQuantity != 0){
                    for (int i = 0; i < enemyQuantity; i++){
                        spawnEnemy(wave.enemies[index]);
                        yield return new WaitForSeconds(1f / wave.rate);
                    }
                }
                index++;
            }
        }

        //for each even wave, a new enemy type will spawn, if it has not spawned yet
        if(waveIndex % 2 == 0 && wave.indexOfIncrement <= 5) wave.AddEnemyType();
        //for each odds wave, the spawning enemy types will spawn more units
        if(waveIndex % 2 != 0) wave.Increment();
        //after the 15 wave, at every 5 waves, more bosses will spawn (disabled for now)
        //if(waveIndex % 5 == 0 && waveIndex >= 15) wave.CallBoss();
        if(waveIndex % 5 == 0 && waveIndex != 0) countdown += 10;

        waveIndex++;
        PlayerStats.rounds = waveIndex;
    }

    void spawnEnemy(GameObject enemy){
        //instantiate an enemy and add the number of alive spawned and alive
        Instantiate(enemy, spawnPoint.position, spawnPoint.rotation);
        
        enemiesSpawned++;
        enemiesAlive++;
    }
}

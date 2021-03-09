using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    public Wave[] waves;
    public static int enemiesAlive = 0;
    public float betweenTime = 7f;
    public Transform spawnPoint;
    public Text waveCountdownTimer;
    public GameObject endLevel;

    private float countdown = 10f;
    private int waveIndex = 0;
    private bool moreEnemies = false;

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
        waveCountdownTimer.text = string.Format("{0:00.00}", countdown);
        waveCountdownTimer.text = Mathf.Round(countdown).ToString();

        //fazer a contagem desaparecer enquanto tiver inimigos na tela
    }


    IEnumerator spawnWave(){
        Wave wave = waves[waveIndex];
        if(wave == null){
            endLevel.SetActive(true);
            yield return 0;
        }

        for (int i = 0; i < wave.count; i++){
            //each even index, different enemy spawns
            if(moreEnemies){
                spawnEnemy(wave.enemy[(i % 2)]);
            }
            else{
                spawnEnemy(wave.enemy[(0)]);
            }
            yield return new WaitForSeconds(1f / wave.rate);
        }

        waveIndex++;
        PlayerStats.rounds = waveIndex;
    }

    void spawnEnemy(Transform enemy){
        //instantiate an enemy and add it to the list of alive enemies
        Instantiate(enemy, spawnPoint.position, spawnPoint.rotation);
        enemiesAlive++;
    }
}

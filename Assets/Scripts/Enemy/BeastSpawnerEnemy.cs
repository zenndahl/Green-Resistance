using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeastSpawnerEnemy : Enemy
{
    public int beastCounter;
    public GameObject beastPrefab;
    public float spawnDelay;
    public float rate = 0.3f;

    // Start is called before the first frame update
    protected override void Start()
    {
        //get the first waypoint
        direction = Waypoints.points[wavepointIndex];
        health = EnemyStats.GetHealth(typeName);
        speed = EnemyStats.GetSpeed(typeName);

        StartCoroutine(SpawnBeast());
    }

    IEnumerator SpawnBeast(){
        for (int i = 0; i < beastCounter; i++){
            GameObject newEnemy = Instantiate(beastPrefab, transform.position, transform.rotation);
            Enemy beast = newEnemy.GetComponent<Enemy>()
;           beast.wavepointIndex = this.wavepointIndex;
            yield return new WaitForSeconds(1f / rate);
        }
    }

}

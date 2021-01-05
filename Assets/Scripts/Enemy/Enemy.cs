using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Setup")]
    protected Transform target;
    public int wavepointIndex = 0;
    public float initSpeed;
    public float initHealth;

    [Header("Stats")]
    public bool inDOT;

    [HideInInspector]
    public float speed;
    public float health;

    // Start is called before the first frame update
    protected virtual void Start()
    {
        //get the first waypoint
        target = Waypoints.points[wavepointIndex];
        speed = initSpeed;
        health = initHealth;
    }

    // Update is called once per frame
    void Update()
    {
        //move in the direction of the next waypoint
        Vector2 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);   

        //if it reaches the waypoint, get the next
        if(Vector2.Distance(transform.position, target.position) <= 0.01f){
            GetNextWaypoint();
        }
    }

    void GetNextWaypoint(){
        //if the enemy gets to the last waypoint, decreases the player lives and estroy the enemy
        if(wavepointIndex >= Waypoints.points.Length - 1){
            Destroy(gameObject);
            Debug.Log("Inimigo Chegou no Objetivo");
            WaveSpawner.enemiesAlive--;
            //PlayerStats.Lives -= 1;
            return;
        }
        //while it is not the last waypoint, get the next waypoint in the array
        wavepointIndex++;
        target = Waypoints.points[wavepointIndex];
    }

    public void TakeDamage(float damage){
        health -= damage;
        if(health <= 0){
            Destroy(gameObject);
            WaveSpawner.enemiesAlive--;
        }
    }
}

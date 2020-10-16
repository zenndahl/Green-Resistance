using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Transform target;
    private int wavepointIndex = 0;

    public float speed = 1f;

    // Start is called before the first frame update
    void Start()
    {
        //get the first waypoint
        target = Waypoints.points[0];
    }

    // Update is called once per frame
    void Update()
    {
        //move in the irection of the next waypoint
        Vector2 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);   

        //if it reaches the waypoint, get the next
        if(Vector2.Distance(transform.position, target.position) <= 0.1f){
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

    public void TakeDamage(){
        Destroy(gameObject);
    }
}

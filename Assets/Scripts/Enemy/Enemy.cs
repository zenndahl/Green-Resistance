using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Setup")]
    protected Transform direction;
    public int wavepointIndex = 0;
    public float initSpeed;
    public float initHealth;
    public float upHealth = 50;
    public int reward;
    public Animator animator;

    [Header("Stats")]
    public bool inDOT;

    //[HideInInspector]
    public float speed;
    public float health;

    // Start is called before the first frame update
    protected virtual void Start()
    {
        //get the first waypoint
        direction = Waypoints.points[wavepointIndex];
        speed = initSpeed;
        health = initHealth;
    }

    // Update is called once per frame
    protected virtual void Update()
    {

        //move in the direction of the next waypoint
        Vector2 dir = direction.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);   

        //if it reaches the waypoint, get the next
        if(Vector2.Distance(transform.position, direction.position) <= 0.05f){
            GetNextWaypoint();
        }

        if(direction.position.x < transform.position.x){
            GetComponent<SpriteRenderer>().flipX = true;
        }
        if(direction.position.x > transform.position.x){
            GetComponent<SpriteRenderer>().flipX = false;
        }
    }

    protected void GetNextWaypoint(){
        //if the enemy gets to the last waypoint, decreases the player lives and destroy the enemy
        if(wavepointIndex >= Waypoints.points.Length - 1){
            Destroy(gameObject);
            WaveSpawner.enemiesAlive--;
            PlayerStats.lives -= 1;
            return;
        }
        //while it is not the last waypoint, get the next waypoint in the array
        wavepointIndex++;
        direction = Waypoints.points[wavepointIndex];
    }

    public void Upgrade(){
        health += upHealth;
    }

    public void TakeDamage(float damage){
        health -= damage;
        StartCoroutine("DamageAnimation");
        if(health <= 0){
            Die();
        }
    }

    IEnumerator DamageAnimation(){
        animator.ResetTrigger("Return");
        animator.SetTrigger("TakeDamage");
        yield return new WaitForSeconds(0.2f);
        animator.ResetTrigger("TakeDamage");
        animator.SetTrigger("Return");
    }

    void Die(){
        PlayerStats.money += reward;
        animator.SetTrigger("Death");
        speed = 0;
        Destroy(gameObject, 0.4f);
        WaveSpawner.enemiesAlive--;
        PlayerStats.enemiesKilled++;
    }
}

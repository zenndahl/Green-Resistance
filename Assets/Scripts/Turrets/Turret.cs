using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour{
    [Header("Enemy Setup")]
    public Transform target;
    public string enemyTag = "Enemy";

    [Header("Turret Stats")]
    public float range;
    public float fireRate;
    public float health;
    public float shootCooldown = 0.5f;
    public bool inRange;

    [Header("Turret Setup")]
    public Transform firePoint;

    [Header("Ranged Settings")]
    public GameObject bulletPrefab;

    // Start is called before the first frame update
    protected virtual void Start(){
        //initiate a rotine to call the method for an amount of times 
        InvokeRepeating("EnemyInRange", 0f, 0.5f);
        inRange = false;
    }

    void EnemyInRange(){
        //searches all objects with the tag "Enemy"
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        foreach(GameObject enemy in enemies){
            //gets the distance between the enemy
            float distanceToEnemy = Vector2.Distance(transform.position, enemy.transform.position);
            //if the distance is the shortest distance, there is an enemy in range
            if(distanceToEnemy < range){
                inRange = true;
                return;
            }
        } 
        //if no enemy is in range
        inRange = false;
    }

    // Update is called once per frame
    void Update()
    {
        //if no enemy in range, does nothing
        if(!inRange){
            return;
        }

        //fire only at a determined rate
        if(shootCooldown <= 0f){
            Attack();
            shootCooldown = 1f /fireRate;
        }
        //decreases with time
        shootCooldown -= Time.deltaTime;
    }

    private void OnDrawGizmosSelected() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }

    public virtual void Attack(){
        return;
    }

    public void TakeDamage(float damage){
        health -= damage;
        if(health <= 0){
            Destroy(gameObject);
        }
    }
 }

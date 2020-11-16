﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour{
    [Header("Enemy Setup")]
    public Transform target;
    public string enemyTag = "Enemy";

    [Header("Turret Stats")]
    public float range;
    public float fireRate;
    public float shootCooldown = 0.5f;
    public bool inRange;

    [Header("Turret Setup")]
    public Transform firePoint;
    public bool isRanged;
    //set id there are modifiers and if it is for more or for less
    public int rangeModStatus;
    public int fireRateModStatus;
    public int damageModStatus;
    public int healthModStatus;

    [Header("Ranged Settings")]
    public GameObject bulletPrefab;

    [Header("Burst Settings")]
    public GameObject burstEffect;

    // Start is called before the first frame update
    protected virtual void Start(){
        //initiate a rotine to call the method for an amount of times 
        InvokeRepeating("EnemyInRange", 0f, 0.5f);
        inRange = false;
        //SetStats();
    }

    void EnemyInRange(){
        //searches all objects with the tag "Enemy"
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        foreach(GameObject enemy in enemies){
            //gets the distance between the enemy
            float distanceToEnemy = Vector2.Distance(transform.position, enemy.transform.position);
            //if the distance is the sortest distance, there is an enemy in range
            if(distanceToEnemy < range){
                inRange = true;
                return; //if there is an enemy in range, it already did what it needed to
            }
        }
        //if no enemy in range
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
 }

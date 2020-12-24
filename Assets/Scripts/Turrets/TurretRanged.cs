using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TurretRanged : Turret
{
    // Start is called before the first frame update
    protected override void Start(){
        //initiate a rotine to call the method for an amount of times 
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
        inRange = false;
    }
    
    void UpdateTarget(){
        //searches all objects with the tag "Enemy"
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        //set the initial distance to infinite
        float shortestDistance = Mathf.Infinity;
        //initialy there is no nearest enemy
        GameObject nearestEnemy = null;

        foreach(GameObject enemy in enemies){
            //gets the distance between the enemy
            float distanceToEnemy = Vector2.Distance(transform.position, enemy.transform.position);
            //if the distance is the sortest distance, it will update and set the enemy as the nearest
            if(distanceToEnemy < shortestDistance){
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
                inRange = true;
            }
        }

        //set the target as the enemy selected as the nearest
        if(nearestEnemy != null && shortestDistance <= range){
            target = nearestEnemy.transform;
            return;
        }
        inRange = false;
    }
    
    public override void Attack(){
        Attacks.Shoot(target, bulletPrefab, firePoint.position, firePoint.rotation);
    }
}

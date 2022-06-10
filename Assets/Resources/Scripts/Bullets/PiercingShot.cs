using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PiercingShot : Bullet
{
    public int enemiesToHit;
    public float range;

    public GameObject bulletPrefab;

    public override void Damage(){
        Enemy enemy = target.GetComponent<Enemy>();
        enemy.TakeDamage(damage);
        Pierce();
        Destroy(gameObject);
    }

    void Pierce(){
        //searches all objects with the tag "Enemy"
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        //set the initial distance to infinite
        float shortestDistance = Mathf.Infinity;
        //initialy there is no nearest enemy
        GameObject nearestEnemy = null;

        foreach(GameObject enemy in enemies){
            //gets the distance between the enemy
            if(enemy == target) Debug.Log("Igual");
            float distanceToEnemy = Vector2.Distance(transform.position, enemy.transform.position);
            //if the distance is the sortest distance, it will update and set the enemy as the nearest
            if(distanceToEnemy < shortestDistance && enemy != target){
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        //set the target as the enemy selected as the nearest
        if(nearestEnemy != null && shortestDistance <= range){
            target = nearestEnemy.transform;
            Attacks.Shoot(target, bulletPrefab, gameObject.transform.position, gameObject.transform.rotation, damage);
            return;
        }
    }
}

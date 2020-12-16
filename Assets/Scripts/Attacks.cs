using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacks : MonoBehaviour
{
    [Header("Base Stats")] 
    public static float baseDamage = 25f;
    public static float baseRange = 1.1f;
    public static float baseHealth = 50f;
    public static float baseFireRate = 1f;

    public static void Shoot(Transform target, GameObject bulletPrefab, Vector3 firePointPos, Quaternion firePointRot){
        //creates the bullet object on scene
        GameObject bulletGO = GameObject.Instantiate(bulletPrefab, firePointPos, firePointRot);

        //get the bullet component to access its variables and methods
        Bullet bullet = bulletGO.GetComponent<Bullet>();

        //determines the target for the bullet instantiated above
        if(bullet != null){
            bullet.Seek(target);
        }
    }

    public static void Burst(GameObject burstEffect, Vector3 firePointPos, Quaternion firePointRot, float range, float damage){
        //searches all objects with the tag "Enemy"
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        //instantiate effect
        GameObject RadialBurst = GameObject.Instantiate(burstEffect, firePointPos, firePointRot);

        foreach(GameObject enemy in enemies){
            //gets the distance between the enemy
            float distanceToEnemy = Vector2.Distance(firePointPos, enemy.transform.position);
            //if the distance of the enemy is less than the range, apply damage
            if(distanceToEnemy < range){
                enemy.GetComponent<Enemy>().TakeDamage(damage);
            }
        }
        Destroy(RadialBurst, 1f);
    }

    public static void DoubleShot(Transform turret, GameObject bulletPrefab, Vector3 firePointPos, Quaternion firePointRot){
        //searches all objects with the tag "Enemy"
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        //set the initial distance to infinite
        float shortestDistance = Mathf.Infinity;
        //initialy there is no nearest enemy
        GameObject[] nearestEnemy = null;
        foreach(GameObject enemy in enemies){
            //gets the distance between the enemy
            float distanceToEnemy = Vector2.Distance(turret.position, enemy.transform.position);
            //if the distance is the sortest distance, it will update and set the enemy as the nearest
            if(distanceToEnemy < shortestDistance){
                nearestEnemy[0] = enemy;
            }
            if(distanceToEnemy < shortestDistance && enemy != nearestEnemy[0]){
                shortestDistance = distanceToEnemy;
                nearestEnemy[1] = enemy;
            }
            Shoot(nearestEnemy[0].transform, bulletPrefab, firePointPos, firePointRot);
            Shoot(nearestEnemy[1].transform, bulletPrefab, firePointPos, firePointRot);
        }
    }

    public static void PiercingShot(){
        //searches all objects with the tag "Enemy"
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
    }

    // public static void DamageOverTime(float damage, float duration, float rate, Transform target){
    //     GameObject DOT = GameObject.Instantiate(dotPrefab, target.position, target.rotation);
    // }
}

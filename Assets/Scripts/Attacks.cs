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

    public static void Melee(){
        //searches all objects with the tag "Enemy"
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
    }

    public static void MultipleShot(){
        //searches all objects with the tag "Enemy"
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
    }

    public static void PiercingShot(){
        //searches all objects with the tag "Enemy"
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
    }
}

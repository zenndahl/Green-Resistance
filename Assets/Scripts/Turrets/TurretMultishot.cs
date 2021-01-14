using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretMultishot : Turret
{
    private int i = 0;
    public Transform[] targets;
    public int numberOfShots;
    bool waitActive = false; //so wait function wouldn't be called many times per frame
 
    IEnumerator Wait(){
        waitActive = true;
        yield return new WaitForSeconds (fireRate);
        waitActive = false;
    }
    // Start is called before the first frame update
    protected override void Start(){
        //initiate a rotine to call the method for an amount of times 
        InvokeRepeating("GetTargets", 0f, 0.5f);
        inRange = false;
    }

    public void GetTargets(){
        //searches all objects with the tag "Enemy"
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);

        //get the enemies in range untill the number of enemies the turret can target
        foreach(GameObject enemy in enemies){
            float distanceToEnemy = Vector2.Distance(transform.position, enemy.transform.position);
            if(distanceToEnemy <= range){
                targets[i++] = enemy.transform;
                Debug.Log("Alvo adquirido");
                inRange = true;
                if(i >= numberOfShots) return; //when the number of targets is reached it stops
            }
        }
        inRange = false;
    }

    public override void Attack(){
        Debug.Log("Atacando");
        foreach (Transform target in targets){
            Attacks.Shoot(target, bulletPrefab, firePoint.position, firePoint.rotation, atkDamage);
            //wait for the fire rate untill next shot
            if(!waitActive){
                StartCoroutine(Wait());
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretMultishot : Turret
{
    public List<GameObject> targets;
    public int numberOfShots;

    // Start is called before the first frame update
    protected override void Start(){
        //initiate a rotine to call the method for an amount of times 
        //InvokeRepeating("GetTargets", 0f, 0.5f);
        inRange = false;
    }

    // Update is called once per frame
    protected override void Update()
    {          
        //if no enemy in range, does nothing
        if(!inRange){
            isAttacking = false;
            return;
        }

        //fire only at a determined rate
        if(shootCooldown <= 0f){
            //searches all objects with the tag "Enemy"
            GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);

            foreach (GameObject enemy in enemies){
                //gets the distance between the enemy
                float distanceToEnemy = Vector2.Distance(transform.position, enemy.transform.position);
                if(distanceToEnemy < range){
                    Attack();
                    Debug.Log("Atacando");
                    isAttacking = true;
                    shootCooldown = 1f /fireRate;
                }
            }
        }
        //decreases with time
        shootCooldown -= Time.deltaTime;
    }

    public override void Attack(){
        Debug.Log("Atacando");
        foreach (GameObject target in targets){
            if(target == null){
                targets.Remove(target);
                return;
            }
            Attacks.Shoot(target.transform, bulletPrefab, firePoint.position, firePoint.rotation, atkDamage);
            //wait for the fire rate untill next shot
        }
        targets.Clear();
    }
}

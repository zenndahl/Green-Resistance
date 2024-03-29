using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Empresario : Boss
{
    //this script will select the sprite for the prefab from a list

    public GameObject bulletPrefab;
    public string enemyTag = "Turret";
    public Transform target;
    public Transform firePoint;

    [Header("AttackStats")]
    public float range;
    public float fireRate;
    public float shootCooldown = 2f;
    public float stopTime;
    public bool inRange;
    public bool isAttacking;

    void Awake(){
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
            if(enemy.transform == null) return;
            //gets the distance between the enemy
            float distanceToEnemy = Vector2.Distance(transform.position, enemy.transform.position);
            Debug.Log("Aqui 1");
            //if the distance is the sortest distance, it will update and set the enemy as the nearest
            if(distanceToEnemy < shortestDistance){
                Debug.Log("Aqui 2");
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
                inRange = true;
            }
        }

        //set the target as the enemy selected as the nearest
        if(nearestEnemy != null && shortestDistance <= range){
            Debug.Log("Aqui 3");
            target = nearestEnemy.transform;
            return;
        }
        inRange = false;
    }

    // Update is called once per frame
    protected override void Update()
    {
        //move in the direction of the next waypoint
        Vector2 dir = direction.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);   

        //if it reaches the waypoint, get the next
        if(Vector2.Distance(transform.position, direction.position) <= 0.01f){
            GetNextWaypoint();
        }

        //if no enemy in range, does nothing
        if(!inRange){
            return;
        }

        //fire only at a determined rate
        if(shootCooldown <= 0f){
            Attack();
            shootCooldown = 1f/fireRate;
        }
        //decreases with time
        shootCooldown -= Time.deltaTime;
        
    }
    
    public void Attack(){
        StartCoroutine(StopToAttack());
        Attacks.Shoot(target, bulletPrefab, firePoint.position, firePoint.rotation, 9999);
    }

    IEnumerator StopToAttack(){
        speed = 0;
        yield return new WaitForSeconds(stopTime);
        speed = EnemyStats.instance.GetSpeed(typeName);
    }

    private void OnDrawGizmosSelected() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}

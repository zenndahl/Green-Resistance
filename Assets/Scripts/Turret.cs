using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    [Header("Enemy Setup")]
    public Transform target;
    
    public string enemyTag = "Enemy";

    [Header("Turret Stats")]

    public float range = 15f;

    public int fireRate = 1;
    public float shootCooldown = 0.5f;

    public float turnSpeed = 10;

    [Header("Turret Setup")]

    public Transform partToRotate;

    public GameObject bulletPrefab;
    public Transform firePoint;

    // Start is called before the first frame update
    void Start()
    {
        //initiate a rotine to call the method for an amount of times 
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
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
            }
        }

        //set the target as the enemy selected as the nearest
        if(nearestEnemy != null && shortestDistance <= range){
            target = nearestEnemy.transform;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //if no enemy in range, does nothing
        if(target == null){
            return;
        }

        //will make the turret point in the direction of the target
        LockOnTarget();

        //fire only at a determined rate
        if(shootCooldown <= 0f){
            Shoot();
            shootCooldown = 1f /fireRate;
        }
        shootCooldown -= Time.deltaTime;
    }

    public void Shoot(){
        //creates the bullet object on scene
        GameObject bulletGO = (GameObject)Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

        //get the bullet component to access its variables and methods
        Bullet bullet = bulletGO.GetComponent<Bullet>();

        //determines the target for the bullet instantiated above
        if(bullet != null){
            bullet.Seek(target);
        }
    }

    void LockOnTarget(){
        //target lock on
        Vector2 dir = target.position - transform.position;
    }
 }

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
    public bool isRanged;
    //set if there are modifiers and if it is for more or for less
    public int rangeModStatus;
    public int fireRateModStatus;
    public int healthModStatus;

    [Header("Ranged Settings")]
    public GameObject bulletPrefab;

    [Header("Burst Settings")]
    public GameObject burstEffect;

    private void Awake() {
        //when the turret is instantiated, it is given its stats
        SetStats();
    }

    // Start is called before the first frame update
    protected virtual void Start(){
        //initiate a rotine to call the method for an amount of times 
        InvokeRepeating("EnemyInRange", 0f, 0.5f);
        inRange = false;
    }

    public void SetStats(){
        //setting range
        if(rangeModStatus == 1){
            range = Attacks.baseRange + Attacks.rangeMod;
        }
        else if(rangeModStatus == -1){
            range = Attacks.baseRange - Attacks.rangeMod;
        }
        else{
            range = Attacks.baseRange;
        }

        //setting fire rate
        if(fireRateModStatus == 1){
            fireRate = Attacks.baseFireRate + Attacks.fireRateMod;
        }
        else if(fireRateModStatus == -1){
            fireRate = Attacks.baseFireRate - Attacks.fireRateMod;
        }
        else{
            fireRate = Attacks.baseFireRate;
        }

        //setting health
        if(healthModStatus == 1){
            health = Attacks.baseFireRate + Attacks.healthMod;
        }
        else if(healthModStatus == -1){
            health = Attacks.baseHealth - Attacks.healthMod;
        }
        else{
            health = Attacks.baseHealth;
        }
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

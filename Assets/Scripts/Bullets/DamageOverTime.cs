using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageOverTime : EnemyShot
{
    public float dotDamage;
    public float dotDuration;
    public bool notStack;

    private bool isEnemy = false;
    private bool isTurret = false;

    //set to dot state so the damage does not stack
    private void OnTriggerEnter2D(Collider2D other){
        
        //check if the target is already under dot effect and cancels the onDestroy method
        if(other.gameObject.tag == "Enemy"){
            isEnemy = true;
            Enemy enemy = target.GetComponent<Enemy>();
            if(enemy.inDOT){
                notStack = true;
                Destroy(gameObject);
                return;
            }
            enemy.inDOT = true;
        }
        else if(other.gameObject.tag == "Turret"){
            isTurret = true;
            Turret turret = target.GetComponent<Turret>();
            if(turret.inDOT){
                notStack = true;
                Destroy(gameObject);
                return;
            }
            turret.inDOT = true;
        }

        //destroy the object after the determined time and ends the dot effect
        Destroy(gameObject, dotDuration);
    }

    private void OnTriggerStay2D(Collider2D other){
        //check if its an enemy or a turret and adresses the damage to the right object
        if(target == null) return;
        if(other.gameObject.tag == "Enemy"){
            Enemy enemy = target.GetComponent<Enemy>();
            enemy.TakeDamage(dotDamage);
        }
        else if(other.gameObject.tag == "Turret"){
            Turret turret = target.GetComponent<Turret>();
            turret.TakeDamage(dotDamage);
        }
    }

    private void OnDestroy(){
        //if the target is already under dot effect, the target inDOT will not be set as false
        if(notStack) return;
        //set back to the not receiving dot state
        if(isEnemy){
            Enemy enemy = target.GetComponent<Enemy>();
            enemy.inDOT = false;
        }
        else if(isTurret){
            Turret turret = target.GetComponent<Turret>();
            turret.inDOT = false;
        }
    }

    
}

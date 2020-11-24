using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[System.Serializable]
public class TurretBurst : Turret
{
    protected override void Start(){
        //initiate a rotine to call the method for an amount of times 
        InvokeRepeating("EnemyInRange", 0f, 0.5f);
        inRange = false;
    }
    public override void Attack(){
        Attacks.Burst(burstEffect, firePoint.position,  firePoint.rotation, range, damage);
    } 
}

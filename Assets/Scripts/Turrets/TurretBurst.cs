using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[System.Serializable]
public class TurretBurst : Turret
{
    [Header("Burst Settings")]
    public GameObject burstEffect;
    
    public override void Attack(){
        Attacks.Burst(burstEffect, firePoint.position,  firePoint.rotation, range, atkDamage);
    } 
}

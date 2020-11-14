using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Ranged_Turret : Turret{
    
    public override void Attack(){
        attacks.Shoot(target, bulletPrefab, firePoint.position, firePoint.rotation);
    }
    
}

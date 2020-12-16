using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretDoubleshot : Turret
{
    public override void Attack(){

        Attacks.Shoot(target, bulletPrefab, firePoint.position, firePoint.rotation);
    }
}

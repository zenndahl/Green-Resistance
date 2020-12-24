using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShot : Bullet
{
    //this function will change to apply damage on life instead of simply destroing the target
    public override void Damage(){
        //subtract life from enemy
        //apply any on-hit effect
        Turret turret = target.GetComponent<Turret>();
        turret.TakeDamage(damage);
        Destroy(gameObject);
    }
}

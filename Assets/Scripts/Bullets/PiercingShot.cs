using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PiercingShot : Bullet
{
    public override void Damage(){
        Enemy enemy = target.GetComponent<Enemy>();
        Attacks.PiercingShot();
        Destroy(gameObject);
    }
}

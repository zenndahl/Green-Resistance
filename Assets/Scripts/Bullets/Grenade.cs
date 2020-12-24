using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Grenade : Bullet
{
    public GameObject burstEffect;
    public float range;

    public override void Damage(){
        Enemy enemy = target.GetComponent<Enemy>();
        Attacks.Burst(burstEffect, transform.position, transform.rotation, range, damage);
        Destroy(gameObject);
    }

    // private void OnDrawGizmosSelected() {
    //     Gizmos.color = Color.red;
    //     Gizmos.DrawWireSphere(transform.position, range);
    // }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trator : Boss
{
    private void OnTriggerEnter2D(Collider2D other){
        Debug.Log(other);
        if(other.gameObject.tag != "Turret") return;
        Turret turret = other.gameObject.GetComponent<Turret>();
        turret.TakeDamage(10000);
    }
}

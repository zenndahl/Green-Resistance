using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trator : Boss
{
    private void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.tag != "Turret"){
            return;
        } 
        Debug.Log(other.gameObject.tag + " passou");
        Turret turret = other.gameObject.GetComponent<Turret>();
        turret.TakeDamage(10000);
    }
}

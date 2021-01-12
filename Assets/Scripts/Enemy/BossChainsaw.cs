using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossChainsaw : Boss
{
    private void Awake() {
        InvokeRepeating("CheckIfSawing", 0f, 0.5f);
    }

    void CheckIfSawing(){
        if(this.GetComponent<Turret>().isAttacking){
            speed = 0;
            return;
        }
        speed = initSpeed;
        return;
    }
}

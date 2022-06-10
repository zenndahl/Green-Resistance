using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowShot : Bullet
{
    private static float slowMod = 0.5f;
    private static float slowTotal = 1f;
    private static float slowTime;
    private bool damageDone = false;

    public override void Damage(){
        if(target == null) return;
        Enemy enemy = target.GetComponent<Enemy>();
        if(!damageDone){
            enemy.TakeDamage(damage);
        }
        damageDone = true;
        Destroy(gameObject, slowTotal);
    }

    private void OnTriggerStay2D(Collider2D other) {
        //spriteRenderer.enabled = false;
        if(target == null) return;
        Enemy enemy = target.GetComponent<Enemy>();
        enemy.speed = (EnemyStats.instance.GetSpeed(enemy.typeName) * slowMod);
        //this.GetComponent<SpriteRenderer>().sortingLayerName = "Turret";
    }

    private void OnDestroy() {
        if(target == null) return;
        Enemy enemy = target.GetComponent<Enemy>();
        enemy.speed = EnemyStats.instance.GetSpeed(enemy.typeName);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmpresarioShot : Bullet
{
    private Node node;
    public GameObject buildingPrefab;

    public override void Damage(){
        Turret turret = target.GetComponent<Turret>();
        turret.TakeDamage(damage);
        Build(turret);
        Destroy(gameObject);
    }

    void Build(Turret turret){
        node = turret.node;
        node.BuildBuilding(buildingPrefab);
    }
}

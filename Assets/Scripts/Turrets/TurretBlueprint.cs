using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable] //mark a non-MonoBehaviour class to show in the Inspector
public class TurretBlueprint {  
    public bool hasUpgrade;

    [Header("Prefabs")]
    public GameObject prefab;
    public int cost;

    public GameObject upgrade1Prefab;
    public int upgradeCost;

    public GameObject upgrade2Prefab;
    public int upgrade2Cost;

    private Turret turret;

    public GameObject GetPrefab(GameObject _turret = null){
        if(turret != null) turret = _turret.GetComponent<Turret>();

        if(_turret == null){
            return prefab;
        }
        else if(turret.wichUpgrade == 0){
            return upgrade1Prefab;
        }
        else if(turret.wichUpgrade == 1){
            return upgrade2Prefab;
        }
        return null;
    }

    public int GetSellAmount(GameObject _turret){
        turret = _turret.GetComponent<Turret>();

        if(turret.wichUpgrade == 0){
            return cost/2;
        }
        else if(turret.wichUpgrade == 1){
            return upgradeCost/2;
        }
        else if(turret.wichUpgrade == 2){
            return upgrade2Cost/2;
        }
        return 0;
    }
}

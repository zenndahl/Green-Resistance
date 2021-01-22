using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable] //mark a non-MonoBehaviour class to show in the Inspector
public class TurretBlueprint {  
    public bool hasUpgrade;
    public int wichUpgrade = 0;

    [Header("Prefabs")]
    public GameObject prefab;
    public int cost;

    public GameObject upgrade1Prefab;
    public int upgradeCost;

    public GameObject upgrade2Prefab;
    public int upgrade2Cost;

    public GameObject GetPrefab(){
        if(wichUpgrade == 0){
        return prefab;
        }
        if(wichUpgrade == 1){
            return upgrade1Prefab;
        }
        if(wichUpgrade == 2){
            return upgrade2Prefab;
        }
        return null;
    }

    public int GetSellAmount(){
        if(wichUpgrade == 0){
        return cost/2;
        }
        else if(wichUpgrade == 1){
            return upgradeCost/2;
        }
        else if(wichUpgrade == 2){
            return upgrade2Cost/2;
        }
        return 0;
    }
}

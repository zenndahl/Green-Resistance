using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable] //mark a non-MonoBehaviour class to show in the Inspector
public class TurretBlueprint {  
    public bool hasUpgrade;

    [Header("Prefabs")]
    public GameObject prefab;
    public GameObject upgrade1Prefab;
    public GameObject upgrade2Prefab;

    public bool[] upgrades_1 = new bool[3];
    public bool[] upgrades_2 = new bool[3];

    private Turret turret;

    public GameObject GetPrefab(int upNum){
        if(upNum == 1) return upgrade1Prefab;
        else return upgrade2Prefab;
        
    }
}

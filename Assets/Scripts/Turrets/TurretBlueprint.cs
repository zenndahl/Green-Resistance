using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable] //mark a non-MonoBehaviour class to show in the Inspector
public class TurretBlueprint {  
    public bool hasUpgrade;

    [Header("Prefabs")]
    public int cost;
    public int upgradeCost;

    public int sellPrice => (upgradeCost > 2 * cost) ? upgradeCost/2 : cost/2;
    public GameObject prefab;
    public GameObject upgrade1Prefab;

    public GameObject upgrade2Prefab;
    public bool[] upgrades_1 = new bool[3];
    public bool[] upgrades_2 = new bool[3];
    // public bool upgradeDamage;
    // public bool upgradeFireRate;
    // public bool upgradeRange;

    private Turret turret;

    public void SetUpgradeCost(){
        upgradeCost = 3 * cost;
    }
}

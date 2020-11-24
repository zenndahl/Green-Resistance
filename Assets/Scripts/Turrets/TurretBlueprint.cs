using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable] //mark a non-MonoBehaviour class to show in the Inspector
public class TurretBlueprint {    
    [Header("Prefabs")]
    public GameObject prefab;
    public int cost;

    public GameObject upgrade1_Prefab;
    public int upgradeCost;

    public GameObject upgrade2_Prefab;
    public int upgrade2_Cost;

    public int GetSellAmount(){
        return cost/2;
    }
}

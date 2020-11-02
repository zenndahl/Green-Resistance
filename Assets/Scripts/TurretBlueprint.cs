using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable] //mark a non-MonoBehaviour class to show in the Inspector
public class TurretBlueprint 
{
    [Header("Stats")]
    public float health = 100f;
    public float damage = 50f;
    public float range = 12f;
    public float fireRate = 1;

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

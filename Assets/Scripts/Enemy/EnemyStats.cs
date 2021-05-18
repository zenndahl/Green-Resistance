using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    public static EnemyStats instance;
    [Header("Farmer")]
    public static float initFarmerHealth = 50f;
    public static float upgradeFarmerHealth = 50f;
    public static float initFarmerSpeed = 1f;

    [Header("Heavy")]
    public static float initHeavyHealth = 100f;
    public static float upgradeHeavyHealth = 100f;
    public static float initHeavySpeed = 0.5f;

    [Header("DogMaster")]
    public static float initDogMasterHealth = 100f;
    public static float upgradeDogMasterHealth = 50f;
    public static float initDogMasterSpeed = 0.7f;

    [Header("Lumberjack")]
    public static float initLumberjackHealth = 100f;
    public static float upgradeLumberjackHealth = 100f;
    public static float initLumberjackSpeed = 1f;
    
    [Header("Dog")]
    public static float initDogHealth = 25f;
    public static float upgradeDogHealth = 25f;
    public static float initDogSpeed = 1.5f;

    private void Awake() {
        instance = this;
    }

    public static float GetHealth(string type){
        if(type == "Farmer"){
            return initFarmerHealth;
        }
        if(type == "Heavy"){
            return initHeavyHealth;
        }
        if(type == "DogMaster"){
            return initDogMasterHealth;
        }
        if(type == "Lumberjack"){
            return initLumberjackHealth;
        }
        if(type == "Dog"){
            return initDogHealth;
        }
        else{
            return 100;
        }
    }

    public static float GetSpeed(string type){
        if(type == "Farmer"){
            return initFarmerSpeed;
        }
        if(type == "Heavy"){
            return initHeavySpeed;
        }
        if(type == "DogMaster"){
            return initDogMasterSpeed;
        }
        if(type == "Lumberjack"){
            return initLumberjackSpeed;
        }
        if(type == "Dog"){
            return initDogSpeed;
        }
        else{
            return 1;
        }
    }

    public static void UpgradeHealth(){
        initFarmerHealth += upgradeFarmerHealth;
        initHeavyHealth += upgradeHeavyHealth;
        initDogMasterHealth += upgradeDogMasterHealth;
        initLumberjackHealth += upgradeLumberjackHealth;
        initDogHealth += upgradeDogHealth;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    public static EnemyStats instance;

    //TODO MAKE THIS AN SCRIPTABLE OBJECT

    [Header("Farmer")]
    public float initFarmerHealth = 50f;
    public float upgradeFarmerHealth = 50f;
    public float initFarmerSpeed = 1f;

    [Header("Heavy")]
    public float initHeavyHealth = 100f;
    public float upgradeHeavyHealth = 100f;
    public float initHeavySpeed = 0.5f;

    [Header("DogMaster")]
    public float initDogMasterHealth = 100f;
    public float upgradeDogMasterHealth = 50f;
    public float initDogMasterSpeed = 0.7f;

    [Header("Lumberjack")]
    public float initLumberjackHealth = 100f;
    public float upgradeLumberjackHealth = 100f;
    public float initLumberjackSpeed = 1f;
    
    [Header("Dog")]
    public float initDogHealth = 25f;
    public float upgradeDogHealth = 25f;
    public float initDogSpeed = 1.5f;

    private void Awake() {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public float GetHealth(string type){
        if(type == "Farmer"){
            return instance.initFarmerHealth;
        }
        if(type == "Heavy"){
            return instance.initHeavyHealth;
        }
        if(type == "DogMaster"){
            return instance.initDogMasterHealth;
        }
        if(type == "Lumberjack"){
            return instance.initLumberjackHealth;
        }
        if(type == "Dog"){
            return instance.initDogHealth;
        }
        else{
            return 100;
        }
    }

    public float GetSpeed(string type){
        if(type == "Farmer"){
            return instance.initFarmerSpeed;
        }
        if(type == "Heavy"){
            return instance.initHeavySpeed;
        }
        if(type == "DogMaster"){
            return instance.initDogMasterSpeed;
        }
        if(type == "Lumberjack"){
            return instance.initLumberjackSpeed;
        }
        if(type == "Dog"){
            return instance.initDogSpeed;
        }
        else{
            return 1;
        }
    }

    public void UpgradeHealth(){
        instance.initFarmerHealth += upgradeFarmerHealth;
        instance.initHeavyHealth += upgradeHeavyHealth;
        instance.initDogMasterHealth += upgradeDogMasterHealth;
        instance.initLumberjackHealth += upgradeLumberjackHealth;
        instance.initDogHealth += upgradeDogHealth;
    }
}

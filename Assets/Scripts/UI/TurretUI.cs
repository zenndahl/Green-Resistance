using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurretUI : MonoBehaviour
{
    private static Node target;
    private BuildManager buildManager;
    public Text damageUI;
    public Text fireRateUI;
    public Text rangeUI;
    public GameObject upgradeDamageUI;
    public GameObject upgradeRangeUI;
    public GameObject upgradeFireRateUI;
    public Text name_1;
    public Text name_2;
    public Text upgradeCost;
    public Button upgradeButton;
    public Text sellAmount;

    private void Start() {
        buildManager = BuildManager.instance;
    }

    public void SetTurretUI(Node _target){
        target = _target;
        Turret turret = target.turret.GetComponent<Turret>();

        //TurretStats from the present tower
        name_2.text = turret.turretName;
        damageUI.text = "Damage: " + turret.atkDamage.ToString();
        fireRateUI.text = "Fire Rate: " + turret.fireRate.ToString();
        rangeUI.text = "Range: " + turret.range.ToString();

        sellAmount.text = target.turret.GetComponent<Turret>().sellPrice.ToString();

        if(!target.turretBlueprint.hasUpgrade){
            upgradeCost.text = "No Máximo!";
            upgradeButton.interactable = false;
            return;
        }
        if(target.turret.GetComponent<Turret>().wichUpgrade < 2){
            upgradeCost.text = "R$" + target.turret.GetComponent<Turret>().upgradeCost.ToString();
            upgradeButton.interactable = true;
        }
        else{ 
            upgradeCost.text = "No Máximo!";
            upgradeButton.interactable = false;
        }
        
        //TurretUpgradeStats from the upgrade prefab
        name_1.text = turret.turretName;
        if(target.turret.GetComponent<Turret>().wichUpgrade == 0){
            if(target.turretBlueprint.upgrades_1[0]){
                upgradeDamageUI.SetActive(true);
            }
            if(target.turretBlueprint.upgrades_1[1]){
                upgradeFireRateUI.SetActive(true);
            }
            if(target.turretBlueprint.upgrades_1[2]){
                upgradeRangeUI.SetActive(true);
            }
        }
        else if(target.turret.GetComponent<Turret>().wichUpgrade == 1){
            if(target.turretBlueprint.upgrades_2[0]){
                upgradeDamageUI.SetActive(true);
            }
            if(target.turretBlueprint.upgrades_2[1]){
                upgradeFireRateUI.SetActive(true);
            }
            if(target.turretBlueprint.upgrades_2[2]){
                upgradeRangeUI.SetActive(true);
            }
        }
    }

    public void Upgrade(){
        target.UpgradeTurret();
        buildManager.DeselectNode();
        //not using the function Hide because the node would still be selected
    }

    public void Sell(){
        target.SellTurret();
        buildManager.DeselectNode();
    }
}

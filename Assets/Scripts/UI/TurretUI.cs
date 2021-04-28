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
        if(target.turret.GetComponent<Turret>().wichUpgrade < 2){
            upgradeCost.text = "R$" + target.turretBlueprint.upgradeCost.ToString();
            upgradeButton.interactable = true;
        }
        else{ 
            upgradeCost.text = "No Máximo!";
            upgradeButton.interactable = false;
        }

        //TurretStats from the present tower
        name_2.text = turret.turretName;
        damageUI.text = "Damage: " + turret.atkDamage.ToString();
        fireRateUI.text = "Fire Rate: " + turret.fireRate.ToString();
        rangeUI.text = "Range: " + turret.range.ToString();

        //TurretUpgradeStats from the upgrade prefab
        name_1.text = turret.turretName;
        if(target.turretBlueprint.upgradeDamage){
            upgradeDamageUI.SetActive(true);
        }
        if(target.turretBlueprint.upgradeFireRate){
            upgradeFireRateUI.SetActive(true);
        }
        if(target.turretBlueprint.upgradeRange){
            upgradeRangeUI.SetActive(true);
        }

        //sellAmount.text = "R$" + target.turretBlueprint.GetSellAmount(turret).ToString();
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

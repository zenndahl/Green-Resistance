using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurretUI : MonoBehaviour
{
    private static Node target;
    private BuildManager buildManager;
    public Text upgradeCost;
    public Button upgradeButton;
    public Text sellAmount;

    private void Start() {
        buildManager = BuildManager.instance;
    }

    public void SetTurretUI(Node _target){
        target = _target;
        if(target.turret.GetComponent<Turret>().wichUpgrade < 2){
            upgradeCost.text = "R$" + target.turretBlueprint.upgradeCost.ToString();
            upgradeButton.interactable = true;
        }
        else{ 
            upgradeCost.text = "No Máximo!";
            upgradeButton.interactable = false;
        }

        sellAmount.text = "R$" + target.turretBlueprint.GetSellAmount(target.turret).ToString();
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

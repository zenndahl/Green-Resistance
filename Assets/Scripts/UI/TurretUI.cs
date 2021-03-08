using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurretUI : MonoBehaviour
{
    private  Node target;
    public GameObject ui;

    public Text upgradeCost;
    public Button upgradeButton;

    public Text sellAmount;

    

    public void SetTurretUI(Node target){
        if(target.turretBlueprint.wichUpgrade < 2){
            upgradeCost.text = "R$" + target.turretBlueprint.upgradeCost;
            upgradeButton.interactable = true;
        }
        else{ 
            upgradeCost.text = "No Máximo!";
            upgradeButton.interactable = false;
        }

        sellAmount.text = "R$" + target.turretBlueprint.GetSellAmount();
        ui.SetActive(true);
    }

    public void Show(){
        ui.SetActive(true);
    }

    public void Hide(){
        ui.SetActive(false);
    }

    public void Upgrade(){
        target.UpgradeTurret();
        BuildManager.instance.DeselectNode();
        //not using the function Hide because the node would still be selected
    }

    public void Sell(){
        target.SellTurret();
        BuildManager.instance.DeselectNode();
    }
}

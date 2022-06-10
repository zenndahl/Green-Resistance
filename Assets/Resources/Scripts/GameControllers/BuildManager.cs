using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    //singleton pattern
    public static BuildManager instance;

    //turretUI settings
    private TurretUI TUI;
    public GameObject turretUI;

    //there will be only one instance of the build manager
    private void Awake() {
        instance = this;
        TUI = turretUI.GetComponent<TurretUI>();
    }

    private TurretBlueprint turretToBuild;
    private Node selectedNode;

    public void SelectNode(Node node){

        if(selectedNode == node){
            DeselectNode();
            return;
        }

        selectedNode = node;
        turretToBuild = null;

        TUI.SetTurretUI(selectedNode);
        turretUI.SetActive(true);
    }

    public void SelectTurretToBuild(TurretBlueprint turret){
        turretToBuild = turret;
        selectedNode = null;
        turretUI.SetActive(false);
    }

    public void DeselectNode(){
        selectedNode = null;
        turretUI.SetActive(false);
    }

    public TurretBlueprint GetTurretToBuild(){
        return turretToBuild;
    }

    //check if there is a turret selected to build
    public bool CanBuild{get{return turretToBuild != null;}}

    //check if there is enough money to purschase selected turret
    public bool HasMoney{get{return PlayerStats.money >= turretToBuild.prefab.GetComponent<Turret>().cost;}}
}

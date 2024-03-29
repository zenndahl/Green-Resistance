﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{
    [Header("Setup")]
    public BuildManager buildManager;
    //public Vector3 posOffset;
    public bool hasBuff = false;

    [Header("Node Highlights")]
    //sprites (each level will have theirs sprites)
    public Sprite highlightGreen;
    public Sprite highlightRed;
    public Sprite startSprite;

    [HideInInspector]
    public GameObject turret;
    [HideInInspector]
    public bool build = true;

    [HideInInspector]
    public TurretBlueprint turretBlueprint;

    protected SpriteRenderer rend;

    private void Start() {
        //get the sprite renderer of the node
        rend = GetComponent<SpriteRenderer>();

        //intantiate the build manager to allow the turret building
        buildManager = BuildManager.instance;
        //set the base sprite as the start sprite in the build manager
        startSprite = rend.sprite;
    }

    private void OnMouseEnter() {
        //verify if the mouse is over an UI element or another GameObject and prevents missclicks
        if(EventSystem.current.IsPointerOverGameObject()){
            return;
        }

        //verify if the turret object is null, preventing the hover effect to occurr if it is 
        if(!buildManager.CanBuild){
            return;
        }

        //apply the hover effect
        if(buildManager.HasMoney){
            rend.sprite = highlightGreen;
        }
        else{
            rend.sprite = highlightRed;
        }
    }

    //remove the hover effect after the mouse is off the node
    private void OnMouseExit() {
        rend.sprite = startSprite;
    }

    private void OnMouseDown() {

        //verify if the mouse is over an UI element or another GameObject and prevents missclicks
        if(EventSystem.current.IsPointerOverGameObject()){
            return;
        }

        //in case there is already a turret on the node and another is to be built, preventing the new build
        if(turret != null){
            buildManager.SelectNode(this);
            return;
        }

        //verify if the turret object is null, blocking the building if it is
        if(!buildManager.CanBuild){
            return;
        }

        if(build == true){
            //building the turret above the node if there is no building or turret 
            BuildTurret(buildManager.GetTurretToBuild());
        }
        
    }

    //receives the blueprint with the prefab and cost of the turret to build
    void BuildTurret(TurretBlueprint blueprint){
        
        //if the money is not enough, return
        if(PlayerStats.money < blueprint.prefab.GetComponent<Turret>().cost){
            return;
            //usar um evento para quando não tiver dinheiro?
        }

        //subtracts player money by the turret cost
        PlayerStats.money -= blueprint.prefab.GetComponent<Turret>().cost;

        //usar evento para a construção da turret?
        //instantiate the turret and set the node references for the turret and the blueprint used
        GameObject _turret = (GameObject)Instantiate(blueprint.prefab, GetBuildPosition(blueprint.prefab), Quaternion.identity);
        turret = _turret;
        turretBlueprint = blueprint;

        //makes the turret a child of the node, so it can move with it in special cases
        turret.transform.parent = this.transform;

        //if the turret is buffed by a node or support plant
        if(hasBuff){
            Buff();
        }

        //attributes the node to the turret
        turret.GetComponent<Turret>().node = this;

        //GameObject effect = (GameObject)Instantiate(buildManager.buildEffect, GetBuildPosition(blueprint.prefab), Quaternion.identity);
        //Destroy(effect, 5f);
    }

    public void BuildBuilding(GameObject building){
        GameObject _building = (GameObject)Instantiate(building, GetBuildPosition(building), Quaternion.identity);
        turret = _building;
        //animation for the building spawn
    }

    //will be used by special nodes
    protected virtual void Buff(){
        return;
    }

    //REVISAR SISTEMA DE UPGRADE
    //called when the upgrade button on the UI is pressed
    public void UpgradeTurret(){
        GameObject _turret;

        if(turret.GetComponent<Turret>().wichUpgrade == 0){
            //if not enough money, dont do the upgrade
            if(PlayerStats.money < turretBlueprint.upgrade1Prefab.GetComponent<Turret>().cost){
                return;
            }
            //building the upgraded turret
            _turret = (GameObject)Instantiate(turretBlueprint.upgrade1Prefab, GetBuildPosition(turretBlueprint.upgrade1Prefab), Quaternion.identity);
            //if there is enough money, it is subtracted by the upgrade cost
            PlayerStats.money -= turretBlueprint.upgrade1Prefab.GetComponent<Turret>().cost;
        }
        else{
            //if not enough money, dont do the upgrade
            if(PlayerStats.money < turretBlueprint.upgrade2Prefab.GetComponent<Turret>().cost){
                return;
            }
            _turret = (GameObject)Instantiate(turretBlueprint.upgrade2Prefab, GetBuildPosition(turretBlueprint.upgrade2Prefab), Quaternion.identity);
            PlayerStats.money -= turretBlueprint.upgrade2Prefab.GetComponent<Turret>().cost;
        }

        //destroy the old turret
        Destroy(turret);
        
        turret = _turret;
        //here, the blueprint is the same, so there is no need for a new attribution

        //makes the turret a child of the node, so it can move with it in special cases
        turret.transform.parent = this.transform;

        //if the turret is buffed by a node or support plant
        if(hasBuff){
            Buff();
        }

        //attributes the node to the turret
        turret.GetComponent<Turret>().node = this;

        //there is a limit of 2 upgrades for the upgradable turrets, so this keeps track of it
        turret.GetComponent<Turret>().wichUpgrade++;

        // GameObject effect = (GameObject)Instantiate(buildManager.buildEffect, GetBuildPosition(), Quaternion.identity);
        // Destroy(effect, 5f);
    }

    //remove the turret from the node and get some money back
    public void SellTurret(){
        PlayerStats.money += turret.GetComponent<Turret>().sellPrice;
        Destroy(turret);
        turretBlueprint = null;
    }

    //returns the position to build the turrets, that is the pivot + the offset
    public Vector3 GetBuildPosition(GameObject _turret){
        return transform.position + _turret.GetComponent<Turret>().posOffset;
    }
}

﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{
    public BuildManager buildManager;
    public Vector3 posOffset;

    [HideInInspector]
    public GameObject turret;

    [HideInInspector]
    public TurretBlueprint turretBlueprint;

    [HideInInspector]
    public bool isUpgraded = false;

    private SpriteRenderer rend;

    private void Start() {
        //get the sprite renderer of the node
        rend = GetComponent<SpriteRenderer>();

        //intantiate the build manager to allow the turret building
        buildManager = BuildManager.instance;

        //set the base sprite as the start sprite in the build manager
        buildManager.startSprite = rend.sprite;
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
            rend.sprite = buildManager.highlightGreen; 
        }
        else{
             rend.sprite = buildManager.highlightRed; 

        }
    }

    //remove the hover effect after the mouse is off the node
    private void OnMouseExit() {
        rend.sprite = buildManager.startSprite;
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

        //building the turret above the node
        BuildTurret(buildManager.GetTurretToBuild());
    }

    void BuildTurret(TurretBlueprint blueprint){
        
        if(PlayerStats.Money < blueprint.cost){
            return;
        }

        PlayerStats.Money -= blueprint.cost;

        GameObject _turret = (GameObject)Instantiate(blueprint.prefab, GetBuildPosition(), Quaternion.identity);
        turret = _turret;

        turretBlueprint = blueprint;

        //GameObject effect = (GameObject)Instantiate(buildManager.buildEffect, GetBuildPosition(), Quaternion.identity);
        //Destroy(effect, 5f);
    }

    /*public void UpgradeTurret(){

        if(PlayerStats.Money < turretBlueprint.upgradeCost){
            return;
        }

        PlayerStats.Money -= turretBlueprint.upgradeCost;

        //destroy the old turret
        Destroy(turret);

        //building the upgraded turret
        GameObject _turret = (GameObject)Instantiate(turretBlueprint.upgradedPrefab, GetBuildPosition(), Quaternion.identity);
        turret = _turret;

        isUpgraded = true;

        // GameObject effect = (GameObject)Instantiate(buildManager.buildEffect, GetBuildPosition(), Quaternion.identity);
        // Destroy(effect, 5f);
    }*/

    public void SellTurret(){
        //PlayerStats.Money += turretBlueprint.GetSellAmount();

        Destroy(turret);
        turretBlueprint = null;
    }

    public Vector3 GetBuildPosition(){
        return transform.position + posOffset;
    }
}

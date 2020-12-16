using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{
    public BuildManager buildManager;
    public Color notEnoughMoney;
    public Vector3 posOffset;

    [HideInInspector]
    public GameObject turret;

    [HideInInspector]
    public TurretBlueprint turretBlueprint;

    [HideInInspector]
    public bool isUpgraded = false;

    private void Start() {
        //rend = GetComponent<Renderer>();
        //intantiate the build manager to allow the turret building
        buildManager = BuildManager.instance;
    }

    private void OnMouseEnter() {

        //verify if the mouse is over an UI element or another GameObject and prevents missclicks
        if(EventSystem.current.IsPointerOverGameObject()){
            return;
        }

        //find out how to highlight the node 
        
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

    public Vector3 GetBuildPosition(){
        //SpriteRenderer obj = GetComponent<SpriteRenderer>();
        //Vector3 posOffset = obj.sprite.pivot;
        //Debug.Log(posOffset);
        return transform.position + posOffset;
    }
}

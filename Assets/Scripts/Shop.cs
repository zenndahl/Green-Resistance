﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    BuildManager buildManager;
    
    [Header("Cerrado")]
    public TurretBlueprint jabuticabaTurret;
    public TurretBlueprint ipeTurret;
    public TurretBlueprint pinhaoTurret;
    public TurretBlueprint mamonaTurret;
    public TurretBlueprint coquinhoTurret;

    [Header("Sertão")]
    public TurretBlueprint mandacaruTurret;
    public TurretBlueprint bromeliaTurret;
    public TurretBlueprint cajuTurret;
    public TurretBlueprint aroeiraTurret;
    public TurretBlueprint jamboTurret;

    [Header("Praia")]
    public TurretBlueprint acaiTurret;
    public TurretBlueprint cocoTurret;
    public TurretBlueprint palmeiraTurret;
    public TurretBlueprint bananaTurret;
    public TurretBlueprint eritrinaTurret;

    [Header("Pantanal")]
    public TurretBlueprint figoTurret;
    public TurretBlueprint ipe2Turret;
    public TurretBlueprint abacaxiTurret;
    public TurretBlueprint pequiTurret;
    public TurretBlueprint tamarindoTurret;

    [Header("Amazônia")]
    public TurretBlueprint guaranaTurret;
    public TurretBlueprint castanhaTurret;
    public TurretBlueprint urucumTurret;
    public TurretBlueprint carnivoraTurret;
    public TurretBlueprint cacauTurret;

    //[Header("Fungos")]

    private void Start() {
        buildManager = BuildManager.instance;    
    }
//  _____                         _       
// /  __ \                       | |      
// | /  \/ ___ _ __ _ __ __ _  __| | ___  
// | |    / _ \ '__| '__/ _` |/ _` |/ _ \ 
// | \__/\  __/ |  | | | (_| | (_| | (_) |
//  \____/\___|_|  |_|  \__,_|\__,_|\___/ 
                                       
                                       
    //call the BuildManager to assign the Jabuticaba turret type
    public void SelectJabuticaba(){
        Debug.Log("Jabuticaba Tree-Turret Selected");
        buildManager.SelectTurretToBuild(jabuticabaTurret);
    }

    //call the BuildManager to assign the Ipê turret type
    public void SelectIpe(){
        Debug.Log("Ipê Tree-Turret Selected");
        buildManager.SelectTurretToBuild(ipeTurret);
    }

    //call the BuildManager to assign the Pinhão turret type
    public void SelectPinhao(){
        Debug.Log("Pinhão Tree-Turret Selected");
        buildManager.SelectTurretToBuild(pinhaoTurret);
    }

    //call the BuildManager to assign the Pequi turret type
    public void SelectMamona(){
        Debug.Log("Pequi Tree-Turret Selected");
        buildManager.SelectTurretToBuild(mamonaTurret);
    }

    //call the BuildManager to assign the Coquinho type
    public void SelectCoquinho(){
        Debug.Log("Coquinho Tree-Turret Selected");
        buildManager.SelectTurretToBuild(coquinhoTurret);
    }

    //   _____           _              
    // /  ___|         | |             
    // \ `--.  ___ _ __| |_ __ _  ___  
    //  `--. \/ _ \ '__| __/ _` |/ _ \ 
    // /\__/ /  __/ |  | || (_| | (_) |
    // \____/ \___|_|   \__\__,_|\___/ 

    //call the BuildManager to assign the Jabuticaba turret type
    public void SelectMandacaru(){
        Debug.Log("Mandacaru Tree-Turret Selected");
        buildManager.SelectTurretToBuild(mandacaruTurret);
    }

    //call the BuildManager to assign the Ipê turret type
    public void SelectBromelia(){
        Debug.Log("Ipê Tree-Turret Selected");
        buildManager.SelectTurretToBuild(bromeliaTurret);
    }

    //call the BuildManager to assign the Pinhão turret type
    public void SelectCaju(){
        Debug.Log("Pinhão Tree-Turret Selected");
        buildManager.SelectTurretToBuild(cajuTurret);
    }

    //call the BuildManager to assign the Pequi turret type
    public void SelectJambo(){
        Debug.Log("Pequi Tree-Turret Selected");
        buildManager.SelectTurretToBuild(jamboTurret);
    }

    //call the BuildManager to assign the Coquinho type
    public void SelectAroeira(){
        Debug.Log("Coquinho Tree-Turret Selected");
        buildManager.SelectTurretToBuild(aroeiraTurret);
    }          
}
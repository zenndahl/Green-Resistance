using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    BuildManager buildManager;
    
    public TurretBlueprint jabuticabaTurret;
    public TurretBlueprint ipeTurret;
    public TurretBlueprint pinhaoTurret;
    public TurretBlueprint pequiTurret;
    public TurretBlueprint coquinhoTurret;

    private void Start() {
        buildManager = BuildManager.instance;    
    }

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
    public void SelectPequi(){
        Debug.Log("Pequi Tree-Turret Selected");
        buildManager.SelectTurretToBuild(pequiTurret);
    }

    //call the BuildManager to assign the Coquinho type
    public void SelectCoquinho(){
        Debug.Log("Coquinho Tree-Turret Selected");
        buildManager.SelectTurretToBuild(coquinhoTurret);
    }
}
using System.Collections;
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

    [Header("Mata Atlântica")]
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

    //call the BuildManager to assign the Mandacaru turret type
    public void SelectMandacaru(){
        Debug.Log("Mandacaru Tree-Turret Selected");
        buildManager.SelectTurretToBuild(mandacaruTurret);
    }

    //call the BuildManager to assign the Bromélia turret type
    public void SelectBromelia(){
        Debug.Log("Bromélia Tree-Turret Selected");
        buildManager.SelectTurretToBuild(bromeliaTurret);
    }

    //call the BuildManager to assign the Caju turret type
    public void SelectCaju(){
        Debug.Log("Caju Tree-Turret Selected");
        buildManager.SelectTurretToBuild(cajuTurret);
    }

    //call the BuildManager to assign the Jambo turret type
    public void SelectJambo(){
        Debug.Log("Jambo Tree-Turret Selected");
        buildManager.SelectTurretToBuild(jamboTurret);
    }

    //call the BuildManager to assign the Aroeira type
    public void SelectAroeira(){
        Debug.Log("Aroeira Tree-Turret Selected");
        buildManager.SelectTurretToBuild(aroeiraTurret);
    }

    // ___  ___      _           ___  _   _             _   _           
    // |  \/  |     | |         / _ \| | | |           | | (_)          
    // | .  . | __ _| |_ __ _  / /_\ \ |_| | __ _ _ __ | |_ _  ___ __ _ 
    // | |\/| |/ _` | __/ _` | |  _  | __| |/ _` | '_ \| __| |/ __/ _` |
    // | |  | | (_| | || (_| | | | | | |_| | (_| | | | | |_| | (_| (_| |
    // \_|  |_/\__,_|\__\__,_| \_| |_/\__|_|\__,_|_| |_|\__|_|\___\__,_|

    //call the BuildManager to assign the Açaí turret type
    public void SelectAcai(){
        Debug.Log("Açaí Tree-Turret Selected");
        buildManager.SelectTurretToBuild(acaiTurret);
    }

    //call the BuildManager to assign the Coco turret type
    public void SelectCoco(){
        Debug.Log("Coco Tree-Turret Selected");
        buildManager.SelectTurretToBuild(cocoTurret);
    }

    //call the BuildManager to assign the Palmeira turret type
    public void SelectPalmeira(){
        Debug.Log("Pinhão Tree-Turret Selected");
        buildManager.SelectTurretToBuild(palmeiraTurret);
    }

    //call the BuildManager to assign the Banana turret type
    public void SelectBanana(){
        Debug.Log("Banana Tree-Turret Selected");
        buildManager.SelectTurretToBuild(bananaTurret);
    }

    //call the BuildManager to assign the Eritrina type
    public void SelectEritrina(){
        Debug.Log("Eritrina Tree-Turret Selected");
        buildManager.SelectTurretToBuild(eritrinaTurret);
    }

    // ______           _                    _ 
    // | ___ \         | |                  | |
    // | |_/ /_ _ _ __ | |_ __ _ _ __   __ _| |
    // |  __/ _` | '_ \| __/ _` | '_ \ / _` | |
    // | | | (_| | | | | || (_| | | | | (_| | |
    // \_|  \__,_|_| |_|\__\__,_|_| |_|\__,_|_|

    //call the BuildManager to assign the Figo turret type
    public void SelectFigo(){
        Debug.Log("Figo Tree-Turret Selected");
        buildManager.SelectTurretToBuild(figoTurret);
    }

    //call the BuildManager to assign the Ipe2 turret type
    public void SelectIpe2(){
        Debug.Log("Ipe2 Tree-Turret Selected");
        buildManager.SelectTurretToBuild(ipe2Turret);
    }

    //call the BuildManager to assign the Abacaxi turret type
    public void SelectAbacaxi(){
        Debug.Log("Abacaxi Tree-Turret Selected");
        buildManager.SelectTurretToBuild(abacaxiTurret);
    }

    //call the BuildManager to assign the Pequi turret type
    public void SelectPequi(){
        Debug.Log("Pequi Tree-Turret Selected");
        buildManager.SelectTurretToBuild(pequiTurret);
    }

    //call the BuildManager to assign the Tamarindo type
    public void SelectTamarindo(){
        Debug.Log("Tamarindo Tree-Turret Selected");
        buildManager.SelectTurretToBuild(tamarindoTurret);
    }

    //  ___                                 _       
    // / _ \                               (_)      
    // / /_\ \_ __ ___   __ _ _______  _ __  _  __ _ 
    // |  _  | '_ ` _ \ / _` |_  / _ \| '_ \| |/ _` |
    // | | | | | | | | | (_| |/ / (_) | | | | | (_| |
    // \_| |_/_| |_| |_|\__,_/___\___/|_| |_|_|\__,_|

    //call the BuildManager to assign the Guaraná turret type
    public void SelectGuarana(){
        Debug.Log("Guaraná Tree-Turret Selected");
        buildManager.SelectTurretToBuild(guaranaTurret);
    }

    //call the BuildManager to assign the Castanha turret type
    public void SelectCastanha(){
        Debug.Log("Castanha Tree-Turret Selected");
        buildManager.SelectTurretToBuild(castanhaTurret);
    }

    //call the BuildManager to assign the Urucum turret type
    public void SelectUrucum(){
        Debug.Log("Urucum Tree-Turret Selected");
        buildManager.SelectTurretToBuild(urucumTurret);
    }

    //call the BuildManager to assign the Canívora turret type
    public void SelectCarnivora(){
        Debug.Log("Carnívora Tree-Turret Selected");
        buildManager.SelectTurretToBuild(carnivoraTurret);
    }

    //call the BuildManager to assign the Cacau type
    public void SelectCacau(){
        Debug.Log("Cacau Tree-Turret Selected");
        buildManager.SelectTurretToBuild(cacauTurret);
    }
}
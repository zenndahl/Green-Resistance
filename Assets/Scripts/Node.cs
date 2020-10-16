using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    //public BuildManager buildManager;
    public Vector2 posOffset;

    //hover colors
    public Color hoverColor;
    public Color notEnoughMoney;

    // Start is called before the first frame update
    void Start()
    {
        //intantiate the build manager to allow the turret building
        //buildManager = BuildManager.instance;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : Enemy
{
    // Start is called before the first frame update
    protected override void Start()
    {
        //get the first waypoint
        target = Waypoints.bossPoints[0];
        speed = initSpeed;
        health = initHealth;
    }

}
﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : Enemy
{
    // Start is called before the first frame update
    protected override void Start()
    {
        //get the first waypoint
        direction = Waypoints.bossPoints[wavepointIndex];
        health = EnemyStats.instance.GetHealth(typeName);
        speed = EnemyStats.instance.GetSpeed(typeName);
    }

}

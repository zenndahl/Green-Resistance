using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Wave
{
    public Transform[] enemy;//vector of enemies that will be in the wave
    public int count; //quantity of enemies in the wave
    public float rate; //frequency of enemies spawn

}

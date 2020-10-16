using System.Collections;
using UnityEngine;

public class Waypoints : MonoBehaviour
{
    public static Transform[] points;

    //when this object is initiated it will get every child waypoint and make a list
    public void Awake() {
        points = new Transform[transform.childCount];

        for (int i = 0; i < points.Length; i++)
        {
            points[i] = transform.GetChild(i);
        }
    }
}
using System.Collections;
using UnityEngine;

public class Waypoints : MonoBehaviour
{
    public bool isBoss;
    public static Transform[] points;
    public static Transform[] bossPoints;
    private int i, j;

    //when this object is initiated it will get every child waypoint and make a list
    public void Awake() {
        //if it is a boss will count the childs waypoints
        if(isBoss){
            bossPoints = new Transform[transform.childCount];
            for (i = 0; i < bossPoints.Length; i++){
                bossPoints[i] = transform.GetChild(i);
            }
        }
        else{ //if it is not a boss will count the childs of a diferent set of waypoints
            points = new Transform[transform.childCount];
            for (j = 0; j < points.Length; j++){
                points[i] = transform.GetChild(j);
            }
        }
    }
}
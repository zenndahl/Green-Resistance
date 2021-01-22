using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatPoints : MonoBehaviour
{
    public Transform[] points;
    // Start is called before the first frame update
    void Awake()
    {
        points = new Transform[transform.childCount];
        for (int j = 0; j < points.Length; j++){
            points[j] = transform.GetChild(j);
        }
    }
}

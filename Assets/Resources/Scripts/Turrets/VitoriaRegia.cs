using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VitoriaRegia : Node
{
    public int wavepointIndex = 0;
    public float speed;
    public GameObject floatPoints;
    public float fireRateBuff;
    private FloatPoints waypoints;
    private Transform direction;


    // Start is called before the first frame update
    void Start()
    {
        //get the first waypoint
        waypoints = floatPoints.GetComponent<FloatPoints>();
        direction = waypoints.points[wavepointIndex];

        //get the sprite renderer of the node
        rend = GetComponent<SpriteRenderer>();
        //intantiate the build manager to allow the turret building
        buildManager = BuildManager.instance;
        //set the base sprite as the start sprite in the build manager
        startSprite = rend.sprite;
    }

    protected override void Buff(){
        //accessing the vitoria ragia node component
        Node node = this.GetComponent<Node>();
        //getting the turret instantiated in this node
        Turret turret = node.turret.GetComponent<Turret>();
        //buff the turret fire rate
        turret.fireRate += fireRateBuff;
    }

    void Update()
    {
        //move in the direction of the next waypoint
        Vector2 dir = direction.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);   

        //if it reaches the waypoint, get the next
        if(Vector2.Distance(transform.position, direction.position) <= 0.05f){
            GetNextWaypoint();
        }
    }

    protected void GetNextWaypoint(){
        //while it is not the last waypoint, get the next waypoint in the array
        wavepointIndex++;
        //if it passes the last waypoint, go back to the first
        if(wavepointIndex == waypoints.points.Length){
            wavepointIndex = 0;
        }
        direction = waypoints.points[wavepointIndex];
    }
}

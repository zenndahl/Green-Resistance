using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauBrasil : MonoBehaviour
{
    public float range;
    public float damageBonus;
    public float burnBonus;

    private List<GameObject> nodesBuffed;


    // Start is called before the first frame update
    void Start()
    {
        nodesBuffed = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        //searches all objects with the tag "Enemy"
        GameObject[] nodes = GameObject.FindGameObjectsWithTag("Node");
        GameObject[] turrets = GameObject.FindGameObjectsWithTag("Turret");

        foreach(GameObject node in nodes){
            //gets the distance between the node and this object
            float distanceToNode = Vector2.Distance(transform.position, node.transform.position);
            //if there is an enemy in range, ad to the list of buffed nodes
            if(distanceToNode < range){
                nodesBuffed.Add(node);
            }
        }

        BuffTurret();
    }

    void BuffTurret(){
        foreach (GameObject land in nodesBuffed){
            Node node = land.GetComponent<Node>();
            if(node.turret != null){
                Turret turret = node.turret.GetComponent<Turret>();
                turret.atkDamage = damageBonus;
                turret.isBuffed = true;
            }
        }
    }

    private void OnDrawGizmosSelected() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}

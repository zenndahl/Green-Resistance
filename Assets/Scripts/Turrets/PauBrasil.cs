using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauBrasil : MonoBehaviour
{
    public float range;
    public float damageBonus;
    public float burnBonus;
    public GameObject buffEffect;

    private List<GameObject> nodesBuffed;


    // Start is called before the first frame update
    void Start()
    {
        nodesBuffed = new List<GameObject>();
        SetBuffs();
    }

    // Update is called once per frame
    void SetBuffs()
    {
        //searches all nodes
        GameObject[] nodes = GameObject.FindGameObjectsWithTag("Node");

        foreach(GameObject node in nodes){
            //gets the distance between the node and this object
            float distanceToNode = Vector2.Distance(transform.position, node.transform.position);
            //if there is an enemy in range, ad to the list of buffed nodes
            if(distanceToNode < range){
                nodesBuffed.Add(node);
                GameObject effect = GameObject.Instantiate(buffEffect, node.transform.position, node.transform.rotation);
                effect.transform.parent = node.transform;
            }
        }
    }

    private void Update() {

        foreach(GameObject node in nodesBuffed){
            Node nodeObject = node.GetComponent<Node>();
            BuffTurret(nodeObject);
        }
    }

    void BuffTurret(Node node){
        if(node.turret != null){
            Turret turret = node.turret.GetComponent<Turret>();
            Debug.Log("Chegando");
            turret.atkDamage = damageBonus;
        }
    }

    private void OnDrawGizmosSelected() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}

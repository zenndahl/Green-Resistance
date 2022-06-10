using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SupportPlant : MonoBehaviour
{
    [Header("Stats")]
    public float range;
    [Header("Setup")]
    public GameObject buffEffect;
    public GameObject bulletPrefab;
    [Header("Bonus Stats")]
    public float damageBonus;
    public float fireRateBonus;

    private List<GameObject> nodesBuffed;


    // Start is called before the first frame update
    void Start()
    {
        nodesBuffed = new List<GameObject>();
        SetBuffEffect();
    }

    // Update is called once per frame
    void SetBuffEffect()
    {
        //searches all nodes
        GameObject[] nodes = GameObject.FindGameObjectsWithTag("Node");

        foreach(GameObject node in nodes){
            //gets the distance between the node and this object
            float distanceToNode = Vector2.Distance(transform.position, node.transform.position);
            //if there is an enemy in range, add to the list of buffed nodes
            if(distanceToNode < range){
                nodesBuffed.Add(node);
                //instantiate the effect on the node
                GameObject effect = GameObject.Instantiate(buffEffect, node.transform.position, node.transform.rotation);
                //the node becomes parent of the effect, so that moving nodes will properly show the effect
                effect.transform.parent = node.transform;
            }
        }
    }

    private void Update(){
        //will each frame check for new turrets and apply the buff
        foreach(GameObject nodeObject in nodesBuffed){
            Node node = nodeObject.GetComponent<Node>();
            if(node.turret != null){
                BuffTurret(node);
            }
        }
    }

    protected virtual void BuffTurret(Node node){
        Turret turret = node.turret.GetComponent<Turret>();
        if(!turret.isBuffed){
            //apply the bonus from the support plant
            turret.atkDamage += damageBonus;
            turret.fireRate += fireRateBonus;
            if(turret.isRanged){
                //gets the original bullet sprite
                Sprite originalSprite = turret.bulletPrefab.GetComponent<SpriteRenderer>().sprite;
                //set the new bullet prefab
                turret.bulletPrefab = bulletPrefab;
                //set the new bullet prefab sprite as the original
                turret.bulletPrefab.GetComponent<SpriteRenderer>().sprite = originalSprite;
            }
            //burst turrets do not get the burn bonus, just the damage buff
        }
    }

    private void OnDrawGizmosSelected() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}

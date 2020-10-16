using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Transform target;
    public float speed = 50f;
    public int damage = 50;
    
    public void Seek(Transform _target){
        target = _target;
    }

    // Update is called once per frame
    void Update()
    {
        if(target == null){
            Destroy(gameObject);
            return;
        }

        Vector2 direction = target.position - transform.position;
        float distancePerFrame = speed * Time.deltaTime;

        if(direction.magnitude <= distancePerFrame){
            HitTarget();
            return;
        }
    
    }

    public void HitTarget(){
        //instantiate hit effect

        Damage();
        //destroy impact effect
    }

    //this function will change to apply damage on life instead of simply destroing the target
    public void Damage(){
        //subtract life from enemy
        //apply any on-hit effect
        Enemy enemy = target.GetComponent<Enemy>();
        enemy.TakeDamage();
    }
}

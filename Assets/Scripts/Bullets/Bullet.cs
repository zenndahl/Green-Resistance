﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [Header("Setup")]
    protected Transform target;
    private Rigidbody2D rigidBody;
    public bool isGrenade;
    public Vector3 hitPoint;

    [Header("Stats")]
    public float damage;
    public float speed;
    
    public void Seek(Transform _target){
        target = _target;
        hitPoint = target.position;
    }

    private void Start() {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(target == null){
            Destroy(gameObject);
            return;
        }
        Vector3 direction;
        if(!isGrenade){
            direction = (Vector2)target.position - rigidBody.position;
        }
        else{
            direction = (Vector2)hitPoint - rigidBody.position;
        }
        float distancePerFrame = speed * Time.deltaTime;

        //mudar para hitbox
        if(direction.magnitude <= distancePerFrame){
            HitTarget();
        }
        //Translate funciona com Vector3
        transform.Translate(direction.normalized * distancePerFrame);
    }

    public void HitTarget(){
        //instantiate hit effect and sound
        Damage();
        //destroy hit effect and sound
    }

    //this function will change to apply damage on life instead of simply destroing the target
    public virtual void Damage(){
        //subtract life from enemy
        //apply any on-hit effect
        Enemy enemy = target.GetComponent<Enemy>();
        enemy.TakeDamage(damage);
        Destroy(gameObject);
    }
}
﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [Header("Setup")]
    protected Transform target;
    protected Rigidbody2D rigidBody;
    protected SpriteRenderer spriteRenderer;
    public string soundEffectName = "Hit";

    [Header("Stats")]
    public float speed;

    [HideInInspector]
    public float damage;

    [Header("Grenadier Turret Setup")]
    //only used by grenade turrets
    public bool isGrenade;
    public Vector3 hitPoint;
    

    private void Start(){
        rigidBody = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void Seek(Transform _target){
        if(_target == null) return;
        target = _target;
        hitPoint = target.position;
    }

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

        //mudar para hitbox?
        if(direction.magnitude <= distancePerFrame){
            HitTarget();
        }
        //Translate funciona com Vector3
        transform.Translate(direction.normalized * distancePerFrame);
    }

    public virtual void HitTarget(){
        //instantiate hit effect and sound
        FindObjectOfType<AudioManager>().PlayAudio(soundEffectName);
        Damage();
        //TODO destroy effect and sound
    }

    public virtual void Damage(){
        //subtract life from enemy
        //apply any on-hit effect
        Enemy enemy = target.GetComponent<Enemy>();
        enemy.TakeDamage(damage);
        Destroy(gameObject);
    }
}

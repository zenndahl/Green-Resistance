using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Transform target;
    private Rigidbody2D rigidBody;

    public float speed = 50f;
    public int damage = 50;
    
    public void Seek(Transform _target){
        target = _target;
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

        Vector3 direction = (Vector2)target.position - rigidBody.position;
        float distancePerFrame = speed * Time.deltaTime;

        //mudar para hitbox
        if(direction.magnitude <= distancePerFrame){
            HitTarget();
            return;
        }
        //Translate funciona com Vector3
        transform.Translate(direction.normalized * distancePerFrame);
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
        enemy.TakeDamage(0);
    }
}

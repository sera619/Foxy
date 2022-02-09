using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float speed = 60f;
    [SerializeField] private float acceleration = 0f;
 

    public int SpellDamage { get; set; }
    public Vector2 Direction { get; set; }
    public float Speed { get; set; }
    public Character ProjectileOwner { get; set; }
    private Rigidbody2D myBody;
    private Collider2D myCollider;
    private SpriteRenderer spriteRenderer;
    private Vector2 movement;
    private bool canMove;

    private void Awake() {
        Speed = speed;
        canMove = true;

        myBody = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        myCollider = GetComponent<Collider2D>();
    }

    private void FixedUpdate() {
        if(canMove){
            MoveProjectile();
        }
    }

    public void MoveProjectile(){
        movement = Direction * (Speed / 10f)  * Time.fixedDeltaTime;
        myBody.MovePosition(myBody.position + movement);
        
        Speed += acceleration * Time.deltaTime;
    }

    public void SetDirection(Vector2 newDirection, Quaternion rotation){
        Direction = newDirection;
        transform.rotation = rotation;
    }

    public void ResetProjectile(){
        spriteRenderer.enabled = false;
    }

    public void SetSpellDamage(int damage){
        SpellDamage = damage;
    } 

    public void DisableProjectile(){
        canMove = false;
        spriteRenderer.enabled = false;
        myCollider.enabled = false;
    }

    public void EnableProjectile(){
        canMove = true;
        spriteRenderer.enabled = true;
        myCollider.enabled = true;
    }

}




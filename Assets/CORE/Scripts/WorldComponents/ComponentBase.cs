using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComponentBase : MonoBehaviour
{
    [Header("Sprite")]
    [SerializeField] private Sprite damagedSprite;
    [Header("Animation")]
    [SerializeField] private bool isAnimated;

    [Header("Settings")]
    [SerializeField] private int damage = 1;
    [SerializeField] private bool isDamageable;

    private Health health;
    private SpriteRenderer spriteRenderer;
    private RandomReward randomReward;
    private Collider2D myCollider;
    private Animator animator;


    private void Start(){
        health =GetComponent<Health>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        randomReward = GetComponent<RandomReward>();
        myCollider = GetComponent<Collider2D>();
        animator = GetComponent<Animator>();
    }


    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag("PlayerWeapon")){
            TakeDamage();
        }
    }

    private void TakeDamage(){
        health.TakeDamage(damage);
        if(health.CurrentHealth > 0){
            if(isDamageable){
                spriteRenderer.sprite = damagedSprite;
            }
        }
        if(health.CurrentHealth <= 0){
            if(isDamageable){
                if(isAnimated){
                    animator.SetTrigger("Animate");
                }
                Destroy(gameObject);
            }else{
                if(isAnimated){
                    animator.SetTrigger("Animate");
                }
                spriteRenderer.sprite = damagedSprite;
                myCollider.enabled = false;
                randomReward.GiveReward();
            }
        }
    }
}

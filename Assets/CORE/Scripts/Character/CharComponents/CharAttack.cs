using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharAttack : MonoBehaviour
{
    
    [Header("Player Sword Damage")]
    [SerializeField] private int swordDamage = 2;
    [SerializeField] private PlayerSword playerSword;

    [SerializeField] private Animator animator;
    private CharMovement charMovement;
    private CharController controller;
    
    private float attackTime = .5f;
    private float checkTime;
    public bool isAttacking { get; set; }


    private void Start() {
        controller = GetComponent<CharController>();
    }
    
    
    
    
    private void Update(){
        if (Input.GetKeyDown(KeyCode.Space)){
                StartAttack();
            }
        
        
        if(isAttacking){
            checkTime += Time.deltaTime;
            if(checkTime >= attackTime){
                isAttacking = false;
                StopAttack();
            }
        }


    }




    
    private void StartAttack(){
        if(isAttacking){
            return;
        }
        isAttacking = true;
        animator.SetTrigger("Attack");
        controller.NormalMovement = false;
    }



    private void StopAttack(){
        checkTime = 0;
        controller.NormalMovement = true;
    }


        



}

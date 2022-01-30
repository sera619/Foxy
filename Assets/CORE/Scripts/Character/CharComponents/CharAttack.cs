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
    public bool canAttack = true;
    private bool isAttacking = false;

    
    
    private void Start(){
        controller = GetComponent<CharController>();
        charMovement = GetComponent<CharMovement>();
        if(playerSword != null){
            playerSword.SwordDamage = swordDamage;
        }
    }

    private void Update(){
        if(canAttack){
            if(Input.GetKeyDown(KeyCode.Space)){
            Attack();
        }
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Atack")){
            canAttack = false;
        }else{
            canAttack = true;
            charMovement.ResetSpeed();
        }
        

   }
       

        
}
        
    private void Attack(){
        charMovement.MoveSpeed = 0f;
        canAttack = false;
        isAttacking = true;
        animator.SetTrigger("Attack");


    }



}

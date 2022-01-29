using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharAttack : CharComponents
{
    private float attackDuration = .6f;
    private float attackTimer;

    public bool isAttacking { get; set; }
    protected override void Start(){
        base.Start();
    }

    protected override void HandleInput()
    {
        if(Input.GetKeyDown(KeyCode.Space)){
            Attack();
        }
    }

    protected override void HandleAbility()
    {
        base.HandleAbility();
        if(isAttacking){
            if(attackTimer < attackDuration){
                charMovement.MoveSpeed = 0f;
                attackTimer += Time.time;
            }else{
                StopAttack();
            }

        }

    }



    private void Attack(){
        if(isAttacking){
            return;
        }
        isAttacking = true;
        attackTimer = 0f;
        character.CharAnimator.SetTrigger("Attack");
    }

    private void StopAttack(){
        isAttacking = false;
        charMovement.ResetSpeed();
    }


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "AI/Actions/Meele Attack", fileName = "MeeleAttack")]
public class ActionMeeleAttack : AIAction
{   public override void Act(StateController controller)
    {
        Attack(controller);
    }

    private void Attack(StateController controller)
    {
        Animator animator = controller.GetComponent<Character>().CharAnimator;
    
        // Stop
        controller.CharacterMovement.SetHorizontal(0f);
        controller.CharacterMovement.SetVertical(0f);
        
        // Attack
        animator.SetTrigger("Attack");
    }
}

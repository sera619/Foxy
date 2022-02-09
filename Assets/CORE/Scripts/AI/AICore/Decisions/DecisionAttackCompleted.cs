using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "AI/Decisions/Attack Completed", fileName = "DecisionAttackCompleted")]
public class DecisionAttackCompleted : AIDecision
{
    [SerializeField] private Animator animator;
    public override bool Decide(StateController controller)
    {
        return AttackCompleted(controller);
    }

    private bool AttackCompleted(StateController controller)
    {   
     

        if (animator.GetCurrentAnimatorStateInfo(0).length
        > animator.GetCurrentAnimatorStateInfo(0).normalizedTime)
        {
            return true;
        }

        return false;
    }
}

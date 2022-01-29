using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharEffects : MonoBehaviour
{

    [SerializeField] Animator animator;

    public Animator Animator => animator;


    public void PlayEffect(int effectIDtoPlay){
        if(effectIDtoPlay == 1){
            animator.SetTrigger("Dead");          
        }
    }



}

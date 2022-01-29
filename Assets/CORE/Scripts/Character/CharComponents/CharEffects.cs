using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharEffects : MonoBehaviour
{

    [SerializeField]private Animator animator;
    [SerializeField]private SpriteRenderer spriteRenderer;


    public Animator Animator => animator;
    public SpriteRenderer SpriteRenderer=>spriteRenderer;
    public bool IsPlaying { get; set; }

    public bool HitEffect {get; set;}
    public bool DeadEffect { get; set; }

    private void Start(){
        HitEffect = false;
        DeadEffect = false;
    }


    public void PlayEffect(int effectIDtoPlay){
        if(effectIDtoPlay == 1){
            IsPlaying = true;
            spriteRenderer.enabled = true;
            DeadEffect = true;
            animator.SetTrigger("Dead");
        }
        if(effectIDtoPlay == 2){
            IsPlaying= true;
            HitEffect = true;

            spriteRenderer.enabled = true;
            animator.SetTrigger("Hit");
        }
    }



}

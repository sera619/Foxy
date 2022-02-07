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
    public bool ExplodeEffect { get; set; }

    public bool LvlUpEffect { get; set; }

    private void Start(){
        ResetEffects();
    }

    private void ResetEffects(){
        HitEffect = false;
        DeadEffect = false;
        ExplodeEffect = false;
    }

    public void PlayEffect(int effectIDtoPlay){
        ResetEffects();
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
        if(effectIDtoPlay == 3){
            IsPlaying = true;
            ExplodeEffect = true;

            spriteRenderer.enabled = true;
            animator.SetTrigger("Explode");
        }
        if(effectIDtoPlay == 4){
            IsPlaying = true;
            LvlUpEffect = true;

            spriteRenderer.enabled = true;
            animator.SetTrigger("LvlUp");
        }
    }



}

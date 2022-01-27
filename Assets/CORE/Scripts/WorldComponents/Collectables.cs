using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectables : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private bool canDestroyItem = true;
    protected Character character;
    protected GameObject objectCollided;
    protected SpriteRenderer spriteRenderer;
    protected Collider2D myCollider;



    private void Start(){
        spriteRenderer = GetComponent<SpriteRenderer>();
        myCollider = GetComponent<Collider2D>();

    }

    private void OnTriggerEnter2D(Collider2D other) {
        objectCollided = other.gameObject;
        if(IsPickable()){
            Pick();
            PlayEffects();
            if (canDestroyItem){
                Destroy(gameObject);
            }else{
                spriteRenderer.enabled = false;
                myCollider.enabled = false;
            }
        }
    }

  
  
  
    protected virtual bool IsPickable(){
        character = objectCollided.GetComponent<Character>();
        if(character == null){
            return false;
        }
        if (character.CharType == Character.CharTypes.Player){
            return true;
        }
        else{
            return false;
        }
    }

    protected virtual void Pick(){

    }
    protected virtual void PlayEffects(){

    }

}

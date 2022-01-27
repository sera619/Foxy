using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{

    [Header("Door Settings")]
    [SerializeField] private Animator animator;
    [SerializeField] private Sprite openSprite; 


    private bool isPlayer;
    private bool isOpen;
    private SpriteRenderer doorSprite;



    private void Start(){
        doorSprite = GetComponentInChildren<SpriteRenderer>();
    }


    private void Update() {
        if(Input.GetKeyDown(KeyCode.E)){
            if(!isPlayer){
                return;
            }else{
                OpenDoor();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player")){
            isPlayer = true;
        }    
    }
    private void OnTriggerExit2D(Collider2D other) {
        if(other.CompareTag("Player")){
            isPlayer = false;
        }    
    }


    private void OpenDoor(){
        if(!isOpen){
            isOpen = true;
            animator.SetTrigger("Open");
            if(animator.GetCurrentAnimatorStateInfo(0).IsName("Open")){
                doorSprite.sprite = openSprite;
            }
        }
    }



}

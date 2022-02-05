using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorGarden : MonoBehaviour
{
    [SerializeField] private Collider2D myCollider;
    [SerializeField] private Animator animator;

    private  bool canOpen {get; set;}

    private float openTimer = 2f;

    private void Start() {
        
        animator = GetComponent<Animator>();
        myCollider = GetComponent<Collider2D>();

    }


    private void Update() {
        if(Input.GetKeyDown(KeyCode.E)){
            if(canOpen){
                Open();
            }else{
                Close();
            }
            
        }
    }



    private void Close(){
        animator.SetTrigger("Close"); 
        myCollider.enabled = true;
    }


    private void Open(){
        animator.SetTrigger("Open");
        myCollider.enabled = false;
    }
    
    private bool Timer(){
        if(!canOpen){
            return true;
        }
        return false;
    }
    
    






}

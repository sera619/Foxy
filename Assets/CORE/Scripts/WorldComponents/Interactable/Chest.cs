using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{

    [Header("Chest Settings")]
    [SerializeField] private Collider2D chestBlocker;
    [SerializeField] private Animator animator;

    private bool isPlayer;
    private bool isOpen;
    private RandomReward reward;

    private void Start(){
        reward = GetComponent<RandomReward>();
    }


    private void Update(){
        if(Input.GetKeyDown(KeyCode.E)){
            if(!isPlayer){
                return;               
            }else{
                OpenChest();
            }
        }
    }

    private void OpenChest(){
        if(isOpen){
            return;
        }else{
            isOpen = true;
            animator.SetTrigger("Open");
            RewardPlayer();
        }
    }

    private void RewardPlayer(){
        if(!isPlayer){
            return;
        }else{
            reward.GiveReward();
        }
    
    
    }


    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player")){
            isPlayer = true;
        }    
    }

    private void OnTriggerExit2D(Collider2D other){
        if(other.CompareTag("Player")){
            isPlayer = false;
        }
    }




}

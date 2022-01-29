using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{

    [Header("Chest Settings")]
    [SerializeField] private Collider2D chestBlocker;
    [SerializeField] private Animator animator;
    [SerializeField] private Sprite openSprite;
    [SerializeField] private SpriteRenderer spriteRenderer;

    private bool isPlayer;
    private bool isOpen;
    //private bool isOpen {set; get;}
    private RandomReward reward;
    private CollectableItemset collectableItemset;
    private UniqueID uniqueID;

    private void Start(){
        reward = GetComponent<RandomReward>();
        uniqueID = GetComponent<UniqueID>();
        collectableItemset =FindObjectOfType<CollectableItemset>();
        if(collectableItemset.CollectedItems.Contains(uniqueID.ID)){
            isOpen = true;
            animator.SetTrigger("Open");
        }

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
            SaveLoad.Save<bool>(isOpen, "Chest");
            collectableItemset.CollectedItems.Add(uniqueID.ID);
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestItem : MonoBehaviour 
{

    [SerializeField] private bool destroyItem;
    private Collider2D myCollider;
    private PlayerQuest playerquest;
    
    private void Start() {
        myCollider = GetComponent<Collider2D>();
    }
    
    private void OnTriggerEnter2D(Collider2D other) {
        if(!other.CompareTag("Player")){
            return;
        }else{
            PlayerQuest playerquest = other.GetComponent<CharQuest>().playerQuest;
            if(playerquest.Status != QuestStatus.Started){
                return;
            }
            playerquest.QuestReady();
            playerquest.CurrentAmount = 1;
            UIManager.Instance.ShowReadyIcon();
            Debug.Log("Quest Ready");
            if(destroyItem){
                gameObject.SetActive(false);
            }else{
                Destroy(gameObject);
            }

        }
    }

}

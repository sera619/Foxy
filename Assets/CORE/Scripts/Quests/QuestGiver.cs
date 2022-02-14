using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestGiver : MonoBehaviour
{
    [SerializeField] private string npcName;
    [SerializeField] Dialog dialog;   
    [SerializeField] Dialog finishedDialog; 
    [SerializeField] QuestBase questToStart;

    private PlayerQuest activeQuest;
    [SerializeField] public CharQuest playerQuest;
    public Quest quest;
    private bool playerRewarded;
    private bool isPlayer;
    private bool firstSeen = true;
    public string NpcName => npcName;

    

    public void AcceptQuest(){
        Debug.Log("Quest accepted");
        
        playerQuest.AddQuest(quest);
    }

    
    
    
    
    
    
    
    private void Update() {
        if(isPlayer){
            if(Input.GetKeyDown(KeyCode.E )&& !DialogManager.Instance.IsShowing){
                StartCoroutine(Interact());
            }
        }
    }


    private IEnumerator Interact(){
        DialogManager.Instance.NpcName = NpcName;                    
        if(firstSeen){
            firstSeen = false;
            yield return DialogManager.Instance.ShowDialog(dialog);
        }
        else if(questToStart != null){
            activeQuest = new PlayerQuest(questToStart);
            Debug.Log("Quest generiert"); 
            yield return activeQuest.StartQuest(playerQuest);
            questToStart = null;
        }
        else if(playerQuest.playerQuest != null && playerQuest.playerQuest.Status == QuestStatus.Ready){
            RewardPlayer();
            yield return activeQuest.CompleteQuest();
            activeQuest = null;
        }
        else if(activeQuest == null && questToStart == null){
            yield return DialogManager.Instance.ShowDialog(finishedDialog);
        
        }
        else{
            yield return DialogManager.Instance.ShowDialog(dialog);
        }


    }


    public void RewardPlayer(){
        if(playerRewarded){
            return;
        }
        //playerQuest.GetComponent<Health>().GetXP(quest.ExpReward);
        //playerQuest.GetComponent<CharGold>().AddCoins(quest.GoldReward);
        playerRewarded = true;
        playerQuest.GetComponent<CharGold>().AddCoins(activeQuest.Base.RewardGold);
        playerQuest.GetComponent<Health>().GetXP(activeQuest.Base.RewardExp);       
        playerQuest.RemoveQuest();
        Debug.Log("Quest rewarded");
        //quest.IsCompleted = true;
    }


    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player")){
            isPlayer = true;
        }else{
            return;
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if (other.CompareTag("Player")){
            isPlayer = false;
        }
        else{
            return;
        }
    }



}

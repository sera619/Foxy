using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharQuest : MonoBehaviour
{



    [SerializeField] private GameObject questTracker;
    public PlayerQuest playerQuest;
    public Quest Quest; 
    private CharController controller;
   
    
    private void Start(){
        questTracker.SetActive(false);
        controller = GetComponent<CharController>();
    }


    public void AddQuest(Quest quest){
        if(!Quest.IsActive){
            Quest = quest;
            Quest.IsActive = true;
            UIManager.Instance.ShowQuestTracker();
            UpdateQuestTracker();
        }

    }

    public void AddPlayerQuest(PlayerQuest quest){
        if(playerQuest != null){
            Debug.Log("FAIL ADD QUEST: Quest already exists!");
        }else{
            playerQuest = quest;
            Debug.Log("Quest accepted"); 
            UIManager.Instance.ShowQuestTracker();
            UpdateQuestTracker();   
        }
    }

    private void Update() {
        
        if(playerQuest !=null){
            if (playerQuest.Status == QuestStatus.Started || playerQuest.Status == QuestStatus.Ready){
                UpdateQuestTracker();
            }
        } 
        
        
        /*if(Quest.IsActive){
            UpdateQuestTracker();
        }*/

    }

    public void UpdateQuestTracker(){
        
        UIManager.Instance.UpdateQuestTracker(playerQuest.Base.QuestName, playerQuest.Base.QuestDescription, playerQuest.CurrentAmount, playerQuest.Base.RequiredAmount, true);
        if(playerQuest.Status == QuestStatus.Ready){
            UIManager.Instance.ShowReadyIcon();
        }
        
        /*
        UIManager.Instance.UpdateQuestTracker(Quest.QuestName, Quest.QuestDescription, Quest.Goal.CurrentAmount, Quest.Goal.RequiredAmount, true);
        if(Quest.Goal.IsReached()){
            UIManager.Instance.ShowReadyIcon();
        }
        */
    }

    public void RemoveQuest(){
        if(Quest.IsActive){
            Quest.IsActive = false;
            Quest = null;

        }
        if(playerQuest != null){
            playerQuest = null;
            UIManager.Instance.HideQuestTracker();
            Debug.Log("Quest entfernt");

        }
    }


}

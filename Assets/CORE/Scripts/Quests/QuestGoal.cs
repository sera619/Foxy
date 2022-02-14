using System.Collections;
using System.Collections.Generic;
using UnityEngine;




[System.Serializable]
public class QuestGoal
{
    
    [Header("Quest Goal Settings")]
    public GoalType goalType;
    public int CurrentAmount;
    public int RequiredAmount;
    
    public bool Reached;
    public bool IsReached(){
        return (CurrentAmount >= RequiredAmount);
    }

    public void EnemyKilled(){
        if(goalType == GoalType.Kill){
            CurrentAmount ++;
            if(IsReached()){
                Reached = true;
            }
        }
    }  

    public void ItemCollected(){
        if(goalType == GoalType.Gathering){
            CurrentAmount ++;
            if(IsReached()){
                Reached = true;
            }
        }
    }



}

public enum GoalType
{
    Kill,
    Gathering
}

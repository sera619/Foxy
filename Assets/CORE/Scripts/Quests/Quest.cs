using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Quest 
{
    [Header("Quest Settings")]
    public string QuestName;
    public string QuestDescription;
    public int ExpReward;
    public int GoldReward;
    public bool IsActive;
    public bool IsCompleted;
    

    public QuestGoal Goal;
    

}

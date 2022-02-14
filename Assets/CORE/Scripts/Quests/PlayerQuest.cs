using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerQuest
{    
    public QuestBase Base { get; private set;}
    public QuestStatus Status { get; private set;}

    private CharQuest charQuest;
    public int CurrentAmount { set; get;}
    public PlayerQuest(QuestBase _base){
        Base = _base;
    }

    public IEnumerator StartQuest(CharQuest playerCharQuest){
        Status = QuestStatus.Started;
        charQuest = playerCharQuest;
        charQuest.AddPlayerQuest(this);
        yield return DialogManager.Instance.ShowDialog(Base.StartDialog);



    }
    
    public IEnumerator CompleteQuest(){
        Status = QuestStatus.Completed;
        yield return DialogManager.Instance.ShowDialog(Base.RewardDialog);

        if(Base.RewardExp != 0){

        }



    }

    public void QuestReady(){
        CurrentAmount = Base.RequiredAmount;
        Status = QuestStatus.Ready;
    }

    public IEnumerator ProgessQuest(){
        yield return DialogManager.Instance.ShowDialog(Base.InProgressDialog);
    }


    



}

public enum QuestStatus{
    None,
    Started,
    Ready,
    Completed
}
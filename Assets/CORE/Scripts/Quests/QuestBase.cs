using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName="Quest/Create new Quest")]
public class QuestBase : ScriptableObject
{
    [SerializeField] string questName;
    [SerializeField] string questDescription;

    [SerializeField] Dialog startDialog;
    [SerializeField] Dialog inProgressDialog;
    [SerializeField] Dialog rewardDialog;
  

    [SerializeField] int requiredAmount;
    [SerializeField] int currentAmount;

    [SerializeField] int rewardGold;
    [SerializeField] int rewardExp;

    public string QuestName => questName;
    public string QuestDescription => questDescription;

    public Dialog StartDialog => startDialog;
    public Dialog InProgressDialog => inProgressDialog?.Lines.Count > 0 ? inProgressDialog : startDialog ;
    public Dialog RewardDialog => rewardDialog;


    public int RewardGold => rewardGold;
    public int RewardExp => rewardExp;

    public int RequiredAmount => requiredAmount;
    public int CurrentAmount => currentAmount;


}

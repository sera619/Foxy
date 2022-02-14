using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestNPC : MonoBehaviour
{

    private EnemyHealth enemyHealth;
    private CharQuest charQuest;
    private void Start() {
        enemyHealth = GetComponent<EnemyHealth>();
        charQuest = GetComponent<CharQuest>();
    }

    private void UpdateQuest(){
        if(enemyHealth.EnemyCurrentHealth >= 0){
            if(!charQuest.Quest.Goal.IsReached()){
                return;
            }else{
                charQuest.Quest.Goal.EnemyKilled();
        }
        }
        
    }





}

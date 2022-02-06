using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{

    
    


    public int currentSceneID = 0;
    

    public void LoadLevel(){
        Debug.Log("call 'LoadLevel'");
        currentSceneID += 1;
        SceneManager.LoadScene(currentSceneID);
    }

    public void Save(){
        GameEvents.OnSaveInitiated();
    }



}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : MonoBehaviour
{   
    [Header("Pause Settings")]
    [SerializeField] private GameObject PauseMenu;
    private bool gamePaused { set; get;}

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)){
            PauseGame();
        }

        
    }
    private void PauseGame(){
        gamePaused = !gamePaused;
        Time.timeScale = gamePaused ? 0 : 1;
        PauseMenu.SetActive(gamePaused);
    }
    public bool IsGamePaused() {
             return gamePaused;
        }  
}

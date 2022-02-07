using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelManager : Singleton<LevelManager>
{
    [SerializeField] private Character playableCharacter;
    [SerializeField] private Transform spawnPosition;
    [SerializeField] private GameObject transitionPlayer;
    
    [Header("Level Information")]
    [SerializeField] private string levelName;
    [SerializeField] private TextMeshProUGUI leveNameTMP;
    [SerializeField] private GameObject levelInformationPanel;




    private float activeTime = 4f;
    private float _timeChecker;
    private bool levelinfoShowing = false;
    private Animator transAnimator;
    public Transform Player { get; set; }
    public string LevelName => levelName;

    private void Start(){
        transAnimator = transitionPlayer.GetComponent<Animator>();
        Player = playableCharacter.transform;
        Camera2D.Instance.Target = playableCharacter.transform;
        _timeChecker = activeTime;
        ShowLevelInformation();
    }
    
    private void Update(){
        ShowInfo();
        if(Input.GetKeyDown(KeyCode.P)){
            ReviveCharacter();
        }
    }
    public void ReviveCharacter(){
        if (playableCharacter.GetComponent<Health>().CurrentHealth <= 0){
            playableCharacter.GetComponent<Health>().Revive();
            playableCharacter.transform.position = spawnPosition.position;
        }
    }


    private void ShowInfo(){
        if(levelinfoShowing && _timeChecker > 0){
            _timeChecker -= Time.deltaTime;

        }else{
            _timeChecker =  activeTime;
            levelinfoShowing = false;
            levelInformationPanel.SetActive(false);
        }

    }



    private void ShowLevelInformation(){
        if(levelName != "" && levelInformationPanel != null){
            leveNameTMP.text = LevelName;
            levelInformationPanel.SetActive(true);
            levelinfoShowing = true;
        }
    }
}

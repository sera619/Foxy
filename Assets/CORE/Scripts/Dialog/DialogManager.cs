using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

public class DialogManager : MonoBehaviour
{
    [SerializeField] private GameObject dialogBox;
    [SerializeField] private TextMeshProUGUI npcNameTMP;
    [SerializeField] private TextMeshProUGUI textTMP;
    [SerializeField] private int lettersPerSecond = 1;

    public event Action OnShowDialog;
    public event Action OnCloseDialog;

    public string NpcName {get; set;}

    public static DialogManager Instance { get; private set; }  
    public bool IsShowing;
    public bool IsTyping;
    
    private void Awake() {
        Instance = this;
    }


    public IEnumerator ShowDialog(Dialog dialog){
        IsShowing = true;
        yield return new WaitForEndOfFrame();
        
        OnShowDialog?.Invoke();
        dialogBox.SetActive(true);
        npcNameTMP.text = NpcName;
        
        foreach( var line in dialog.Lines){
            yield return TypeDialog(line);
            yield return new WaitUntil( () => Input.GetKeyDown(KeyCode.E));
        }
        

        NpcName = "";
        HideDialog();
    }


    public void HandleInput(){

    }

    public void HideDialog(){
        dialogBox.SetActive(false);
        IsShowing= false;
        OnCloseDialog?.Invoke();
    }

    public IEnumerator TypeDialog(string line){

        textTMP.text = "";
        foreach(var letter in line.ToCharArray()){
            textTMP.text +=letter;
            yield return new WaitForSeconds(1f / lettersPerSecond);
        }

    }
}

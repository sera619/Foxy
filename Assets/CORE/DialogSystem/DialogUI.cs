using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogUI : MonoBehaviour
{
    [SerializeField] private TMP_Text nameLabel;
    [SerializeField] private TMP_Text textLabel;
    [SerializeField] private GameObject textBox;
    [SerializeField] public string npcName;


    public bool IsOpen { get; private set; }


    private ResponseManager responseManager;
    private TypewriterEffect typewriterEffect;


    private void Start() {
        typewriterEffect = GetComponent<TypewriterEffect>();
        responseManager = GetComponent<ResponseManager>();

        CloseDialog();


    }

    public void ShowDialog(DialogObject dialogObject){
        nameLabel.text = npcName;
        textBox.SetActive(true);
        IsOpen = true;
        StartCoroutine(StepThroughDialog(dialogObject));
    }

    public void AddResponseEvents(ResponseEvent[] responseEvents){
        responseManager.AddResponseEvent(responseEvents);
    }




    private IEnumerator StepThroughDialog(DialogObject dialogObject)
    {
        for (int i = 0; i < dialogObject.Dialogue.Length; i++){
            string dialog = dialogObject.Dialogue[i];
            yield return RunTypingEffect(dialog);

            textLabel.text = dialog+"\n\n weiter mit 'E'.";


            if(i == dialogObject.Dialogue.Length - 1 && dialogObject.HasResponses) break;

            yield return null;
            yield return new WaitUntil( () => Input.GetKeyDown(KeyCode.E) );
        }

        if (dialogObject.HasResponses){
            responseManager.ShowResponses(dialogObject.Responses);
        }else{
            CloseDialog();
        }
    }

    private IEnumerator RunTypingEffect(string dialog){
        typewriterEffect.Run(dialog, textLabel);
        while (typewriterEffect.IsRunning){
            yield return null;
            if(Input.GetKeyDown(KeyCode.E)){
                typewriterEffect.Stop();
            }
        }
    }

    public void CloseDialog(){
        textBox.SetActive(false);
        nameLabel.text = string.Empty;
        IsOpen = false;

    }




}

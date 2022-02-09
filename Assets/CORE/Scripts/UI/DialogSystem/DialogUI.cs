using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogUI : MonoBehaviour
{
    [SerializeField] private TMP_Text nameLabel;
    [SerializeField] private TMP_Text textLabel;
    [SerializeField] private DialogObject testDialog;
    [SerializeField] private GameObject textBox;
    [SerializeField] public string npcName;



    private ResponseManager responseManager;
    private TypewriterEffect typewriterEffect;


    private void Start() {
        typewriterEffect = GetComponent<TypewriterEffect>();
        responseManager = GetComponent<ResponseManager>();

        CloseDialog();
        ShowDialog(testDialog);

    }

    public void ShowDialog(DialogObject dialogObject){
        nameLabel.text = npcName;
        textBox.SetActive(true);
        StartCoroutine(StepThroughDialog(dialogObject));
    }

    private IEnumerator StepThroughDialog(DialogObject dialogObject)
    {
        for (int i = 0; i < dialogObject.Dialogue.Length; i++){
            string dialog = dialogObject.Dialogue[i];
            yield return typewriterEffect.Run(dialog, textLabel);

            if(i == dialogObject.Dialogue.Length - 1 && dialogObject.HasResponses) break;


            yield return new WaitUntil( () => Input.GetKeyDown(KeyCode.Space) );
        }

        if (dialogObject.HasResponses){
            responseManager.ShowResponses(dialogObject.Responses);
        }else{
            CloseDialog();
        }
    }

    private void CloseDialog(){
        textBox.SetActive(false);
        nameLabel.text = string.Empty;

    }




}

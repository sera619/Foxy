using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class PlayerInformation : MonoBehaviour
{
    [Header("Text Settings")]
    [SerializeField] private TextMeshProUGUI textField;
    [SerializeField] public string showingText;
    [SerializeField] private GameObject ingamePanel;
    [SerializeField] private GameObject icon;

    private Collider2D myCollider;
    private bool isPlayer;



    private void Start() {
        myCollider = GetComponent<Collider2D>();
    }


    private void Update(){
        if(Input.GetKeyDown(KeyCode.E)){
            if(!isPlayer){
                return;
            }else{
                ShowPanel();
            }
        }
    }

    private void ShowPanel(){
        if(ingamePanel.activeSelf){
            ingamePanel.SetActive(false);
        }else{
            SetText();
            ingamePanel.SetActive(true);
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player")){
            isPlayer = true;
            icon.SetActive(true);          
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if(other.CompareTag("Player")){
            isPlayer = false;
            icon.SetActive(false);
            if(ingamePanel.activeSelf){
                ingamePanel.SetActive(false);
            }
        }

    }

    private void SetText(){
        textField.text = showingText;
    }



}

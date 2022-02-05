using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NPCBase: MonoBehaviour
{

    [SerializeField] private GameObject vendorPanel;
    [SerializeField] private TextMeshProUGUI playerGoldTMP;
    [SerializeField] private GameObject icon;

    private float itemPrice;
    private bool isPanelShow;
    private bool isPlayer = false;

    public int PlayerGold;

    public TextMeshProUGUI PlayerGoldTMP;
    private void Start() {
        PlayerGoldTMP = playerGoldTMP;
    }

    private void Update() {
        if(isPlayer && Input.GetKeyDown(KeyCode.E)){
            if(!isPanelShow){
                ShowShopPanel();
            }else{
                HideShopPanel();
            }
        }

    }


    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player")){
            icon.SetActive(true);
            PlayerGold = other.GetComponent<CharGold>().CurrentPlayerGold;
            isPlayer = true;
        }
    }


    private void OnTriggerExit2D(Collider2D other) {
        if(other.CompareTag("Player")){
            icon.SetActive(false);
            isPlayer = false;
        }
    }

    public void ShowShopPanel(){
        playerGoldTMP.text = PlayerGold.ToString();
        vendorPanel.SetActive(true);
        isPanelShow = true;      
    }



    public void HideShopPanel(){
        playerGoldTMP.text = "";
        vendorPanel.SetActive(false);
        isPanelShow = false;
    }



}

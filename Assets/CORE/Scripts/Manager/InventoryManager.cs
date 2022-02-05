using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
public class InventoryManager : Singleton<InventoryManager>
{
    [Header("Inventory")]
    [SerializeField] private GameObject inventoryFrame;

    [Header("Textfields")]
    [SerializeField] private TextMeshProUGUI keyTMP;
    [SerializeField] private TextMeshProUGUI manaTMP;
    [SerializeField] private TextMeshProUGUI healTMP;
    [SerializeField] private TextMeshProUGUI speedTMP;
    [SerializeField] private TextMeshProUGUI goldTMP;
 

    private bool isShowing;
    private int playerCurrentHealthPotion;
    private int playerCurrentManaPotion;
    private int playerCurrentKey;
    private int playerCurrentSpeedPotion;

    private int playerCurrentGold;

    private bool isPlayer;



    // Save System Start
    private void Start() {
        GameEvents.SaveInitiated += Save;
    }

    void Save(){
        SaveLoad.Save(playerCurrentKey,"PlayerKeys");
        SaveLoad.Save(playerCurrentGold, "PlayerGold");
        SaveLoad.Save(playerCurrentHealthPotion,"PlayerHpotion");
        SaveLoad.Save(playerCurrentManaPotion, "PlayerMpotion");


    }
    // Save system end

    private void Update(){
        InternalUpdate();
        if(Input.GetKeyDown(KeyCode.I)){
            ShowInventory();
        }
    }

    private void ShowInventory(){
        isShowing = !isShowing;
        inventoryFrame.SetActive(isShowing);
    }


    public void UpdatePotions(int manaPotion, int healPotion, int speedPotion, bool isThisPlayer){
        playerCurrentHealthPotion = healPotion;
        playerCurrentManaPotion = manaPotion;
        playerCurrentSpeedPotion = speedPotion;
        isPlayer = isThisPlayer;
        
    }

    public void UpdateGold(int gold, bool isThisPlayer){
        playerCurrentGold = gold;
        isPlayer = isThisPlayer;
    }

    public void UpdateKeys(int keys, bool isThisPlayer){
        playerCurrentKey = keys;
        isPlayer = isThisPlayer;
    }

    private void InternalUpdate(){
        if(isPlayer){
            keyTMP.text = playerCurrentKey.ToString();
            healTMP.text = playerCurrentHealthPotion.ToString();
            speedTMP.text = playerCurrentSpeedPotion.ToString();
            manaTMP.text = playerCurrentManaPotion.ToString();
            goldTMP.text = playerCurrentGold.ToString();
        }
    }
}

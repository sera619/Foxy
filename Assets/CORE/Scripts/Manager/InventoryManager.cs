using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class InventoryManager : MonoBehaviour
{
    [Header("Inventory")]
    [SerializeField] private GameObject inventoryFrame;

    [Header("Textfields")]
    [SerializeField] private TextMeshProUGUI keyTMP;
    [SerializeField] private TextMeshProUGUI manaTMP;
    [SerializeField] private TextMeshProUGUI healTMP;
    [SerializeField] private TextMeshProUGUI speedTMP;
 

    private bool isShowing;
    private int playerCurrentHealthPotion;
    private int playerCurrentManaPotion;
    private int playerCurrentKey;
    private int playerCurrentSpeedPotion;

    private bool isPlayer;
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


    private void UpdateInventory(int manaPotion, int healPotion, int speedPotion, int key , bool isThisPlayer){
        playerCurrentHealthPotion = healPotion;
        playerCurrentManaPotion = manaPotion;
        playerCurrentKey = key;
        playerCurrentSpeedPotion = speedPotion;
        isPlayer = isThisPlayer;
        
    }

    private void InternalUpdate(){
        if(isPlayer){
            keyTMP.text = playerCurrentKey.ToString();
            healTMP.text = playerCurrentHealthPotion.ToString();
            speedTMP.text = playerCurrentSpeedPotion.ToString();
            manaTMP.text = playerCurrentManaPotion.ToString();
        }
    }
}

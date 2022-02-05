using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharGold : MonoBehaviour
{
    [Header("Gold Settings")]
    [SerializeField] private int playerGold;
    public int CurrentPlayerGold;
    private readonly string COINS_KEY = "FOX_COINS";
    private InventoryManager inventory;

    private void Start() {
        inventory = FindObjectOfType<InventoryManager>();
        if(playerGold != 0){
            CurrentPlayerGold = playerGold;
        }     
        if(inventory != null){
            UpdateGold();
        }
    }

    public void AddCoins(int amount){
        CurrentPlayerGold += amount;
        UpdateGold();
    }

    private void UpdateGold(){
        inventory.UpdateGold(CurrentPlayerGold, true);
    }
   
    





}

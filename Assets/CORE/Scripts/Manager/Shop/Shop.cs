using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Shop : MonoBehaviour
{

    [Header("Shopitems")]
    [SerializeField] private ShopItem healPotion;
    [SerializeField] private ShopItem manaPotion;
    [SerializeField] private ShopItem speedPotion;
    [SerializeField] private ShopItem weapon;

    [Header("Item 1")]
    [SerializeField] private Image speedpotionSpriterenderer;
    [SerializeField] private TextMeshProUGUI speedPotionTMP;
    [SerializeField] private TextMeshProUGUI speedPotionPriceTMP;



    [Header("Item 2")]
    [SerializeField] private Image healPotionSpriterenderer;
    [SerializeField] private TextMeshProUGUI healPotionTMP;
    [SerializeField] private TextMeshProUGUI healPotionPriceTMP;


    [Header("Item 3")]
    [SerializeField] private Image manaPotionSpriterenderer;
    [SerializeField] private TextMeshProUGUI manaPotionTMP;
    [SerializeField] private TextMeshProUGUI manaPotionPriceTMP;

    [Header("Description Panel")]
    [SerializeField] private TextMeshProUGUI itemInfoTMP;

    [SerializeField] private NPCBase vendor;
    private bool isInfoShowing { get; set; }
    private TextMeshProUGUI goldDisplay;
    private int playerGold;
    private int fullPrice { get; set; }

    private void Start() {
        if(healPotion != null && manaPotion != null && speedPotion != null){
            InitialUpdate();
        }
        fullPrice = 0;
        ResetInfo();
        if(goldDisplay != null){
            goldDisplay = vendor.PlayerGoldTMP;
        }
        playerGold = vendor.PlayerGold;

    }

    private void InitialUpdate(){

            //healpotion
            healPotionSpriterenderer.sprite = healPotion.itemIcon;
            healPotionTMP.text = healPotion.title;
            healPotionPriceTMP.text = healPotion.itemPrice.ToString();

            //manaPotion
            manaPotionPriceTMP.text = manaPotion.itemPrice.ToString();
            manaPotionSpriterenderer.sprite = manaPotion.itemIcon;
            manaPotionTMP.text = manaPotion.title;

            //speedpotion
            speedPotionTMP.text = speedPotion.title;
            speedPotionPriceTMP.text = speedPotion.itemPrice.ToString();
            speedpotionSpriterenderer.sprite = speedPotion.itemIcon;

    }



    private void Update(){

    }

    private void ResetInfo(){
        itemInfoTMP.text = "";
    }

    public void ShowSPotionInfo(){
        ResetInfo();
        itemInfoTMP.text = speedPotion.description;
        fullPrice = speedPotion.itemPrice;
        goldDisplay.text = playerGold +  " -" + fullPrice.ToString(); 
        isInfoShowing = true;
    }

    public void ShowMPotionInfo(){
        ResetInfo();
        itemInfoTMP.text = manaPotion.description;
        fullPrice = manaPotion.itemPrice;
        goldDisplay.text = playerGold + " -" + fullPrice.ToString(); 
        isInfoShowing = true;
    }

    public void ShowHPotionInfo(){
        ResetInfo();
        itemInfoTMP.text = healPotion.description;
        fullPrice = manaPotion.itemPrice;
        goldDisplay.text = playerGold + " -" + fullPrice.ToString();
        isInfoShowing = true;
    }




}

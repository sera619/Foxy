using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

    


public class UIManager : Singleton<UIManager>
{
    [Header("Name/Level Settings")]
    [SerializeField] private TextMeshProUGUI nameField;
    [SerializeField] private string playerName;

    [SerializeField] private TextMeshProUGUI levelField;
    [SerializeField] private string  levelValue;


    [Header("Bar Settings")]
    [SerializeField] private Image healthBar;
    [SerializeField] private TextMeshProUGUI currentHealthTMP;
    [SerializeField] private Image shieldBar;
    [SerializeField] private TextMeshProUGUI currentShieldTMP;
    [SerializeField] private Image manaBar;
    [SerializeField] private TextMeshProUGUI currentManaTMP;
    [SerializeField] private Image expBar;
    [SerializeField] private TextMeshProUGUI currentExpTMP;

    [Header("Level UP Settings")]
    [SerializeField] private GameObject levelupPanel;
    [Header("Quest Tracker Setting")]
    [SerializeField] private GameObject questTrackerPanel;
    [SerializeField] private TextMeshProUGUI questNameTMP;
    [SerializeField] private TextMeshProUGUI questDesTMP;
    [SerializeField] private Image readyIcon;

    [Header("DeathScreen")]
    [SerializeField] private GameObject deathScreen;

    [Header("Text")]
    [SerializeField] private TextMeshProUGUI coinsTMP;
    
    [Header("Boss")]
    [SerializeField] private GameObject bossHealthPanel;
    [SerializeField] private GameObject bossIntroPanel;
    
    private float playerCurrentHealth;
    private float playerMaxHealth;
    private float playerCurrentShield;
    private float playerMaxShield;
    private float playerCurrentMana;
    private float playerMaxMana;

    private float playerCurrentExp;
    private float playerMaxExp;



    public GameObject LevelUpPanel => levelupPanel;


    private string currentPlayerName;
    private int currentPlayerLevel;



    private bool isPlayer;

    private float bossCurrentHealth;
    private float bossMaxHealth;


    private void Start(){
        if (isPlayer){
            if(SaveLoad.SaveExists("PlayerName")){
                currentPlayerName = SaveLoad.Load<string>("PlayerName");
            }
            if(SaveLoad.SaveExists("PlayerCurrentXP")){
                playerCurrentExp = SaveLoad.Load<float>("PlayerCurrentExp");
                playerMaxExp = SaveLoad.Load<float>("PlayerCurrentMaxXP");
            }
            if(SaveLoad.SaveExists("PlayerLevel")){
                currentPlayerLevel = SaveLoad.Load<int>("PlayerLevel");
            }
        }
        
    }

    private void Update() {
        InternalUpdate();
    }

    public void UpdateHealth(float currentHealth, float maxHealth, float currentShield, float maxShield, bool isThisPlayer){
        playerCurrentHealth = currentHealth;
        playerMaxHealth  = maxHealth;
        playerCurrentShield = currentShield;
        playerMaxShield = maxShield;
        isPlayer = isThisPlayer;
    }
    public void ShowDeathScreen(){
        if(!deathScreen.activeSelf){
            deathScreen.SetActive(true);
        }
    }
    public void HideDeathScreen(){
        if(deathScreen.activeSelf){
            deathScreen.SetActive(false);
        }
    }
    public void UpdatePlayerLevel(int level, bool isThisPlayer){
        currentPlayerLevel = level;
        isPlayer = isThisPlayer;
    }

    public void UpdatePlayerExp(float xp,float maxXP,bool isThisPlayer){
        playerCurrentExp =  xp;
        playerMaxExp = maxXP;
        isPlayer = isThisPlayer;
    }

    public void UpdateMana(float currentMana, float maxMana, bool isThisPlayer){
        playerMaxMana = maxMana;
        playerCurrentMana =currentMana;
        isPlayer = isThisPlayer;
    }

    public void UpdatePlayername(string name, bool isThisPlayer){
        currentPlayerName = name;
        isPlayer = isThisPlayer;
    }
    private void InternalUpdate(){
        if(isPlayer){
            // healthbar update
            healthBar.fillAmount = Mathf.Lerp(healthBar.fillAmount, playerCurrentHealth/playerMaxHealth, 10f * Time.deltaTime);
            currentHealthTMP.text = playerCurrentHealth.ToString() + " / " + playerMaxHealth.ToString();

            //shieldbar update
            shieldBar.fillAmount = Mathf.Lerp(shieldBar.fillAmount, playerCurrentShield /playerMaxShield, 10f * Time.deltaTime);
            currentShieldTMP.text = playerCurrentShield.ToString() + " / " + playerMaxShield.ToString();

            //Manabar Update
            manaBar.fillAmount = Mathf.Lerp(manaBar.fillAmount, playerCurrentMana / playerMaxMana, 10f * Time.deltaTime);
            currentManaTMP.text = playerCurrentMana.ToString() + " / " + playerMaxMana.ToString();
            
            //EXPbar Update
            expBar.fillAmount = Mathf.Lerp(expBar.fillAmount,playerCurrentExp / playerMaxExp, 10f * Time.deltaTime);
            currentExpTMP.text = playerCurrentExp.ToString() + " / " + playerMaxExp.ToString();
            
            
            //level/Name Update
            nameField.text = currentPlayerName;
            levelField.text = currentPlayerLevel.ToString();

        }
    }

    public void ShowLvlupPanel(){
        levelupPanel.SetActive(true);
    }

    public void HideLvlupPanel(){
        levelupPanel.SetActive(false);
    }
    public void GainBonusMana(){
        if(!isPlayer){
            return;
        }
        HideLvlupPanel();
        GameObject.FindGameObjectWithTag("Player").GetComponent<Health>().GainManaBonus();
    }
    public void GainBonusHealth(){
        if(!isPlayer){
            return;
        }
        HideLvlupPanel();
        GameObject.FindGameObjectWithTag("Player").GetComponent<Health>().GainHealthBonus();
    }

    public void UpdateQuestTracker(string questName, string questDescription, int currentAmount, int requiredAmount, bool isThisPlayer ){
        isPlayer = isThisPlayer;
        questDesTMP.text = questDescription + " " + currentAmount.ToString() + " / " + requiredAmount.ToString();
        questNameTMP.text = questName;
    }


    public void HideQuestTracker(){
        questTrackerPanel.SetActive(false);
        readyIcon.enabled = false;
    }
    public void ShowQuestTracker(){
        questTrackerPanel.SetActive(true);
        readyIcon.enabled = false;
    }
    public void ShowReadyIcon(){
        if (readyIcon !=null){
            readyIcon.enabled = true;
        }
    }
}

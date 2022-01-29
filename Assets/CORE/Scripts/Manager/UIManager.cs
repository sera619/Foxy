using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

    


public class UIManager : Singleton<UIManager>
{
    
    [Header("Settings")]
    [SerializeField] private Image healthBar;
    [SerializeField] private TextMeshProUGUI currentHealthTMP;
    [SerializeField] private Image shieldBar;
    [SerializeField] private TextMeshProUGUI currentShieldTMP;
    [SerializeField] private Image manaBar;
    [SerializeField] private TextMeshProUGUI currentManaTMP;


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

    private bool isPlayer;

    private float bossCurrentHealth;
    private float bossMaxHealth;

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

    public void UpdateMana(float currentMana, float maxMana, bool isThisPlayer){
        playerMaxMana = maxMana;
        playerCurrentMana =currentMana;
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


        }
    }

}

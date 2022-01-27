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
    [SerializeField] private Image shieldBar;
    [SerializeField] private TextMeshProUGUI currentHealthTMP;
    [SerializeField] private TextMeshProUGUI currentShieldTMP;

    [Header("Text")]
    [SerializeField] private TextMeshProUGUI coinsTMP;
    
    [Header("Boss")]
    [SerializeField] private GameObject bossHealthPanel;
    [SerializeField] private GameObject bossIntroPanel;
    
    private float playerCurrentHealth;
    private float playerMaxHealth;
    private float playerCurrentShield;
    private float playerMaxShield;

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
    private void InternalUpdate(){
        if(isPlayer){
            // healthbar update
            healthBar.fillAmount = Mathf.Lerp(healthBar.fillAmount, playerCurrentHealth/playerMaxHealth, 10f * Time.deltaTime);
            currentHealthTMP.text = playerCurrentHealth.ToString() + "/" + playerMaxHealth.ToString();

            //shieldbar update
            shieldBar.fillAmount = Mathf.Lerp(shieldBar.fillAmount, playerCurrentShield /playerMaxShield, 10f * Time.deltaTime);
            currentShieldTMP.text = playerCurrentShield.ToString() + "/" + playerMaxShield.ToString();

        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class EnemyHealth : MonoBehaviour
{   [Header("Settings")]
    [SerializeField] private GameObject healthPanel;
    
    
    [Header("Health Bar Settings")]
    [SerializeField] private TextMeshProUGUI healthText;
    [SerializeField] private Image healthBar;

    [Header("Mana Bar Settings")]
    [SerializeField]private GameObject manaBarPanel;
    [SerializeField] private Image manaBar;
    [SerializeField] private TextMeshProUGUI manaText;
    [Header("Shield Bar Settings")]
    [SerializeField] private GameObject shieldBarPanel;
    [SerializeField] private Image shieldbar;
    [SerializeField] private TextMeshProUGUI shieldText;



    [Header("Lvl/Name Settings")]
    [SerializeField] private TextMeshProUGUI nameTextfield;
    [SerializeField] private TextMeshProUGUI lvlTextfield;
    [SerializeField] private string enemyName;
    [SerializeField] private int enemyLevel;

    private Health enemyHealth;
    private float enemyCurrentHealth;
    private float enemyMaxHealth;
    private float enemyMaxShield;
    private float enemyCurrentShield;
    
    private float enemyCurrentMana;
    private float enemyMaxMana;
    private CharEffects charEffects;


    private void Start(){
        enemyHealth = GetComponent<Health>();
        healthPanel.SetActive(true);
        charEffects = GetComponent<CharEffects>();
    }
    

    private void Update(){
        UpdateHealth();

    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("PlayerWeapon")){
            TakeDamage(other.GetComponent<PlayerSword>().SwordDamage);
        }
        if(other.CompareTag("PlayerSpell")){
            TakeDamage(other.GetComponent<Projectile>().SpellDamage);
            charEffects.PlayEffect(6);
        }
    }

    private void TakeDamage(int damage){
        enemyHealth.TakeDamage(damage);
    }

    private void UpdateHealth(){
        if(enemyMaxShield == 0 ){
            shieldBarPanel.SetActive(false);
        }
        if(enemyMaxMana == 0){
            manaBarPanel.SetActive(false);
        }
        if(healthBar != null){
            // healbar
            healthBar.fillAmount = Mathf.Lerp(healthBar.fillAmount, enemyCurrentHealth / enemyMaxHealth, 10f * Time.deltaTime);
            healthText.text = enemyCurrentHealth.ToString() + " / " + enemyMaxHealth.ToString();
            // shieldbar
            shieldbar.fillAmount = Mathf.Lerp(shieldbar.fillAmount, enemyCurrentShield / enemyMaxShield, 10f * Time.deltaTime);
            shieldText.text = enemyCurrentShield.ToString() + " / " + enemyMaxShield.ToString();
            // manabar
            manaBar.fillAmount = Mathf.Lerp(manaBar.fillAmount, enemyCurrentMana / enemyMaxMana , 10f * Time.deltaTime);
            manaText.text = enemyCurrentMana.ToString() + " / " + enemyMaxMana.ToString();
            
            lvlTextfield.text = enemyLevel.ToString();
            nameTextfield.text = enemyName; 
            
        }
        if(enemyHealth.CurrentHealth <= 0){
            healthPanel.SetActive(false);
        }
    }
    public void UpdateEnemyMana(float currentMana, float maxMana){
        enemyCurrentMana = currentMana;
        enemyMaxMana = maxMana;
    }
    public void UpdateEnemyHealth(float currentHealth, float maxHealth, float currentShield, float maxShield ){
        enemyCurrentHealth = currentHealth;
        enemyMaxHealth = maxHealth;
        enemyMaxShield = maxShield;
        enemyCurrentShield = currentShield;
    }



}

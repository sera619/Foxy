using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public static Action OnBossDead;
    [Header("Health")]
    [SerializeField] private float initHealth = 10f;
    [SerializeField] private float maxHealth = 10f;

    [Header("Shield")]
    [SerializeField] private float initShield = 4f;
    [SerializeField] private float maxShield = 4f;

    [Header("Mana")]
    [SerializeField] private float initMana = 10f;
    [SerializeField] private float maxMana = 10f;

    [Header("Exp")]
    [SerializeField] private int initXp = 0;
    [SerializeField] private int maxXp = 20;
  
    [Header("Settings")]
    [SerializeField] private bool destroyObject;
    
    private Character character;
    private CharController controller;
    private Collider2D myCollider2D;
    private SpriteRenderer spriteRenderer;
    private bool isPlayer;
    private bool shieldBroken;

    private CharEffects charEffects;
    private GameManager gameManager;
    private EnemyHealth enemyHealth;

    public float CurrentHealth { get; set; }
    public float CurrentShield { get; set; }
    public float CurrentMana { get; set; }
    public float CurrentXP { get; set; }
    public float CurrentMaxXP { get; set; }

    public int CurrentLevel { get; set; }
    protected virtual void Awake(){
        character = GetComponent<Character>();
        controller = GetComponent<CharController>();
        myCollider2D = GetComponent<Collider2D>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        charEffects= GetComponent<CharEffects>();
        gameManager = FindObjectOfType<GameManager>();
    	enemyHealth = GetComponent<EnemyHealth>();

        CurrentHealth = initHealth;
        CurrentShield = initShield;
        CurrentMana = initMana;
        

        if(character != null){
            isPlayer = character.CharType == Character.CharTypes.Player;
        }
        if(isPlayer && SaveLoad.SaveExists("PlayerLevel")){
            CurrentLevel = SaveLoad.Load<int>("PlayerLevel");
            CurrentXP = SaveLoad.Load<float>("PlayerCurrentExp");
            CurrentMaxXP = SaveLoad.Load<float>("PlayerCurrentMaxExp");
            UpdatePlayerExp();
            UpdatePlayerLevel();
        }
        UpdateCharacterHealth();

    }
 
    protected virtual void Update(){
        if (charEffects != null){
            StartCoroutine(Timer());
        }
        if(!isPlayer){
            return;
        }
        if(Input.GetKeyDown(KeyCode.L)){
            TakeDamage(2);
            TakeMana(2);
        }
    }

    
    private void LevelUp(){
        CurrentXP = 0;
        maxXp = maxXp * 2;
        UpdatePlayerExp();
        UpdatePlayerLevel();

    }
    public void GetXP(float amount){
        CurrentXP +=  amount;
        if (CurrentXP == maxXp){
            LevelUp();
        }   
        UpdatePlayerExp();
    }
    public void GainHealth(int amount){
        CurrentHealth = Mathf.Min(CurrentHealth + amount , maxHealth);
        UpdateCharacterHealth();
        
    }
    public void GainShield(int amount){
        CurrentShield = Mathf.Min(CurrentShield + amount, maxShield);
        UpdateCharacterHealth();
    }

    public void GainMana(int amount){
        CurrentMana = Mathf.Min(CurrentMana + amount, maxMana);
        UpdateCharacterHealth();
    }


    public void TakeMana(int amount){
        if(CurrentMana<= 0){
            return;
        }
        if(character != null){
            CurrentMana -=amount;
            UpdateCharacterHealth();
            return;
        }
    }
    public void TakeDamage(int damage){
        if(CurrentHealth <= 0){
            return;
        }
        if(charEffects !=null)
            charEffects.PlayEffect(2);
        
        if (!shieldBroken && character != null && initShield > 0){
            CurrentShield -= damage;
            UpdateCharacterHealth();
            if(CurrentShield <= 0){
                shieldBroken = true;
            }
            return;
        }

        CurrentHealth -= damage;
        UpdateCharacterHealth();
        if(CurrentHealth <= 0){
            Die();
        }
    }

    private void Die(){
        if(character != null){
            myCollider2D.enabled = false;
            spriteRenderer.enabled = false;

            character.enabled = false;
            controller.enabled = false;
            if(charEffects != null) {
                charEffects.PlayEffect(1);
            }
            if(character.CharType == Character.CharTypes.Player){
                gameManager.Save();
            }
        }
        if(destroyObject){
            DestroyObject();
        }
    }

    public void Revive(){
        if (character != null){
            myCollider2D.enabled = true;
            spriteRenderer.enabled = true;

            character.enabled = true;
            controller.enabled = true;
        }
        gameObject.SetActive(true);

        CurrentHealth = initHealth;
        CurrentShield = initShield;
        CurrentMana = initMana;

        UpdateCharacterHealth();
    }

    private void DestroyObject(){
        gameObject.SetActive(false);
    }

    private void UpdatePlayerLevel(){
        if(character != null && character.CharType == Character.CharTypes.Player){
            SaveLoad.Save<float>(CurrentLevel, "PlayerLevel");
            UIManager.Instance.UpdatePlayerLevel(CurrentLevel, true);
        }
    }


    private void UpdatePlayerExp(){
        if(character != null && character.CharType == Character.CharTypes.Player){
            SaveLoad.Save<float>(CurrentXP, "PlayerCurrentExp");
            SaveLoad.Save<float>(CurrentMaxXP, "PlayerCurrentMaxExp");
            UIManager.Instance.UpdatePlayerExp(CurrentXP, maxXp,true);
        }
    }

    private void UpdateCharacterHealth(){

        //Ene
        if(enemyHealth != null && character.CharType == Character.CharTypes.AI){
            enemyHealth.UpdateEnemyHealth(CurrentHealth, maxHealth,CurrentShield,maxShield);
            enemyHealth.UpdateEnemyMana(CurrentMana, maxMana);
        }

        //player health 
        if (character != null && character.CharType == Character.CharTypes.Player){
            UIManager.Instance.UpdateHealth(CurrentHealth , maxHealth , CurrentShield, maxShield, isPlayer);
            UIManager.Instance.UpdateMana(CurrentMana,maxMana, isPlayer);
        }
    }



    private IEnumerator Timer(){
            if(charEffects.DeadEffect){
                yield return new WaitForSeconds(1);
                charEffects.IsPlaying = false;
                charEffects.DeadEffect = false;
                charEffects.SpriteRenderer.enabled = false;
                if(isPlayer){
                    UIManager.Instance.ShowDeathScreen();
                }
            }
            if(charEffects.HitEffect){
                yield return new WaitForSeconds(0.2f);
                charEffects.IsPlaying = false;
                charEffects.HitEffect = false;
                charEffects.SpriteRenderer.enabled = false;
            } 
            if(charEffects.ExplodeEffect){
                yield return new WaitForSeconds(1);
                charEffects.IsPlaying = false;
                charEffects.ExplodeEffect = false;
                charEffects.SpriteRenderer.enabled = false;
            }
    }

}

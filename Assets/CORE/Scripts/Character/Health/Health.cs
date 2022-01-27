using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public static Action OnBossDead;
    [Header("Health")]
    [SerializeField] private float initHealth = 10f;
    [SerializeField] private float maxHealth = 10f;

    [Header("Shield")]
    [SerializeField] private float initShield = 4f;
    [SerializeField] private float maxShield = 4f;

    [Header("Settings")]
    [SerializeField] private bool destroyObject;
    
    private Character character;
    private CharController controller;
    private Collider2D myCollider2D;
    private SpriteRenderer spriteRenderer;
    private EnemyHealth enemyHealth;
    private bool isPlayer;
    private bool shieldBroken;

    public float CurrentHealth { get; set; }
    public float CurrentShield { get; set; }

    private void Awake(){
        character = GetComponent<Character>();
        controller = GetComponent<CharController>();
        myCollider2D = GetComponent<Collider2D>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();

        CurrentHealth = initHealth;
        CurrentShield = initShield;

        if(character != null){
            isPlayer = character.CharType == Character.CharTypes.Player;
        }

        UpdateCharacterHealth();

    }

    private void Update(){
        if(Input.GetKeyDown(KeyCode.L)){
            TakeDamage(2);
        }
    }

    public void GainHealth(int amount){
        CurrentHealth = Mathf.Min(CurrentHealth + amount , maxHealth);
        UpdateCharacterHealth();
        
    }
    public void GainShield(int amount){
        CurrentShield = Mathf.Min(CurrentShield + amount, maxShield);
        UpdateCharacterHealth();
    }

    public void TakeDamage(int damage){
        if(CurrentHealth <= 0){
            return;
        }
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

        UpdateCharacterHealth();
    }

    private void DestroyObject(){
        gameObject.SetActive(false);
    }
    private void UpdateCharacterHealth(){
        if (character != null && character.CharType == Character.CharTypes.Player){
            UIManager.Instance.UpdateHealth(CurrentHealth , maxHealth , CurrentShield, maxShield, isPlayer);

        }
    }



}

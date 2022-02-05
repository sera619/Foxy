using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharPotion : CharComponents
{
    [Header("Potion Settings")]
    [SerializeField] private int healPotion;
    [SerializeField] private int speedPotion;
    [SerializeField] private int manaPotion;

    public int CurrentManaPotion { get; set; }
    public int CurrentSpeedPotion { get; set; }
    public int CurrentHealthPotion { get; set; } 

    private bool canDrink = true;

    private bool potionActive;

    private float potionDuration = 3f;
    private float potionCooldown = 2.5f;

    private int hpToAdd = 4;
    private int manaToAdd = 5;
  

   
    protected override void Start() {
        base.Start();
        GameEvents.SaveInitiated += Save;
        if(SaveLoad.SaveExists("PlayerMPotion")){
            Load();
            UpdatePotions();
        }else{
            CurrentHealthPotion = healPotion;
            CurrentManaPotion = manaPotion;
            CurrentSpeedPotion = speedPotion;
            UpdatePotions();
        }

    }

    protected override void HandleAbility()
    {
        base.HandleAbility();
        StartCoroutine(Timer());
    }

    private IEnumerator Timer(){
        if(!canDrink){
            yield return new WaitForSeconds(potionCooldown);
            canDrink = true;
        }
        if(potionActive){
            yield return new WaitForSeconds(potionDuration);
            potionActive = false;
            charMovement.ResetSpeed();
        }

    }



    protected override void HandleInput()
    {
        if(Input.GetKeyDown(KeyCode.Alpha5)){
            UseSpeedPotion();
        }
        if(Input.GetKeyDown(KeyCode.Alpha3)){
            UseHealPotion();
        }
        if(Input.GetKeyDown(KeyCode.Alpha4)){
            UseManaPotion();
        }
    }


    private void UseManaPotion(){
        if(CurrentManaPotion >= 0 && canDrink){
            canDrink = false;
            RemovePotion(3,1);
            charHealth.GainMana(manaToAdd);
        }
    }


    private void UseHealPotion(){
        if (CurrentHealthPotion >= 0 && canDrink){
            canDrink = false;
            RemovePotion(2, 1);
            charHealth.GainHealth(hpToAdd);
        }else{
            return;
        }
    }

    private void UseSpeedPotion(){
        if(CurrentSpeedPotion >= 0 && canDrink){
            canDrink = false;
            potionActive= true;
            RemovePotion(1, 1);
            charMovement.MoveSpeed *= 2;
        }else{
            return;
        }
    }


    private void Save(){
        SaveLoad.Save<int>(CurrentHealthPotion, "PlayerHPotion");
        SaveLoad.Save<int>(CurrentManaPotion, "PlayerMPotion");
        SaveLoad.Save<int>(CurrentSpeedPotion, "PlayerSPotion");
    }

    private void Load(){
        if (SaveLoad.SaveExists("PlayerHPotion")){
            AddPotion(2, SaveLoad.Load<int>("PlayerHPotion"));
        }
        if (SaveLoad.SaveExists("PlayerMPotion")){
            AddPotion(3, SaveLoad.Load<int>("PlayerMPotion"));
        }
        if (SaveLoad.SaveExists("PlayerSPotion")){
            AddPotion(1, SaveLoad.Load<int>("PlayerSPotion"));
        }
    }

    
    public void AddPotion(int potionID, int value){
        if (potionID == 1){
            CurrentSpeedPotion += value;
                        if(character.CharType == Character.CharTypes.Player){
                UpdatePotions();
            }
        }
        if (potionID == 2){
            CurrentHealthPotion += value;
            if(character.CharType == Character.CharTypes.Player){
                UpdatePotions();
            }
        }
        if (potionID == 3){
            CurrentManaPotion += value;
            if(character.CharType == Character.CharTypes.Player){
                UpdatePotions();
            }
        }
     
        else {
            return;
        }
    }

    public void RemovePotion(int potionID, int value){
        if (potionID == 1){
            CurrentSpeedPotion -= value;
            UpdatePotions();
        }
        if (potionID == 2){
            CurrentHealthPotion -= value;
            UpdatePotions();
        }
        if (potionID == 3){
            CurrentManaPotion -= value;
            UpdatePotions();
        }
     
        else {
            return;
        }
    }

    private void UpdatePotions(){
        InventoryManager.Instance.UpdatePotions(CurrentManaPotion,CurrentHealthPotion,CurrentSpeedPotion, true);

    }


}

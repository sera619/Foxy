using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharSpell : CharComponents
{

    public static Action OnStartCasting;

    [Header("Settings")]
    [SerializeField] private PlayerSpell spellToUse;
    [SerializeField] private Transform spellHolderPosition;

    public PlayerSpell CurrentSpell { get; set; }
    public PlayerSpell SecondSpell { get; set; }
    protected override void Start()
    {
        base.Start();
        EquipSpell(spellToUse, spellHolderPosition);
        
    }

    protected override void HandleInput()
    {
        if(character.CharType == Character.CharTypes.Player){
            if(Input.GetKey(KeyCode.Q)){
                Shoot();
            }
            if(Input.GetKey(KeyCode.R)){
                Reload();
            }
            if(Input.GetKeyDown(KeyCode.F1) && SecondSpell != null){
                EquipSpell(spellToUse, spellHolderPosition);
            }
            if(Input.GetKeyDown(KeyCode.F2) && SecondSpell != null){
                EquipSpell(SecondSpell, spellHolderPosition);
            }
        }
        
    }


    public void Shoot(){
        if(CurrentSpell == null){
            return;
        }
        CurrentSpell.UseSpell();
        if(character.CharType == Character.CharTypes.Player){
            OnStartCasting?.Invoke();
            //TODO UI MANAER Ammo
        }

    }

    public void Reload(){
        if(CurrentSpell == null){
            return;
        }
        CurrentSpell.Reload();
        if(character.CharType == Character.CharTypes.Player){
            // TODO: UI MANAGER Ammo 
        }
    }

    public void StopSpell(){
        if(CurrentSpell == null){
            return;
        }
        // TODO: Knockback 
        return;
    }

    public void EquipSpell(PlayerSpell spell, Transform spellPosition){
        if(CurrentSpell != null){
            CurrentSpell.SpellAmmo.SaveAmmo();
            Destroy(GameObject.Find("Pool"));
            Destroy(CurrentSpell.gameObject);
        }
        
        
        CurrentSpell = Instantiate(spell, spellPosition.position, spellPosition.rotation);
        CurrentSpell.transform.parent = spellPosition;
        CurrentSpell.SetOwner(character);
        
        if(character.CharType == Character.CharTypes.Player){
            // TODO: UI MANAGER Weapon AMMO 
        }
    
    
    }


}

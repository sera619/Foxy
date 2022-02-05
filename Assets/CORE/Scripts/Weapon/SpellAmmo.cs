using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellAmmo : MonoBehaviour
{
   private PlayerSpell playerSpell;

   private readonly string SPELL_AMMO_SAVELOAD = "Spell_";
   private void Awake(){
       playerSpell = GetComponent<PlayerSpell>();
       LoadWeapoinMagazineSize();
       
   }


    public void ConsumeAmmo(){
        if(playerSpell.UseMagazine){
            playerSpell.CurrentAmmo -= 1;

        }
    }

    public bool CanUseSpell(){
        if(playerSpell.CurrentAmmo > 0){
            return true;
        }
        return false;
    }

    public void RefillAmmo(){
        if(playerSpell.UseMagazine){
            playerSpell.CurrentAmmo = playerSpell.MagazineSize;
        }
    }

    public void LoadWeapoinMagazineSize(){
        int savedAmmo = LoadAmmo();
        playerSpell.CurrentAmmo = savedAmmo < playerSpell.MagazineSize ? LoadAmmo() : playerSpell.MagazineSize;
    }


    public int LoadAmmo(){
        
        return PlayerPrefs.GetInt(SPELL_AMMO_SAVELOAD + playerSpell.SpellName, playerSpell.MagazineSize);
    }

    public void SaveAmmo(){
        PlayerPrefs.SetInt(SPELL_AMMO_SAVELOAD + playerSpell.SpellName, playerSpell.CurrentAmmo);
    
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinDrop : Collectables
{
    [SerializeField] private int goldToAdd = 10;

    protected override void Pick()
    {
        AddCoins(character);
    }



    private void AddCoins(Character character){
        if(character != null && character.CharType == Character.CharTypes.Player){
            
            GoldManager.Instance.AddCoins(goldToAdd);
            character.GetComponent<CharGold>().AddCoins(goldToAdd);

        } 
    }

}
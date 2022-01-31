using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldUp : Collectables
{
    [SerializeField] private int shieldToAdd = 1;
    [SerializeField] private ParticleSystem effect;
    private Collider2D myCollider2D;
    

    protected override void Pick(){
        AddShield(character);
    }

    
    protected override void PlayEffects(){
        Instantiate(effect, transform.position, Quaternion.identity);
    }
    
    public void AddShield(Character character){
        character.GetComponent<Health>().GainShield(shieldToAdd);
    }





}

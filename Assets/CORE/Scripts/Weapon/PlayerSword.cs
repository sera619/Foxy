using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSword : MonoBehaviour
{

    [SerializeField] private CharAttack charAttack;
    [SerializeField] private int swordDamage= 2;
    public int SwordDamage { get; set;}
    private Collider2D myCollider;

    private void Start() {
        SwordDamage =  swordDamage;
    }
    public bool canAttack(){
        return charAttack.canAttack = true;
    }



    private void EquipSword(){
        
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSword : MonoBehaviour
{

    [Header("Settings")]
    [SerializeField] private int swordDamage;

    public int SwordDamage => swordDamage;

    private Collider2D myCollider;


    private void Start(){
        myCollider = GetComponent<Collider2D>();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("WorldObject")){
            return;
        }
        if(other.CompareTag("Enemy")){
            other.GetComponent<Health>().TakeDamage(SwordDamage);
        }    
    }




}

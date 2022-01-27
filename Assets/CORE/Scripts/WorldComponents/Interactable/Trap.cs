using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    [Header("Trap Settings")]
    [SerializeField] private int trapDamage = 2;

    private Collider2D myCollider;
    private bool isPlayer;
    private Character player;

    private void Start() {
        myCollider = GetComponent<Collider2D>();
    }



    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player")){
            player = other.GetComponent<Character>();
            DoDamage();
        }
    }

    private void DoDamage() {
        if(player != null){
            player.GetComponent<Health>().TakeDamage(trapDamage);
        }
    }






}

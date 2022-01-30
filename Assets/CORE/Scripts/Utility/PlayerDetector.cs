using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetector : MonoBehaviour
{

    public bool IsPlayer;
    [SerializeField] private Collider2D myCollider;

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player")){
            IsPlayer = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if(other.CompareTag("Player")){
            IsPlayer = false;
        }
    }
}

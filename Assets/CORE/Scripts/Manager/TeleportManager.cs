using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class TeleportManager : MonoBehaviour
{
    enum TeleportLocation{
        House,
        Dungeon,
        Shop,
        World
    }
    [Header("Teleport Settings")]
    [SerializeField] private TeleportLocation teleportLocation = TeleportLocation.House;
    
    private Collider2D myCollider;

    private void Start(){
        myCollider = GetComponent<Collider2D>();
    }



    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player")){
            TeleportPlayer();
        }
    }
    
    private void TeleportPlayer(){
        if (teleportLocation == TeleportLocation.House){
            SceneManager.LoadScene(1);
        }
        if(teleportLocation == TeleportLocation.Shop){
            SceneManager.LoadScene(4);
        }
        if(teleportLocation == TeleportLocation.Dungeon){
            SceneManager.LoadScene(3);
        }
        if(teleportLocation == TeleportLocation.World){
            SceneManager.LoadScene(2);
        }
    }






}

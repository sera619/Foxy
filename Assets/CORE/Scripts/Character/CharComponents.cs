using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharComponents : MonoBehaviour
{
    protected float horizontalInput;
    protected float verticalInput;
    protected Character character;
    protected CharController controller;
    protected CharMovement charMovement;
    protected CharPotion charPotion;

    protected Health charHealth;
    private Rigidbody2D myBody;
   
    protected virtual void Start(){
        controller = GetComponent<CharController>();
        character = GetComponent<Character>();
        charMovement = GetComponent<CharMovement>();
        charHealth = GetComponent<Health>();
        charPotion = GetComponent<CharPotion>();
        myBody = GetComponent<Rigidbody2D>();

    }

    protected virtual void Update(){
        HandleAbility();
    }

    protected virtual void HandleAbility(){
        InternalInput();
        HandleInput();
    }

    protected virtual void HandleInput(){

    }
    protected virtual void InternalInput(){
        if(character.CharType == Character.CharTypes.Player){
            horizontalInput = Input.GetAxisRaw("Horizontal");
            verticalInput = Input.GetAxisRaw("Vertical");
        }
    }

}

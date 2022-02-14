using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharController : MonoBehaviour
{
    public bool NormalMovement { get; set;}
    public Vector2 CurrentMovement { get; set; }
    private Rigidbody2D myBody;
    private Character character;

    private void Start(){
        NormalMovement = true;
        myBody = GetComponent<Rigidbody2D>();
        character = GetComponent<Character>();
        if(character.CharType == Character.CharTypes.Player){
            DialogManager.Instance.OnCloseDialog += () => StartMovement();
            DialogManager.Instance.OnShowDialog += () => StopMovement();
        }
    }

    public void StopMovement(){
        NormalMovement = false;
    }
    public void StartMovement(){
        NormalMovement = true;
    }

    private void FixedUpdate(){
        if(NormalMovement){
            MoveCharacter();
        }
    }


    private void MoveCharacter(){
        Vector2 currentMovePosition = myBody.position + CurrentMovement * Time.fixedDeltaTime;
        myBody.MovePosition(currentMovePosition);
    }

    public void MovePosition(Vector2 newPosition){
        myBody.MovePosition(newPosition);

    }

    public void SetMovement(Vector2 newPosition){
        CurrentMovement = newPosition;
    }

}

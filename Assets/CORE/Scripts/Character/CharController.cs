using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharController : MonoBehaviour
{
    public bool NormalMovement { get; set;}
    public Vector2 CurrentMovement { get; set; }
    private Rigidbody2D myBody;

    private void Start(){
        NormalMovement = true;
        myBody = GetComponent<Rigidbody2D>();
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

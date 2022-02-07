using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharDirection : CharComponents
{
    // Start is called before the first frame update
    
    public bool FaceingRight { get; set; }
    public bool FaceingLeft { get; set; }
    public bool FaceingUp { get; set; }
    public bool FaceingDown { get; set; }
    
    private void Awake(){
        FaceingRight = true;
    }

    
    protected override void HandleAbility()
    {
        base.HandleAbility();
    
    }


    private void GetDirection(){
        if(character != null){
            if(character.CharAnimator.GetFloat("LastHorizontal") <= 0){
                FaceingRight = true;
                FaceingLeft = false;
            }
            if(character.CharAnimator.GetFloat("LastHorizontal") >= 0){
                FaceingRight = false;
                FaceingLeft = true;
            }
            if(character.CharAnimator.GetFloat("LastVertical") <= 0){
                FaceingDown = false;
                FaceingUp = true;
            }
            if(character.CharAnimator.GetFloat("LastVertical") >= 0){
                FaceingDown = true;
                FaceingUp = false;
            }

        }


    }


}

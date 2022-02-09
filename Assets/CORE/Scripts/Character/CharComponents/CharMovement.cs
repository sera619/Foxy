using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharMovement : CharComponents
{

    [SerializeField] private float walkSpeed = 6f;
    public float MoveSpeed { get; set; }
    private readonly int movingParameter = Animator.StringToHash("Move");
    
    protected override void Start()
    {
        base.Start();
        MoveSpeed = walkSpeed;
    }

    // Update is called once per frame
    protected override void HandleAbility()
    {
        base.HandleAbility();
        MoveCharacter();
        UpdateAnimations();
    }

    private void MoveCharacter(){
        Vector2 movement = new Vector2(horizontalInput, verticalInput);
        Vector2 moveInput = movement;
        Vector2 movementNormalized = moveInput.normalized;
        Vector2 movementSpeed  = movementNormalized * MoveSpeed;
        controller.SetMovement(movementSpeed);

    }

    private void UpdateAnimations(){
        if (Mathf.Abs(horizontalInput)> 0.1f || Mathf.Abs(verticalInput) > 0.1f){
            if(character.CharAnimator != null){
                character.CharAnimator.SetBool(movingParameter, true);
                character.CharAnimator.SetFloat("Horizontal", horizontalInput);
                character.CharAnimator.SetFloat("Vertical", verticalInput); 
                character.CharAnimator.SetFloat("LastVertical", verticalInput);
                character.CharAnimator.SetFloat("LastHorizontal", horizontalInput);
            }
        }else{
            if (character.CharAnimator != null){
                character.CharAnimator.SetBool(movingParameter, false);
            }
        }
    }

    public void ResetSpeed(){
        MoveSpeed = walkSpeed;
    }

    public void SetHorizontal(float value){
        horizontalInput = value;
        if(Mathf.Abs(horizontalInput) > 0.1f){
            
        }
    }

    public void SetVertical(float value){
        verticalInput = value;
    }

}

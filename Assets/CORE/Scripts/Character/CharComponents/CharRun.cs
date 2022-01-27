using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharRun : CharComponents
{
    [SerializeField] private float runSpeed = 10f;
    protected override void Start()
    {
        base.Start();
    }
    
    protected override void HandleInput(){
        if(Input.GetKey(KeyCode.LeftShift)){
            Run();
        }
        if(Input.GetKeyUp(KeyCode.LeftShift)){
            StopRun();
        }
    }

    private void Run(){
        charMovement.MoveSpeed = runSpeed;
    }

    private void StopRun(){
        charMovement.ResetSpeed();
    }

}


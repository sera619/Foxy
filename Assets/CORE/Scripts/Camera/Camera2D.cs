using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera2D : Singleton<Camera2D>
{
    private enum CameraMode{
        Update,
        FixedUpdate,
        LateUpdate
    }
    [Header("Target")]
    [SerializeField] private Transform targetTransform;

    [Header("Offset")]
    [SerializeField] private Vector2 offset;

    [Header("Mode")] 
    [SerializeField] private CameraMode cameraMode = CameraMode.Update;
    public Transform Target { get; set; }
    public Vector2 Offset { get; set; }
    public Vector2 PlayerOffset  => offset;
    
    private void Start(){
        Target = targetTransform;
    }

    private void Update(){
        if(cameraMode == CameraMode.Update){
            FollowTarget();
        }
    }

    private void FixedUpdate(){
        if (cameraMode == CameraMode.FixedUpdate){
            FollowTarget();
        }
    }

    private void LateUpdate(){
        if(cameraMode == CameraMode.LateUpdate){
            FollowTarget();
        }
    }




    private void FollowTarget(){
        Vector3 desiredPosition = new Vector3(x: Target.position.x + Offset.x ,y: Target.position.y + Offset.y, z: transform.position.z);
        transform.position = desiredPosition;
    }


}

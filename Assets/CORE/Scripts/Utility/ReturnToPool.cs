using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnToPool : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private LayerMask objectMask;
    [SerializeField] private float lifeTIme = 2f;

    [Header("Effects")]
    [SerializeField] private ParticleSystem impactEffect;




    private void Return(){
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(Lib.CheckLayer(other.gameObject.layer, objectMask)){
            impactEffect.Play();
            Invoke(nameof(Return), impactEffect.main.duration);
        }
    }

    private void OnEnable() {
        if(lifeTIme > 0 ){
            Invoke(nameof(Return), lifeTIme);
        }    
    }
    private void OnDisable(){
        CancelInvoke();
    }









}

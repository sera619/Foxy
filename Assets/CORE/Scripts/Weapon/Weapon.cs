using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{

    [Header("Name")]
    [SerializeField] private string weaponName= "";

    [Header("Settings")]
    [SerializeField] private float timeBtwShoots = 0.5f;
    
    [Header("Range Settings")]
    [SerializeField] private bool useMagazine =  false; 
    [SerializeField] private int magazineSize = 20;
    [SerializeField] private bool autoReload = false;

    [Header("Recoil Settings")]
    [SerializeField] private bool useRecoil = false;
    [SerializeField] private int recoilForce = 5;
    
    public Character WeaponOwner { get; set; }


    public string WeaponName => weaponName;
    public bool UseMagazine => useMagazine;
    public int MagazineSize => magazineSize;
    public bool CanAttack { get; set;}

    public virtual void UseWeapon(){

    }

    public void  StopWeapon(){

    }

    private void StartShooting(){

    }

    private void RequestShot(){

    }

    protected virtual void WeaponCanShoot(){

    }

    public void SetOwner(Character owner){

    }

    public void Reload(){

    }



}

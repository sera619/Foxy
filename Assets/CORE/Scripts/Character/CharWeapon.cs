using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharWeapon : CharComponents
{
    [Header("Weapon Settings")]
    [SerializeField] private Weapon weaponToUse;
    [SerializeField] private Transform weaponHolderPosition;
    public Weapon CurrentWeapon { get; set; }
    public Weapon SecondaryWeapon { get; set; }



    protected override void Start()
    {
        base.Start();
    }



    public void EquipWeapon(Weapon weapon, Transform weaponPosition){
        CurrentWeapon = Instantiate(weapon, weaponPosition.position, weaponPosition.rotation);
        CurrentWeapon.transform.parent = weaponPosition;

    
    }



}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeapon : MonoBehaviour
{
    [SerializeField] private int enemyWeaponDamage = 2;
    private Collider2D myCollider2D;

    public int EnemyWeaponDamage;



    private void Start(){
        EnemyWeaponDamage = enemyWeaponDamage;
    }



}


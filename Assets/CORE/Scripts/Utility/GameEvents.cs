using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameEvents : MonoBehaviour
{
    public static System.Action SaveInitiated;
    public static System.Action LoadInitiated;
    public static System.Action DeleAllFilesInitiated;

    public static System.Action EnemyDeath;

    public static void OnEnemyDeath(){
        EnemyDeath?.Invoke();
    }

    public static void OnSaveInitiated(){
        SaveInitiated?.Invoke();
    }



}

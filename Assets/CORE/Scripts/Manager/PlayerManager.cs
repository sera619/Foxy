using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : Singleton<PlayerManager>
{



    [SerializeField] private float playerExp;
    [SerializeField] private float currentPlayerExp;
    [SerializeField] private string playerName;
    [SerializeField] private int playerLevel;


    public float CurrentPlayerXP { get; set; }
    public string PlayerName { get; set; }
    public int PlayerLevel { get; set; }
    public float PlayerExp { get; set; }


    public void GainExp(float exp){
        
    }






}
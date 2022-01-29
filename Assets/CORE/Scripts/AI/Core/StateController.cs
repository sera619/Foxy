using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateController : MonoBehaviour
{
    [Header("State")] 
    [SerializeField] private AIState currentState;
    [SerializeField] private AIState remainState;

    
    /// <summary>
    /// Returns the target of this Enemy
    /// </summary>
    public Transform Target { get; set; }
    
    /// <summary>
    /// Returns a reference to this enemy movement
    /// </summary>
    public CharMovement CharacterMovement { get; set; }

    /// <summary>
    /// Returns this character weapon
    /// </summary>
   
    
    /// <summary>
    /// Returns a reference to this enemy path
    /// </summary>
    public Path Path { get; set; }


    public Transform Player { get; set; }

    public Health PlayerHealth { get; set; }
    
    /// <summary>
    /// Returns the collider of this enemy
    /// </summary>
    public Collider2D Collider2D { get; set; }

    //    public BossCirclePattern BossCirclePattern { get; set; }
    //public BossRandomPattern BossRandomPattern { get; set; }
    //public BossSpiralPattern BossSpiralPattern { get; set; }
    
    private void Awake()
    {
        CharacterMovement = GetComponent<CharMovement>();
        Path = GetComponent<Path>();
        Collider2D = GetComponent<Collider2D>();

        Player = GameObject.FindWithTag("Player").transform;
        PlayerHealth = Player.GetComponent<Health>();
        /*
        BossCirclePattern = GetComponent<BossCirclePattern>();
        BossRandomPattern = GetComponent<BossRandomPattern>();
        BossSpiralPattern = GetComponent<BossSpiralPattern>();
        */    
    }

    private void Update()
    {
        currentState.EvaluateState(this);
    }

    public void TransitionToState(AIState nextState)
    {
        if (nextState != remainState)
        {
            currentState = nextState;
        }
    }
}

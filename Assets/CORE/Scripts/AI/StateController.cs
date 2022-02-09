using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class StateController : MonoBehaviour
{
    [Header("State")] 
    [SerializeField] private AIState currentState;
    [SerializeField] private AIState remainState;

    [Header("Field Of View")] 
    [SerializeField] private Light2D fieldOfView;
    
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
    public CharSpell CharSpell { get; set; }

    
    /// <summary>
    /// Returns a reference to this enemy path
    /// </summary>
    public Path Path { get; set; }

    public Light2D FieldOfView => fieldOfView;

    public Transform Player { get; set; }

    public Health PlayerHealth { get; set; }
    
    /// <summary>
    /// Returns the collider of this enemy
    /// </summary>
    public Collider2D Collider2D { get; set; }

    
    private void Awake()
    {
        CharacterMovement = GetComponent<CharMovement>();
        CharSpell = GetComponent<CharSpell>();
        Path = GetComponent<Path>();
        Collider2D = GetComponent<Collider2D>();

        Player = GameObject.FindWithTag("Player").transform;
        PlayerHealth = Player.GetComponent<Health>();


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

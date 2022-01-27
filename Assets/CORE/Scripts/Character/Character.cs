using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public enum CharTypes {
        Player,
        AI
    }

    [SerializeField] private CharTypes charType;
    [SerializeField] private GameObject characterSprite;
    [SerializeField] private Animator animator;

    public CharTypes CharType => charType;
    public GameObject CharacterSprite => characterSprite;
    public Animator CharAnimator => animator;
    void Start(){

    }
    void Update(){
        
    }
}

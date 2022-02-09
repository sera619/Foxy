using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpell : MonoBehaviour
{
    [Header("Name")]
    [SerializeField] private string spellName = "";

    [Header("Settings")]
    [SerializeField] private float timeBtwCasts = 0.5f;

    
    [Header("Spell")]
    [SerializeField] private bool useMagazine = true;
    [ SerializeField] private int magazineSize = 30;
    [SerializeField] private bool autoReload = true;

    [Header("Effects")]
    [SerializeField] private ParticleSystem spellEffect;

    public Character SpellOwner { get; set; }
    public int CurrentAmmo  { get; set; }
    public SpellAmmo SpellAmmo { get; set;}

    public int MagazineSize => magazineSize;
    public bool UseMagazine => useMagazine;
    public bool CanCast { get; set; }

    public string SpellName => spellName;
    private float nextCastTime;
    private CharController controller;
    private Animator animator;
    private readonly int spellUseParameter = Animator.StringToHash("SpellUse");

    protected virtual void Awake(){
        SpellAmmo = GetComponent<SpellAmmo>();
        //animator = GetComponent<Animator>();
        
    }

    protected virtual void Update(){
        SpellCanShoot();
    }


    // Spell Logic
    public virtual void UseSpell(){
        StartCast();
    }

    private void StartCast(){
        if(useMagazine){
            if(SpellAmmo != null){
                if (SpellAmmo.CanUseSpell()){
                    RequestShot();            
                }else{
                    if(autoReload){
                        Reload();
                    }
                }
            }
        }else{
            RequestShot();
        }
    }


    protected virtual void RequestShot(){
        if(!CanCast){
            return;
        }
        //animator.SetTrigger(spellUseParameter);
        SpellAmmo.ConsumeAmmo();
        //spellEffect.Play();
    }


    public void Reload(){
        if (SpellAmmo != null){
            if (useMagazine){
                SpellAmmo.RefillAmmo();
            }
        }
    }


    protected virtual void SpellCanShoot(){
        if(Time.time > nextCastTime){
            CanCast = true;
            nextCastTime = Time.time + timeBtwCasts;
        }
    }

    public void SetOwner(Character owner){
        SpellOwner = owner;
        controller = SpellOwner.GetComponent<CharController>();
    }







}


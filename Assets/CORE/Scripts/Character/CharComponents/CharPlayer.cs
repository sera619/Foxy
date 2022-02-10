using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharPlayer : MonoBehaviour
{

    [SerializeField] private DialogUI dialogUI;

    public DialogUI DialogUI => dialogUI;
    
    public IInteractable IInteractable { get; set; }
    private CharController charController;
    private Character character;
    

    private void Start() {
        charController= GetComponent<CharController>();
        character = GetComponent<Character>();
    }

    private void Update() {
        if(Input.GetKeyDown(KeyCode.E)){
            // interaction with TextBox
            if(dialogUI.IsOpen){
                return;
            }
            IInteractable?.Interact(this);
        }
    }    
        
        
        









}

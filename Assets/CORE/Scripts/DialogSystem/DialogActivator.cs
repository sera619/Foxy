using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogActivator : MonoBehaviour, IInteractable
{

    [SerializeField] private DialogObject dialogObject;
    [SerializeField] private Collider2D myCollider;
    

    public void UpdateDialogObject(DialogObject dialogObject){
        this.dialogObject = dialogObject;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player") && other.TryGetComponent(out CharPlayer player)){
            player.IInteractable = this;
        }        
    }


    private void OnTriggerExit2D(Collider2D other) {
        if (other.CompareTag("Player") && other.TryGetComponent(out CharPlayer player)){
            if (player.IInteractable is DialogActivator dialogActivator && dialogActivator == this){
                player.IInteractable = null;
            }



        }
    }

    public void Interact(CharPlayer player){

        foreach (DialogResponseEvents responseEvents in GetComponents<DialogResponseEvents>()){
            if (responseEvents.DialogObject == dialogObject){
                player.DialogUI.AddResponseEvents(responseEvents.Events);
                break;
            }
        }


        player.DialogUI.ShowDialog(dialogObject);
    }
}

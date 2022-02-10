using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class DialogResponseEvents : MonoBehaviour
{
    
    [SerializeField] private DialogObject dialogObject;
    [SerializeField] private ResponseEvent[] events;

    public ResponseEvent[] Events => events;
    public DialogObject DialogObject => dialogObject;

    public void OnValidate() {
        if (dialogObject == null) return;

        if (dialogObject.Responses == null) return;
        if (events != null && events.Length == dialogObject.Responses.Length) return;
        if (events == null){
            events = new ResponseEvent[dialogObject.Responses.Length];
        }else{
            Array.Resize(ref events, dialogObject.Responses.Length);
        }

        for ( int i = 0; i < dialogObject.Responses.Length; i ++){
            
            Response response = dialogObject.Responses[i];
            if (events[i] != null){
                events[i].name = response.ResponseText;
                continue;
            }
            events[i] = new ResponseEvent() { name = response.ResponseText};
        }

    
    }


}

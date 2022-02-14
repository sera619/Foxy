using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class StreetLight : MonoBehaviour
{
    private GameObject[] lights;
    public bool IsOn { get; set; }

    private void Start() {
        lights = GameObject.FindGameObjectsWithTag("Lights");
    }


    public void LightOn(){
        foreach (GameObject light in lights){
            light.gameObject.SetActive(false);
            IsOn = true;
        }
    }

    public void LightOff(){
        foreach (GameObject light in lights){
            light.gameObject.SetActive(true);
            IsOn = false;
        }
    }



}

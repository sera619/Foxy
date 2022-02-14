using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;
using UnityEngine.SceneManagement;

public class Relexa : MonoBehaviour
{
    [SerializeField] private Color colorYelllow;
    [SerializeField] private Color colorBlue;
    [SerializeField] private Color colorRed;
    [SerializeField] private Color colorGreen;

    public GameObject[] lights;

    public Color ColorRed => colorRed;
    public Color ColorGreen => colorGreen;
    public Color ColorBlue => colorBlue;
    public Color ColorYellow => colorYelllow;
    
    
    public bool LightsOn = true;
    
    private bool changeColor = false;

    private void Start() {
        lights = GameObject.FindGameObjectsWithTag("Lights");

    }

    private void Update(){

    }

    public void ChangeLightColor(Color color){
        foreach(GameObject light in lights){
            light.transform.GetComponent<Light2D>().color = color;
        }
    }



    public void LightOn(){
        foreach(GameObject light in lights){
            LightsOn = true;
            light.transform.GetComponent<Light2D>().enabled = true;
        }
    }

    public void LightOff(){
        foreach(GameObject light in lights){
            LightsOn = false;
            light.transform.GetComponent<Light2D>().enabled = false;
        }
    }



    public void LightYellow(){
        ChangeLightColor(new Color(1.0f, 0.97f, 0.14f));
    }
    public void LightBlue(){
        ChangeLightColor(new Color(0.0f, 0.5f,1.0f));
    }
    public void LightGreen(){
        ChangeLightColor(new Color(0.18f, 0.51f, 0.27f));
    }

    public void LightRed(){
        ChangeLightColor(new Color(1.0f, 0.0f, 0.0f));
    }

    public void LightWhite(){
        ChangeLightColor(new Color(1.0f, 1.0f, 1.0f));
    }


    public void TakePlayerOff(){
        SceneManager.LoadScene(3);
    }








    
}

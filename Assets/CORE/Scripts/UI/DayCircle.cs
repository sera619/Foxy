using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;


public class DayCircle : MonoBehaviour
{
    
    [Header("Light Settings")]
    [SerializeField] private Light2D light2d;

    [Header("Time Settings")]
    [SerializeField] public float dayLength = 10.0f;
    [SerializeField] public float nightLength = 10.0f;
    
    [SerializeField] [Range(0f, 1f)] float lerpTime;
    public Color dayColor = new Color(1.0f, 1.0f, 1.0f);
    public Color nightColor = new Color(0.25f, 0.25f, 0.6f);
    
    public bool daytime { get; private set; }
    private float timeRemaining;


    private void Update(){
        timeRemaining -= Time.deltaTime;
        if(timeRemaining <= 0){
            daytime = !daytime;
            if(daytime){
                light2d.color = Color.Lerp(nightColor, dayColor, lerpTime *  Time.time);
                timeRemaining = dayLength;

            }else{
                light2d.color = Color.Lerp(dayColor,nightColor, lerpTime * Time.time);
                timeRemaining = nightLength;
            }
        }
    }
    


}

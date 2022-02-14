using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GameEvent
{
    public string EventDescription;

}

public class BuildingEvent : GameEvent
{
    public string BuildingName;
    public BuildingEvent(string name){
        BuildingName = name;
    }
}
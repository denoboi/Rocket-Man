using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public static class EventManager
{
    public static FloatEvent OnFuelChange = new FloatEvent();
   
}

public class FloatEvent: UnityEvent<float> { }

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FuelManager : MonoBehaviour
{
    public static FuelManager instance;

    [HideInInspector]
    public float maxFuelAmount = 100;
    float currentFuelAmount;

    const float DECREASE_AMOUNT = 0.2f;

    public bool canFly = true;

    public float CurrentFuelAmount
    {
        get { return currentFuelAmount; }
        set { currentFuelAmount = value; }
    }


    void Awake()
    {
        instance = this;
        currentFuelAmount = maxFuelAmount;
    }

    public void DecreaseFuel()
    {
        CurrentFuelAmount -= DECREASE_AMOUNT;

        if(currentFuelAmount < 0)
        {
            canFly = false;
        }

        Debug.Log(currentFuelAmount);
        EventManager.OnFuelChange.Invoke(CurrentFuelAmount);
    }
    public void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            DecreaseFuel();
        }
    }
}

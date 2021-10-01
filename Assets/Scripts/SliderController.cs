using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderController : MonoBehaviour
{
    public Image fuelSlider;

    //private void OnEnable()
    //{
    //    EventManager.OnFuelChange.AddListener(ChangeSlider);
    //}

    //private void OnDisable()
    //{
    //    EventManager.OnFuelChange.RemoveListener(ChangeSlider);
    //}

    private void Update()
    {
        fuelSlider.fillAmount = FuelManager.instance.CurrentFuelAmount / FuelManager.instance.maxFuelAmount;
    }
    //void ChangeSlider(float fuel)
    //{
    //    fuelSlider.fillAmount = fuel / FuelManager.instance.maxFuelAmount;
    //    Debug.Log(fuel / 100f);
    //}
}

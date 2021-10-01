using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SliderController : MonoBehaviour
{
    public Image fuelSlider;
    public TextMeshProUGUI fuelText;

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
        fuelText.text = ((int)FuelManager.instance.CurrentFuelAmount).ToString() ;
    }
    //void ChangeSlider(float fuel)
    //{
    //    fuelSlider.fillAmount = fuel / FuelManager.instance.maxFuelAmount;
    //    Debug.Log(fuel / 100f);
    //}
}

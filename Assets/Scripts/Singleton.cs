using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Singleton : MonoBehaviour
{
    public static Singleton instance;

    float fuel = 100;
    public Image fuelSlider;

    public float Fuel
    {
        get { return fuel; }
    }


    // Start is called before the first frame update
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

      
    }


}

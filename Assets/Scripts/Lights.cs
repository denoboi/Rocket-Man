using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lights : MonoBehaviour
 {
     public GameObject objectToActivate;
 
      void Start()
     {
       
     }

     void Update()
    {
        Invoke("LightsOff",1);
        Invoke("LightsOn",2);
    }
 
    

   

         
     
     void LightsOn()
     {
        gameObject.SetActive(true);
     }
     
     void LightsOff()
     {
         gameObject.SetActive(false);
     }
 }
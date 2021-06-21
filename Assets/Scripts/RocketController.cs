using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketController : MonoBehaviour
{
    private Rigidbody playerRb;
    public float thrustAmount;
    public float rotationAmount;

    void Start()
    {
        playerRb = GetComponent<Rigidbody>(); 
    }

    
    void Update()
    {
        ProcessThrust();
        ProcessRotation();
    }
    void ProcessThrust()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            playerRb.AddRelativeForce(Vector3.up * thrustAmount * Time.deltaTime);
            Debug.Log("Pressed SPACE - Thrusting");
        }
    }
    void ProcessRotation()
      { 
        
        if (Input.GetKey(KeyCode.A))
        {
            ApplyRotation(rotationAmount);
        }
        else if (Input.GetKey(KeyCode.D)) //buraya apply rotation methodunun tersini eklemek icin mecburen parametre kullanacagiz.(rotationThisFrame)
        {
            ApplyRotation(-rotationAmount);
        }
     }

    private void ApplyRotation(float rotationThisFrame)
    {
        transform.Rotate(Vector3.forward * rotationThisFrame * Time.deltaTime);
    }
}

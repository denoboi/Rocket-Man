using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketController : MonoBehaviour
{
    private Rigidbody playerRb;
    public float thrustAmount;
    public float rotationAmount;
    private AudioSource playerAudio;
    

    void Start()
    {
        playerAudio = GetComponent<AudioSource>();
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

            //audio
            if (!playerAudio.isPlaying) //surekli bir jittering ses geliyor onu onlemek icin. eger calmiyorsa cal diyoruz.
            {
                playerAudio.Play();
            }

        }
        else

        {
            playerAudio.Stop();
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

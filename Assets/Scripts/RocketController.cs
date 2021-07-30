using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketController : MonoBehaviour
{
    private Rigidbody playerRb;
    public float thrustAmount;
    public float rotationAmount;
    private AudioSource playerAudio;

    [SerializeField] ParticleSystem leftThruster;
    [SerializeField] ParticleSystem rightThruster;
    [SerializeField] ParticleSystem mainThruster;

    [SerializeField] AudioClip mainEngine;
   

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
            if(!mainThruster.isPlaying)
            {
                mainThruster.Play();
            }
           


            //audio
            if (!playerAudio.isPlaying) //surekli bir jittering ses geliyor onu onlemek icin. eger calmiyorsa cal diyoruz.
            {
                playerAudio.PlayOneShot(mainEngine);
            }

        }
        else

        {
            playerAudio.Stop();
            mainThruster.Stop();
        }

    }
    void ProcessRotation()
    { 
        
        if (Input.GetKey(KeyCode.A))
        {
            ApplyRotation(rotationAmount);
            if(!rightThruster.isPlaying)
            {
                rightThruster.Play();
            }
             
           
            
        }
        
        else if (Input.GetKey(KeyCode.D)) //buraya apply rotation methodunun tersini eklemek icin mecburen parametre kullanacagiz.(rotationThisFrame)
        {
            ApplyRotation(-rotationAmount);
            
            if(!leftThruster.isPlaying)
            {
                leftThruster.Play();
            }

            
        }
        else
        {
            rightThruster.Stop();
            leftThruster.Stop();
        }
       
        
    }

    
    private void ApplyRotation(float rotationThisFrame)
    {
        transform.Rotate(Vector3.forward * rotationThisFrame * Time.deltaTime);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RocketController : MonoBehaviour
{
    private Rigidbody playerRb;
    public float thrustAmount;
    public float rotationAmount;
    private AudioSource playerAudio;

    public float fuel = 100;

    [SerializeField] ParticleSystem leftThruster;
    [SerializeField] ParticleSystem rightThruster;
    [SerializeField] ParticleSystem mainThruster;

    [SerializeField] AudioClip mainEngine;

    public Slider fuelSlider;
   
    void Awake()
    {
        playerAudio = GetComponent<AudioSource>();
        playerRb = GetComponent<Rigidbody>();
        playerRb.velocity = Vector3.zero;
        fuelSlider = FindObjectOfType<Slider>();
      
    }
    private void Start()
    {
        fuelSlider.value = fuel;
    }

    /* oyun baslar
     * ilk input gelinceye kadar rigidbody.constaints = constaints.freezerotati; 
     * ilk inputtan sonra rotasyon acilir
     * 
     */
    void Update()
    {
        if (fuel <= 0)
            return;
        Debug.Log(fuel);
        ProcessThrust();
        ProcessRotation();
        DecreaseFuel();      
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

    WaitForSeconds duration = new WaitForSeconds(0.25f);

    void ChangeSlider(float fuel)
    {
        fuelSlider.value = fuel;
    }
    void DecreaseFuel()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            fuel -= 0.2f;
            ChangeSlider(fuel);
        }
    }        
}

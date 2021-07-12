using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] float levelLoadDelay = 1.0f;
    [SerializeField] AudioClip successAudio;
    [SerializeField] AudioClip failAudio;
    [SerializeField] ParticleSystem successParticle;
    [SerializeField] ParticleSystem explosionParticle;

    AudioSource sfx;
    bool isTransitioning = false;

    void Start()
    {
        sfx = GetComponent<AudioSource>();
       

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (isTransitioning) { return; } //true ise asagiya hic girmiyor switche. Geri donuyor.
        //bunu if(!isTransitioning) ile de yazabilirdik. yani false ise o zaman switche gir.
        switch (collision.gameObject.tag)
        {
            case "Friendly":
                Debug.Log("This is friendly");
                break;
                
            case "Finished":
                StartSuccessSequence();
                Debug.Log("Congrats yo, you finished");
                
                sfx.PlayOneShot(successAudio);
                
                break;
               
            default:
                StartCrashSequence();
                sfx.PlayOneShot(failAudio);
                break;

        }

    }
        void StartSuccessSequence()
        {
            isTransitioning = true; 
            GetComponent<RocketController>().enabled = false;
            Invoke("NextScene", levelLoadDelay);
            successParticle.Play();

        }

        void StartCrashSequence()
        {
            isTransitioning = true;      
            GetComponent<RocketController>().enabled = false;
            Invoke("ReloadScene", levelLoadDelay);
            explosionParticle.Play();
        }
          void ReloadScene()
        {
            int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(currentSceneIndex);
        }
        void NextScene()
        {
            int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
            int nextLevel = currentSceneIndex + 1; //current scene'e arti 1 ekliyoruz ve sonraki scene'e geciyor.
            

            if (nextLevel == SceneManager.sceneCountInBuildSettings) //eger baska bolum kalmadiysa o zaman ilk levela geri don.
            {
                nextLevel = 0;
            }
            SceneManager.LoadScene(nextLevel);
        }

        
    
}

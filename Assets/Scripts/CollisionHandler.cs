using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        switch(collision.gameObject.tag)
        {
            case "Friendly":
                Debug.Log("This is friendly");
                break;
            case "Finished":
                NextScene();
                Debug.Log("Congrats yo, you finished");
                break;
            default:
                ReloadScene();
                break;

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
}

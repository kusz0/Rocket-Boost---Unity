using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {

        switch (collision.gameObject.tag)
        {
            case "Fuel":
                Destroy(collision.gameObject);
                break;
            case "Finish":
                GoToTheNextLvl();
                break;
            case "Evil":
                ReloadCurrentLvl();
                break;
        }
        void ReloadCurrentLvl()
        {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        void GoToTheNextLvl()
        {
            int nextScene = SceneManager.GetActiveScene().buildIndex + 1;

            if(nextScene == SceneManager.sceneCountInBuildSettings)
            {
                SceneManager.LoadScene(0);
            }else
            {
                SceneManager.LoadScene(nextScene);
            }

            
        }

    }
}


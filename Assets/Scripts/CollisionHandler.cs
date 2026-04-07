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
                gameObject.transform.position = new Vector3(-13.45f, 2.46f,0);
                break;
            case "Evil":
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                break;
        }

    }

}

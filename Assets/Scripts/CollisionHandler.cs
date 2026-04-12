using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] private float nextLvlDelay = 1.2f;
    [SerializeField] private float crashDelay = .7f;
 
    [SerializeField] ParticleSystem succesPatricle;
    [SerializeField] ParticleSystem crashParticle;

    [SerializeField] ParticleSystem mainBooster;
    [SerializeField] ParticleSystem leftBooster;
    [SerializeField]ParticleSystem rightBooster;


    Movement movement;



    private void Awake()
    {
        movement = GetComponent<Movement>();
    }
    private void OnCollisionEnter(Collision collision)
    {

        switch (collision.gameObject.tag)
        {
            case "Fuel":
                Destroy(collision.gameObject);
                break;
            case "Finish":
                NextLvlSeq();
                break;
            case "Evil":
                CrashSequence();
                break;
        }

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
    void CrashSequence()
    {
        crashParticle.Play();
        movement.enabled= false;
        Invoke("ReloadCurrentLvl", crashDelay);
    }
    void NextLvlSeq()
    {
        succesPatricle.Play();
        Invoke("GoToTheNextLvl", nextLvlDelay);
    }
}


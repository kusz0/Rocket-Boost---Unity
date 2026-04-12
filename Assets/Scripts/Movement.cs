using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    [SerializeField] InputAction upAction;
    [SerializeField] InputAction rotation;
    
    [SerializeField] float upStrength = 3000f;
    [SerializeField] float rotationStrength = 2000f;

    [SerializeField] ParticleSystem mainBooster;
    [SerializeField] ParticleSystem leftBooster;
    [SerializeField] ParticleSystem rightBooster;

    Rigidbody rb;


    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        upAction.Enable();
        rotation.Enable();
    }
    private void OnDisable()
    {
        upAction.Disable();
        rotation.Disable();
    }

    private void FixedUpdate()
    {
        ProcessActionUp();
        ProcessRotation();
    }
    private void ProcessActionUp()
    {
        if(upAction.IsPressed())
        {
            mainBooster.Play();
            rb.AddRelativeForce(Vector3.up * upStrength * Time.deltaTime);
        }else
        {
            mainBooster.Stop();
        }
    }
    private void ProcessRotation()
    {
        float rotationInput = rotation.ReadValue<float>();
        if(rotation.IsPressed())
        {
            if(rotationInput == -1)
            {
                leftBooster.Play();
                ApplyRotation(Vector3.left, 1);
            }
            else
            {
                rightBooster.Play();
                ApplyRotation(Vector3.right, -1);
            }
        }else
        {
            rightBooster.Stop();
            leftBooster.Stop();
        }

    }
    private void ApplyRotation(Vector3 direction, float directionRotate)
    {
        transform.Rotate(0, 0, directionRotate);
        rb.AddRelativeForce(direction * rotationStrength * Time.deltaTime);
    }





}

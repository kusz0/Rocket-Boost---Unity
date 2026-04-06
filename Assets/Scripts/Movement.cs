using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    [SerializeField] InputAction upAction;
    [SerializeField] InputAction rotation;
    
    [SerializeField] float up = 3000f;
    [SerializeField] float leftRight = 10f;
    
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
            rb.AddRelativeForce(Vector3.up * up * Time.deltaTime);
        }
    }
    private void ProcessRotation()
    {
        float rotationInput = rotation.ReadValue<float>();
        if(rotation.IsPressed())
        {
            if(rotationInput == -1)
            {
                rb.AddRelativeForce(Vector3.left * leftRight * Time.deltaTime);
            } else
            {
                rb.AddRelativeForce(Vector3.right * leftRight * Time.deltaTime);
            }
        
        }


    }





}

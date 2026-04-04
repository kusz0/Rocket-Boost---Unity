using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    [SerializeField] InputAction action;
    [SerializeField] float up = 30f;

    
    Rigidbody rb;


    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void OnEnable()
    {
        action.Enable();
    }
    private void OnDisable()
    {
        action.Disable();
    }
    
    private void FixedUpdate()
    {
        if(action.IsPressed())
        {
            rb.AddRelativeForce(0,up * Time.deltaTime,0);
        }
    }

}

using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    [SerializeField] InputAction action;
    
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
            rb.AddRelativeForce(0,30,0);
        }
    }

}

using Unity.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    Vector2 movement;
    Rigidbody rb;
    
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float xClamp = 4f;
    [SerializeField] float zClamp = 2f;


    void Awake() 
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate() 
    {
        Vector3 position = rb.position;

        position.x = position.x + movement.x * moveSpeed * Time.deltaTime;
        position.x = Mathf.Clamp(position.x, -xClamp, xClamp);

        position.z = position.z + movement.y * moveSpeed * Time.deltaTime;
        position.z = Mathf.Clamp(position.z, -zClamp, zClamp);

        rb.MovePosition(position);
    }

    void Move(InputAction.CallbackContext context)
    {
        movement = context.ReadValue<Vector2>();
    }
}

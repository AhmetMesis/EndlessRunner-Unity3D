using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    Vector2 move;
    Rigidbody rb;
    float moveSpeed = 5f;
    [SerializeField] float xClamp = 5f;
    [SerializeField] float zClamp = 2f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void Awake()
    {
         rb = GetComponent<Rigidbody>();
    }
    public void Move(InputAction.CallbackContext context)
    {
        move = context.ReadValue<Vector2>();
        Debug.Log(move);
    }
    
    private void FixedUpdate() {
        HandleMovement();
       
    }

    void HandleMovement(){
        Vector3 position = transform.position;
        Vector3 moveDirection = new Vector3(move.x, 0, move.y);
        Vector3 newPosition = position + moveDirection * (Time.fixedDeltaTime * moveSpeed);
        newPosition.x = Mathf.Clamp(newPosition.x, -xClamp, xClamp);
        newPosition.z = Mathf.Clamp(newPosition.z, -zClamp, zClamp);
        rb.MovePosition(newPosition);
    }
}

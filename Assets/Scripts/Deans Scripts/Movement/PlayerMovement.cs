using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private FieldOfView fieldOfView;
    public float moveSpeed = 5f;

    private Vector2 moveInput;
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + moveInput * moveSpeed * Time.fixedDeltaTime);
        fieldOfView.setOrigin(transform.position);
    }

    void OnMove(InputValue value) 
    {
        moveInput = value.Get<Vector2>();   
    }
}
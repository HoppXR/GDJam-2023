using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private FieldOfView fieldOfView;
    public float moveSpeed = 5f;
    public float dashSpeed = 15f;
    public float dashDuration = 0.3f;
    public float dashCooldown = 1f;

    private Rigidbody2D rb;
    private Vector2 moveInput;

    private bool isDashing = false;
    private float dashStartTime;
    private float nextDashTime;

    private PlayerInput playerInput;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerInput = GetComponent<PlayerInput>();
    }

    void FixedUpdate()
    {
        if (!isDashing)
        {
            rb.MovePosition(rb.position + moveInput * moveSpeed * Time.fixedDeltaTime);
            fieldOfView.setOrigin(transform.position);
        }
    }

    void Update()
    {
        if (isDashing)
        {
            if (Time.time - dashStartTime >= dashDuration)
            {
                isDashing = false;
                rb.velocity = Vector2.zero;
            }
        }

        if (Time.time >= nextDashTime)
        {
            if (moveInput != Vector2.zero && playerInput.actions["Dash"].triggered)
            {
                // Initiate a dash in the direction of movement
                Dash(moveInput.normalized);
                nextDashTime = Time.time + dashCooldown;
            }
        }
    }

    void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }

    void Dash(Vector2 direction)
    {
        isDashing = true;
        dashStartTime = Time.time;
        rb.velocity = direction * dashSpeed;
    }
}
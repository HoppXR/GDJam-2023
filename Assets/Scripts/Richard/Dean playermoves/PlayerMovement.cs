using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private Abilities abilitiesScriptReference;
    private Health health;

    [SerializeField] private FieldOfView fieldOfView;
    public float moveSpeed = 5f;
    public float dashSpeed = 15f;
    public float dashDuration = 0.3f;
    float dashCooldown;
    float dashDamageAmount = 10f;

    private Rigidbody2D rb;
    private Vector2 moveInput;

    private bool isDashing = false;
    private float dashStartTime;
    private float nextDashTime;

    private PlayerInput playerInput;

    private void Start()
    {
        abilitiesScriptReference = GetComponent<Abilities>();
        health = GetComponent<Health>();

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
            float dashCooldownFromAbilities = abilitiesScriptReference.GetDashCooldown();
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

    // Jaden added this
    public void TriggerDash()
    {
        if (!isDashing && moveInput != Vector2.zero)
        {
            Dash(moveInput.normalized);
            nextDashTime += Time.time + dashCooldown;
            health.dashDamage(dashDamageAmount);
        }
    }

    // Jaden added this
    public bool IsDashing()
    {
        return isDashing;
    }
}
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController3 : MonoBehaviour
{
    [SerializeField] private FieldOfView fieldOfView;

    private Rigidbody2D rb;
    private Vector2 moveInput;

    private PlayerInput playerInput;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerInput = GetComponent<PlayerInput>();
    }

    void FixedUpdate()
    {

    }

    void Update()
    {

    }

    void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }
}
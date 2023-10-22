using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private FieldOfView fieldOfView;
    public float moveSpeed = 5f;

    public AudioSource audioPlayer;

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

    public void OnCollisionEnter2D(Collision2D collision) 
    {
        if (collision.gameObject.tag == "CollisionTag") 
        {
            audioPlayer.Play();
        }    
    }

}
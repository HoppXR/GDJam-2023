using System.Collections;
using System.Collections.Generic;
using UnityEditor.Searcher;
using UnityEngine;

public class TDMovement : MonoBehaviour
{
    public static TDMovement instance;
    [SerializeField] private FieldOfView fieldOfView;
    private float moveSpeed = 5;
    private float KnockbackPower = 6;
    public Rigidbody2D rb;

    private Vector2 moveInput;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        moveInput.x = Input.GetAxisRaw("Horizontal");
        moveInput.y = Input.GetAxisRaw("Vertical");

        moveInput.Normalize();

        rb.velocity = moveInput * moveSpeed;
    }

    public IEnumerator Knockback(float duration, float power, Transform obj)
    {
        float timer = 0;

        while (timer < duration)
        {
            timer += Time.deltaTime;
            Vector2 direction = ((Vector2)obj.transform.position - (Vector2)this.transform.position).normalized;
            rb.AddForce(-direction * KnockbackPower);
            yield return null;
        }
    }
}


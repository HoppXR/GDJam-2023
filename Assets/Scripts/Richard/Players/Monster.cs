using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player instance;
    [SerializeField] private float speed = 4;
    private Vector2 _moveDirection;
    public Rigidbody2D rb;

    // Knockback Stuff
    private float knockbackTime;
    private float knockbackPower;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        InputManager.Init(this);
        InputManager.SetGameControls(); // Enable player controls
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.rotation * (speed * Time.deltaTime * _moveDirection);
    }

    public void SetMovementDirection(Vector2 currentDirection)
    {
        _moveDirection = currentDirection;
    }

    public IEnumerator Knockback(float duration, float power, Transform source)
    {
        float timer = 0;

        while (timer < duration)
        {
            // Calculate the direction of knockback
            Vector2 direction = (transform.position - source.position).normalized;

            // Apply the knockback force
            rb.AddForce(direction * power);

            // Update the timer
            timer += Time.deltaTime;

            yield return null;
        }
    }
}
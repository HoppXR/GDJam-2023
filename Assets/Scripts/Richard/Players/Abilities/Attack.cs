using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public GameObject SwingPrefab;
    [SerializeField] public float destroyDelay = 0.1f;
    [SerializeField] public float knockbackPower;
    [SerializeField] public float knockbackDuration;
    private Rigidbody2D rb;
    private Vector3 lastMovementDirection;
    public float spawnDistance = 6f;

    [SerializeField] private float cooldownTime = 2.0f;
    private float _lastAttackTime;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        lastMovementDirection = new Vector3(horizontal, vertical, 0f).normalized;
        if (Input.GetKeyDown(KeyCode.U) && CanAttack())
        {
            spawnSwipe();
        }
    }

    public bool CanAttack()
    {
        return (Time.time - _lastAttackTime) >= cooldownTime;
    }

    public void spawnSwipe()
    {
        if (CanAttack())
        {
            _lastAttackTime = Time.time;

            // Calculate the angle of the last movement direction
            float angle = Mathf.Atan2(lastMovementDirection.y, lastMovementDirection.x) * Mathf.Rad2Deg;

            Vector3 spawnPosition;

            // Check if the player is moving
            if (lastMovementDirection.magnitude > 0)
            {
                // Calculate the spawn position with an offset in the direction of movement
                spawnPosition = transform.position + (lastMovementDirection * spawnDistance);
            }
            else
            {
                // Set a fixed spawn distance in front of the player when not moving
                spawnPosition = transform.position + new Vector3(spawnDistance, 0, 0);
            }

            // Instantiate the sprite with the calculated angle and position
            GameObject newSwing = Instantiate(SwingPrefab, spawnPosition, Quaternion.Euler(0, 0, angle));

            // Use the Destroy method with the specified delay
            Destroy(newSwing, destroyDelay/4);
        }
    }
}

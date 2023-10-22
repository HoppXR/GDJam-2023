using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    private Health health;
    float spikeDamageAmount = 4f;

    public GameObject SpikeyBallPrefab;
    [SerializeField] public float destroyDelay = 0.1f;
    [SerializeField] public float cooldownTime = 0.75f;
    private float _lastShootTime;
    [SerializeField] private float projectileForce = 10.0f;
    private Vector3 lastMovementDirection = Vector3.right; // Default direction when not moving

    private void Start()
    {
        health = GetComponent<Health>();
    }
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        lastMovementDirection = new Vector3(horizontal, vertical, 0f).normalized;
        if (Input.GetKeyDown(KeyCode.O) && CanShoot())
        {
            ShootProjectile();
        }
    }

    public bool CanShoot()
    {
        return (Time.time - _lastShootTime) >= cooldownTime;
    }

    public void ShootProjectile()
    {
        if (CanShoot())
        {
            _lastShootTime = Time.time; // Update the last shoot time

            // Calculate the angle of the last movement direction
            float angle = Mathf.Atan2(lastMovementDirection.y, lastMovementDirection.x) * Mathf.Rad2Deg;

            Vector3 spawnPosition;

            // Calculate the spawn position with an offset in the direction of the player's orientation
            spawnPosition = transform.position + (lastMovementDirection.normalized * 1.0f); // You can adjust the offset distance

            // Instantiate the projectile with the calculated angle and position
            GameObject newProjectile = Instantiate(SpikeyBallPrefab, spawnPosition, Quaternion.Euler(0, 0, angle));

            // Access the Rigidbody2D of the current projectile
            Rigidbody2D projectileRb = newProjectile.GetComponent<Rigidbody2D>();

            // Set the shooting direction to the player's orientation (up)
            Vector3 shootingDirection = transform.up;

            // If the player is not moving (lastMovementDirection is zero), use a default direction (e.g., right)
            if (lastMovementDirection == Vector3.zero)
            {
                shootingDirection = Vector3.right; // Adjust the default direction as needed
            }

            // Apply the force to the projectile using ForceMode2D.Impulse
            projectileRb.AddForce(shootingDirection * projectileForce, ForceMode2D.Impulse);

            // Use the Destroy method with the specified delay
            Destroy(newProjectile, 5);
        }
    }

    public float GetSpikeDamageAmount()
    {
        return spikeDamageAmount;
    }
}

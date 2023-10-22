using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public GameObject SpikeyBallPrefab;
    [SerializeField] public float destroyDelay = 0.1f;
    [SerializeField] public float knockbackPower;
    [SerializeField] public float knockbackDuration;
    private Rigidbody2D rb;
    private Vector3 lastMovementDirection;
    public float spawnDistance = 1f;
    [SerializeField] private float cooldownTime = 8.0f;
    private float _lastShootTime;
    [SerializeField] private float projectileForce = 10.0f;
    [SerializeField] private float bulletSpeed = 7;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
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
            _lastShootTime = Time.time; // Update the last attack time

            // Calculate the angle of the last movement direction
            float angle = Mathf.Atan2(lastMovementDirection.y, lastMovementDirection.x) * Mathf.Rad2Deg;

            Vector3 spawnPosition;

            // Calculate the spawn position with an offset in the direction of the player's orientation
            spawnPosition = transform.position + (lastMovementDirection.normalized * spawnDistance);

            // Instantiate the projectile with the calculated angle and position
            GameObject newProjectile = Instantiate(SpikeyBallPrefab, spawnPosition, Quaternion.Euler(0, 0, angle));

            // Access the Rigidbody2D of the current projectile
            Rigidbody2D projectileRb = newProjectile.GetComponent<Rigidbody2D>();
            
            // Apply a force to the projectile in the direction the player is facing
            Vector3 shootingDirection = lastMovementDirection.normalized;
            
            if (lastMovementDirection == Vector3.zero)
            {
                shootingDirection = Vector3.right; // Adjust the default direction as needed
            };
            
            // Apply the force to the projectile using ForceMode2D.Impulse
            projectileRb.AddForce(shootingDirection * projectileForce, ForceMode2D.Impulse);

            // Use the Destroy method with the specified delay
            Destroy(newProjectile, 5);
        }
    }



}

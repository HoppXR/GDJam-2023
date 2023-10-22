using UnityEngine;
using System.Collections;

public class Attack : MonoBehaviour
{
    public GameObject SwingPrefab;
    [SerializeField] public float destroyDelay = 0.1f;
    [SerializeField] public float knockbackPower;
    [SerializeField] public float knockbackDuration;
    [SerializeField] public float spawnDistance = 5f;
    

    private Rigidbody2D rb;

    [SerializeField] private float cooldownTime = 2.0f;
    private float _lastAttackTime;

    // Reference to the player
    private Player player;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GetComponent<Player>(); // Get the Player component
    }

    private void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 playerDirection = new Vector3(horizontal, vertical, 0f).normalized;

        if (Input.GetKeyDown(KeyCode.U) && CanAttack())
        {
            // Attack and set the player's movement direction
            player.SetMovementDirection(playerDirection);
            SpawnSwipe(playerDirection);
        }
    }

    public bool CanAttack()
    {
        return (Time.time - _lastAttackTime) >= cooldownTime;
    }

    public void SpawnSwipe(Vector3 direction)
    {
        if (CanAttack())
        {
            _lastAttackTime = Time.time;

            // Calculate the angle of the attack direction
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

            // Calculate the spawn position based on the player's position and attack direction
            Vector3 spawnPosition = transform.position + direction * spawnDistance;

            // Instantiate the sprite with the calculated angle and position
            GameObject newSwing = Instantiate(SwingPrefab, spawnPosition, Quaternion.Euler(0, 0, angle));

            // Use the Destroy method with the specified delay
            Destroy(newSwing, destroyDelay / 4);
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterDamage : MonoBehaviour
{
    public float damageAmount = 25f;
    private AdjustHealth playerHealth;
    
    // Start is called before the first frame update
    void Start()
    {
        playerHealth = FindObjectOfType<AdjustHealth>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerHealth.ApplyDamage(damageAmount);
        }
    }
}

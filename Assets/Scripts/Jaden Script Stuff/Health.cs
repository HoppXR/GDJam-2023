using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float currentHealth;
    public float maxHealth;

    // Start is called before the first frame update
    public void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(float amount)
    {
        currentHealth -= amount;
        Debug.Log("Bro got swiped");

        if (currentHealth <= 0) 
        {
            Die();
        }
    }

    public void Heal(float amount)
    {
        currentHealth += amount;

        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }

    public void dashDamage(float amount)
    {
        if (GetComponent<PlayerController>() != null && GetComponent<PlayerController>().IsDashing())
        {
            TakeDamage(amount);
        }
    }
}

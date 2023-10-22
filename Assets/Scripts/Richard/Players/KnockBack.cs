using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnockBack : MonoBehaviour
{
    [SerializeField] public float knockbackPower = 150;
    [SerializeField] public float knockbackDuration;
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            StartCoroutine(Player.instance.Knockback(knockbackDuration, knockbackPower, this.transform));
        }
    }
}

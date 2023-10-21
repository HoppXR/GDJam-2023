using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swing : MonoBehaviour
{
    [SerializeField]public float knockbackPower;
    [SerializeField]public float knockbackDuration;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            StartCoroutine(Player.instance.Knockback(knockbackDuration, knockbackPower, this.transform));
        }
    }
}

using System.Collections;
using System.Collections.Generic;
// EnemyHealth.cs
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float health = 100f;

    public void TakeDamage(float amount)
    {
        health -= amount;
        if (health <= 0f)
        {
            Die();
        }
    }

    void Die()
    {
        // Play animation, destroy, etc.
        Destroy(gameObject);
    }
}

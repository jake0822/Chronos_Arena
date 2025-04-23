using System.Collections;
using System.Collections.Generic;
// EnemyHealth.cs
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float health = 100f;
    public Renderer rend; // Assign in inspector
    private Color originalColor;

    
    private void Start()
    {
        
      
        if (rend == null) rend = GetComponent<Renderer>();
        originalColor = rend.material.color;
    }

    public void TakeDamage(float amount)
    {
        health -= amount;
        StartCoroutine(FlashRed());

        if (health <= 0f)
        {
            Die();
           
        }
    }

    System.Collections.IEnumerator FlashRed()
    {
        rend.material.color = Color.red;
        yield return new WaitForSeconds(0.1f); // Flash duration
        rend.material.color = originalColor;
    }

    void Die()
    {
        Destroy(gameObject);
    }
}


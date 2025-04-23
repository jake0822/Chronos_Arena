using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    public float health = 100f;
    public Renderer rend; // Assign in Inspector
    public Image healthBarFill; // Drag the fill image here in the Inspector

    private Color originalColor;

    
    private void Start()
    {
        
      
        if (rend == null) rend = GetComponent<Renderer>();
        originalColor = rend.material.color;

        UpdateHealthBar();
    }

    public void TakeDamage(float amount)
    {
        health -= amount;
        StartCoroutine(FlashRed());
        UpdateHealthBar();

        if (health <= 0f)
        {
            Die();
           
        }
    }

    void UpdateHealthBar()
    {
        if (healthBarFill != null)
        {
            healthBarFill.fillAmount = health / 100f;
        }
    }

    IEnumerator FlashRed()
    {
        rend.material.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        rend.material.color = originalColor;
    }

    void Die()
    {
        Destroy(gameObject);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthBar : MonoBehaviour
{
    public Image fillImage;
    private EnemyHealth enemyHealth;

    void Start()
    {
        enemyHealth = GetComponentInParent<EnemyHealth>();
        if (enemyHealth != null)
        {
            //enemyHealth.OnHealthChanged += UpdateHealthBar;
        }
    }

    void UpdateHealthBar(float currentHealth, float maxHealth)
    {
        fillImage.fillAmount = currentHealth / maxHealth;
    }

    private void LateUpdate()
    {
        transform.LookAt(Camera.main.transform);
        transform.Rotate(0, 180, 0);
    }

    private void OnDestroy()
    {
        //if (enemyHealth != null)
            //enemyHealth.OnHealthChanged -= UpdateHealthBar;
    }
}

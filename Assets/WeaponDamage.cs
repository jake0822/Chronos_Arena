using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponDamage : MonoBehaviour
{
    public float damageMultiplier = 1f;
    public float minDamageThreshold = 0.5f;

    private Vector3 lastPosition;
    private Vector3 velocity;

    void Update()
    {
        velocity = (transform.position - lastPosition) / Time.deltaTime;
        lastPosition = transform.position;
    }

    private void OnCollisionEnter(Collision collision)
    {
        EnemyHealth enemy = collision.collider.GetComponent<EnemyHealth>();
        Rigidbody enemyRb = collision.collider.GetComponent<Rigidbody>();

        if (enemy != null)
        {
            float swingSpeed = velocity.magnitude;

            if (swingSpeed > minDamageThreshold)
            {
                float damage = swingSpeed * damageMultiplier;
                enemy.TakeDamage(damage);
                Debug.Log($"Hit enemy with {damage:F2} damage (speed: {swingSpeed:F2})");

                // Knockback logic
                if (enemyRb != null)
                {
                    Vector3 knockbackDir = collision.contacts[0].point - transform.position;
                    knockbackDir = knockbackDir.normalized;

                    float knockbackForce = Mathf.Clamp(swingSpeed * 10f, 0f, 15f);
                    enemyRb.AddForce(knockbackDir * knockbackForce, ForceMode.Impulse);
                }
            }
        }
    }
}

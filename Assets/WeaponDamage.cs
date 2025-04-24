using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponDamage : MonoBehaviour
{
    public float damageMultiplier = 1f;
    public float minDamageThreshold = 0.5f;
    public float knockbackMultiplier = 10f; // 🔥 Customizable per weapon
    public float maxKnockbackForce = 15f;

    public AudioClip hitSound;
    public AudioClip screechSound;
    public AudioSource audioSource;

    private Vector3 lastPosition;
    private Vector3 velocity;

    void Start()
    {
        if (audioSource == null)
        {
            audioSource = GetComponent<AudioSource>();
        }
    }

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

                // Play sound effects
                if (audioSource != null)
                {
                    if (hitSound != null)
                        audioSource.PlayOneShot(hitSound);
                    if (screechSound != null)
                        audioSource.PlayOneShot(screechSound);
                }

                // Knockback logic
                if (enemyRb != null)
                {
                    Vector3 knockbackDir = collision.contacts[0].point - transform.position;
                    knockbackDir = knockbackDir.normalized;

                    float knockbackForce = Mathf.Clamp(swingSpeed * knockbackMultiplier, 0f, maxKnockbackForce);
                    enemyRb.AddForce(knockbackDir * knockbackForce, ForceMode.Impulse);
                }
            }
        }
    }
}
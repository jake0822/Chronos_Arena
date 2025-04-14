using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordDamage : MonoBehaviour
{
    public float damageMultiplier = 1f; // Multiply velocity by this to get damage
    public float minDamageThreshold = 0.5f; // Ignore tiny hits

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
        if (enemy != null)
        {
            float swingSpeed = velocity.magnitude;

            if (swingSpeed > minDamageThreshold)
            {
                float damage = swingSpeed * damageMultiplier;
                enemy.TakeDamage(damage);
                Debug.Log($"Hit enemy with {damage:F2} damage (speed: {swingSpeed:F2})");
            }
        }
    }
}

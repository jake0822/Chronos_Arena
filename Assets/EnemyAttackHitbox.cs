using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackHitbox : MonoBehaviour
{
    public CapsuleCollider collider;
    
    void Start()
    {
        collider.enabled = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") == true)
        {
            print("Player Hit!");
        }
    }
    IEnumerator Attack()
    {
        collider.enabled = true;
        print("Attack!");
        yield return new WaitForSeconds(2);
        collider.enabled = false;
    }
    public void doAttack()
    {
        StartCoroutine(Attack());
    }
    


}

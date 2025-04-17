using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackHitbox : MonoBehaviour
{
    public CapsuleCollider collider;
    public MeshRenderer attackMesh;
    [HideInInspector]public bool doingAttack = false;
    public AnimationController animations;

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
        animations.hit = false;
        animations.run = false;
        animations.idle = false;
        animations.attack = true;
        doingAttack = true;
        yield return new WaitForSeconds(0.6f);
        collider.enabled = true;
        //attackMesh.enabled = true;
        print("Attack!");
        yield return new WaitForSeconds(1f);
        animations.hit = false;
        animations.run = false;
        animations.attack = false;
        animations.idle = false;
        //attackMesh.enabled = false;
        collider.enabled = false;
        doingAttack = false;
    }
    public void doAttack()
    {
        StartCoroutine(Attack());
    }
    


}

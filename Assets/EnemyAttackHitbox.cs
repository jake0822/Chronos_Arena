using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackHitbox : MonoBehaviour
{
    public CapsuleCollider collider;
    public MeshRenderer attackMesh;
    [HideInInspector]public bool doingAttack = false;
    public AnimationController animations;
    public MeshRenderer redOverlay;

    void Start()
    {
        redOverlay = GameObject.FindGameObjectWithTag("red").GetComponent<MeshRenderer>();
        collider.enabled = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") == true)
        {
            print("Player Hit!");
            StartCoroutine(PlayerHit());
        }
    }
    IEnumerator PlayerHit()
    {
        float alpha = 0f;
        float speed = 2f;
        int dir = 1;

        Color baseColor = redOverlay.material.color;

        while (true)
        {
            alpha += Time.deltaTime * speed * dir;
            alpha = Mathf.Clamp01(alpha);

            redOverlay.material.color = new Color(baseColor.r, baseColor.g, baseColor.b, alpha);

            if (alpha >= 0.6f)
                dir = -1;
            if (alpha <= 0f)
                break;

            yield return null; 
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

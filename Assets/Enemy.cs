using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public bool attack;
    public EnemyAttackHitbox enemyHitbox;
    private void Update()
    {
        if (attack)
        {
            enemyHitbox.doAttack();
            attack = false;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public bool attack;
    public bool follow;
    public EnemyAttackHitbox enemyHitbox;
    public GameObject player;
    float distanceToPlyr;
    private void FixedUpdate()
    {
        distanceToPlyr = Vector3.Distance(player.transform.position, transform.position);
        if (attack)
        {
            enemyHitbox.doAttack();
            attack = false;
        }

        if (follow && distanceToPlyr >= 1)
        {

            transform.position = Vector3.Lerp(transform.position, 
                new Vector3(player.transform.position.x, transform.position.y, //explore PID system
                player.transform.position.z), .01f);


            Vector3 newTest = new Vector3(player.transform.position.x, 1.1f, player.transform.position.z);


            transform.LookAt(newTest);
           
        }
        if (!enemyHitbox.doingAttack && distanceToPlyr <= 1) {
            attack = true; }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public bool attack;
    public bool follow;
    public EnemyAttackHitbox enemyHitbox;
    public GameObject player;
    public NavMeshAgent agent;
    float distanceToPlyr;
    private float attackTimer;
    public float attackDelay = 3f;
    public AnimationController animations;
    public float AttackRange;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    private void FixedUpdate()
    {
        //start
        distanceToPlyr = Vector3.Distance(player.transform.position, transform.position);
        attackTimer += Time.deltaTime;
        //vvv stateMachine
        if (attack)
        {
           
            enemyHitbox.doAttack();
            attack = false;
        }

        if (follow && distanceToPlyr >= AttackRange)
        {
            animations.resetAnimations();
            animations.run = true;
            agent.destination = new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z);
            //transform.position = Vector3.Lerp(transform.position, 
            //new Vector3(player.transform.position.x, transform.position.y, //explore PID system
            // player.transform.position.z), .01f);
            Vector3 newTest = new Vector3(player.transform.position.x, 1.1f, player.transform.position.z);
            transform.LookAt(newTest);
        }// ^^^state machine
        //  vvv state control
        if (!enemyHitbox.doingAttack && distanceToPlyr <= AttackRange && attackTimer >= attackDelay) 
        {
            attackTimer = 0;
            attack = true; 
        }
        if (!enemyHitbox.doingAttack && distanceToPlyr <= AttackRange && attackTimer <= attackDelay)
        {
            animations.idle = true;
        }
    }
}

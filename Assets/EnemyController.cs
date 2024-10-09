using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    Transform playerTarget;
    [SerializeField] private float speed = 3;
    SpriteRenderer spriteRenderer;
    Animator animatorController; // Add reference to Animator

    [SerializeField] private float chaseDistance = 9f;
    [SerializeField] private float attackDistance = 3f;
    float timer = 0;
    public gameManagerSc gameM;
    public float damage = 5f;

    public int enemyAttackSpeed = 1;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        animatorController = GetComponent<Animator>();
        playerTarget = GameObject.Find("player").transform;
        gameM = FindAnyObjectByType<gameManagerSc>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(transform.position, playerTarget.position) <= chaseDistance)
        {

            if (Vector2.Distance(transform.position, playerTarget.position) <= attackDistance)
            {
                attackState();
            }
            else
            {
                chaseState();
            }
        }
        else
        {
            idleState();
        }
    }

    //StateMachine

    void attackState()
    {
        animatorController.SetInteger("enemyAni", 2);
        Debug.Log("Attack State");
        timer += Time.deltaTime;
        Debug.Log("Timer : " + timer);

        if ((int)timer == enemyAttackSpeed)
        {
            gameM.PlayerHit(damage);
            Debug.Log("Hit");
            timer = 0;

        }
    }
    void idleState()
    {
        animatorController.SetInteger("enemyAni", 0);
    }
    void chaseState()
    {
        Debug.Log("Chase Distance");
        transform.position = Vector2.MoveTowards(transform.position, playerTarget.position, speed * Time.deltaTime);

        // Check distance and set animation based on chase distance threshold
        float distanceToPlayer = Vector2.Distance(transform.position, playerTarget.position);
        animatorController.SetInteger("enemyAni", 1);

        if (playerTarget.position.x < transform.position.x)
        {
            spriteRenderer.flipX = true;
        }
        else
        {
            spriteRenderer.flipX = false;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, chaseDistance);

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackDistance);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private CharacterAnimation enemyAnim;
    private Rigidbody myBody;
    public float speed = 5f;

    private Transform playerTarget;
    public float attack_Distance = 1f;
    private float chase_player_after_attack = 1f;
    private float current_attack_time;
    private float default_attack_time = 2f;

    private bool followPlayer,attackPlayer;
    void Start()
    {
        enemyAnim = GetComponentInChildren<CharacterAnimation>();
        myBody = GetComponent<Rigidbody>();
        playerTarget = GameObject.FindWithTag(Tags.player_tag).transform;
        followPlayer = true;
        current_attack_time = default_attack_time;

    }

    void Update()
    {
       
      Attack();
    }
    void FixedUpdate()
    {
        FollowTarget();

    }

    void FollowTarget()
    {
        if(!followPlayer)
        return;

        if(Vector3.Distance(transform.position,playerTarget.position) > attack_Distance){

            transform.LookAt(playerTarget);
            myBody.velocity = transform.forward * speed;

            if(myBody.velocity.sqrMagnitude != 0)
            {
                enemyAnim.Walk(true);
            }
        }
        else if(Vector3.Distance(transform.position,playerTarget.position) <= attack_Distance){

            myBody.velocity = Vector3.zero;
            enemyAnim.Walk(false);

            followPlayer = false;
            attackPlayer = true;
        }

    }

    void Attack()
    {
        if(!attackPlayer)
        return;
        current_attack_time += Time.deltaTime;

        if(current_attack_time>default_attack_time)
        {
            enemyAnim.EnemyAttack(Random.Range(0,3));
            current_attack_time = 0f;
        }
        if(Vector3.Distance(transform.position,playerTarget.position) > attack_Distance + chase_player_after_attack)
        {
            attackPlayer = false;
            followPlayer = true;
        }

    }

}

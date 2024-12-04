using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class Enemy : MonoBehaviour
{
    public NavMeshAgent navMeshAgent;
    public Transform target;

    public float radius = 10f;
    public Vector3 originalePosition;
    public float maxDistance = 50f;
    public Animator animator;
    public DamageZone damageZone;
    public Health health;
    public enum CharacterState
    {
        Normal,
        Attack,
        Die
    }
    public CharacterState currentState;
    void Start()
    {
        originalePosition = transform.position;
    }
    void Update()
    {
        if(health.currentHP <= 0)
        {
            ChangeState(CharacterState.Die);
        }
        //xoay huong vao player
        if(target != null)
        {
            var lookPor = target.position - transform.position;
            lookPor.y = 0;
            var rotation = Quaternion.LookRotation(lookPor);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime + 5);
        }
        if (currentState == CharacterState.Die)
        {
            return;
        }
        var distanceToOriginal = Vector3.Distance(originalePosition, transform.position);
        var distance = Vector3.Distance(target.position, transform.position);
        if (distance <= radius && distanceToOriginal <= maxDistance)
        {
            navMeshAgent.SetDestination(target.position);
            animator.SetFloat("speed", navMeshAgent.velocity.magnitude);

            distance = Vector3.Distance(target.position, transform.position);
            if (distance < 2f)
            {
                ChangeState(CharacterState.Attack);
            }
        }
        if (distance > radius || distanceToOriginal > maxDistance)
        {
            navMeshAgent.SetDestination(originalePosition);
            animator.SetFloat("speed", navMeshAgent.velocity.magnitude);

            distance = Vector3.Distance(originalePosition, transform.position);
            if(distance < 1f)
            {
                animator.SetFloat("speed", 0);
            }
            ChangeState(CharacterState.Normal);
        }
    }
    private void ChangeState(CharacterState newState)
    {
        switch (currentState)
        {
            case CharacterState.Normal:
                break;
            case CharacterState.Attack:
                break;
        }

        switch (newState)
        {
            case CharacterState.Normal:
                damageZone.EndAttack();
                break;
            case CharacterState.Attack:
                animator.SetTrigger("Attack");
                damageZone.BeginAttack();
                break;
            case CharacterState.Die:
                animator.SetTrigger("Die");
                Destroy(gameObject, 3f);
                break;
        }
        currentState = newState;
    }
}

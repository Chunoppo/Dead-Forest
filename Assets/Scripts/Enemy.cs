using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public NavMeshAgent navMeshAgent;
    public Transform target;

    public float radius = 10f;
    public Vector3 originalePosition;
    public float maxDistance = 50f;

    public Animator animator;
    // Update is called once per frame

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
                break;
            case CharacterState.Attack:
                animator.SetTrigger("Attack");
                break;
        }
        currentState = newState;
    }

}

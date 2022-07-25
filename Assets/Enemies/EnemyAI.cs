using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float detectRange = 15f;
    [SerializeField] float attackRange = 5f;
    [SerializeField] private bool isProvoked = false;

    private NavMeshAgent navMeshAgent;
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        SetStopDistance(attackRange * 0.9f);

        if (DistanceToTarget(target.position) < detectRange)
        {
            isProvoked = true;
        }

        if (isProvoked)
        {
            EngageTarget();
        }

    }

    private void EngageTarget()
    {
        if (DistanceToTarget(target.position) <= attackRange)
        {
            AttackTarget();
        }
        else
        {
            FollowTarget();
        }
    }

    private void FollowTarget()
    {
        navMeshAgent.SetDestination(target.position);
    }

    private void AttackTarget()
    {
        print("Die Human!");
    }

    private void Idle()
    {
    }

    private void SetStopDistance(float stopDistance)
    {
        navMeshAgent.stoppingDistance = stopDistance;
    }

    private float DistanceToTarget(Vector3 targetPosition)
    {
        return Vector3.Distance(gameObject.transform.position, targetPosition);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectRange);
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, navMeshAgent.stoppingDistance);
    }

}

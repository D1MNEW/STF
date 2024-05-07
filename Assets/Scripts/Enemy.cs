using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public Mover Player;
    public List<Transform> PatrolPoints;
    public Animator Animator;
    public float ViewAngle;

    private NavMeshAgent _navMeshAgent;
    private bool _isPlayerNoticed;

    void Start()
    {
        InitComponentLinks();
        PickNewPatrolPoint();
        Animator.SetBool("Go", true);
    }
    private void InitComponentLinks()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
    }


    void Update()
    {
        PatrolUpdate();
        ChaseUpdate();
        AttackUpdate();
        NoticePlayerUpdate();
    }

    private void AttackUpdate()
    {
        if (_isPlayerNoticed)
        {
            if (_navMeshAgent.remainingDistance <= _navMeshAgent.stoppingDistance)
            {
                Animator.SetBool("At", true);
            }
            else
            {
                Animator.SetBool("At", false);
            }
        }
        
    }
    private void NoticePlayerUpdate()
    {
        var direction = Player.transform.position - transform.position;
        _isPlayerNoticed = false;
        if (Vector3.Angle(transform.forward, direction) < ViewAngle)
        {
            RaycastHit Hit;
            if (Physics.Raycast(transform.position + Vector3.up, direction, out Hit))
            {
                if (Hit.collider.gameObject == Player.gameObject)
                {
                    _isPlayerNoticed = true;
                }
            }
        }
    }

    private void PatrolUpdate()
    {
        if (!_isPlayerNoticed)
        {
            if (_navMeshAgent.remainingDistance <= _navMeshAgent.stoppingDistance)
            {
                PickNewPatrolPoint();
            }
        }
    }
    private void PickNewPatrolPoint()
    {
        _navMeshAgent.destination = PatrolPoints[Random.Range(0, PatrolPoints.Count)].position;
    }

    private void ChaseUpdate()
    {
        if (_isPlayerNoticed)
        {
            _navMeshAgent.destination = Player.transform.position;
        }
    }
}


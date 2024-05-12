using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public List<Transform> PatrolPoints;
    public float ViewAngle;
    public float Damage = 30;
    //public float DamagePerSecond = 1;
    //public float AttackDistance = 1;
    public Animator AnimatorEnamy;
    public Mover Player;

    private SkelHealth _skelHealth;
    private NavMeshAgent _navMeshAgent;
    private bool _isPlayerNoticed;
    private EnemyHealth _enemyHealth;

 //   public bool IsAlive()
 //   {
 //       return _enemyHealth.IsAlive();
 //   }
 //   public void DestroyEnamyFull()
 //   {
 //  //     _enemyHealth.DestroyEnamyFull();
 ////   }
 // //  public void DestroyEnamyFull(float delayEnamiesTime)
 // //  {
 // //      _enemyHealth.DestroyEnamyFull(delayEnamiesTime);
 ////   }

    private void Start()
    {
        InitComponentLinks();
        PickNewPatrolPoint();
    }

    private void Update()
    {
        AttackUpdate();

        NoticePlayerUpdate();

        ChaseUpdate();

        PatrolUpdate();


    }

    private void AttackUpdate()
    {
        if (_isPlayerNoticed)
        {
            if (_navMeshAgent.remainingDistance <= _navMeshAgent.stoppingDistance)
            {
                AnimatorEnamy.SetBool("Go", false);
                AnimatorEnamy.SetBool("At", true);
                _skelHealth.DealDamage(Damage * Time.deltaTime);
            }
            else
            {
                NoticePlayerUpdate();
                AnimatorEnamy.SetBool("At", false);
                AnimatorEnamy.SetBool("Go", true);
            }
        }
    }

    private void PickNewPatrolPoint()
    {
        _navMeshAgent.destination = PatrolPoints[Random.Range(0, PatrolPoints.Count)].position;
    }

    private void PatrolUpdate()
    {
        if (!_isPlayerNoticed)
        {
            if (_navMeshAgent.remainingDistance <= _navMeshAgent.stoppingDistance)
            {
                PickNewPatrolPoint();
                AnimatorEnamy.SetBool("Go", true);
            }
        }
    }

    private void InitComponentLinks()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _skelHealth = Player.GetComponent<SkelHealth>();
    }

    private void NoticePlayerUpdate()
    {
        _isPlayerNoticed = false;

        var direction = Player.transform.position - transform.position;
        if (Vector3.Angle(transform.forward, direction) < ViewAngle)
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position + Vector3.up, direction, out hit))
            {
                if (hit.collider.gameObject == Player.gameObject)
                {
                    _isPlayerNoticed = true;
                }
            }
        }
    }

    private void ChaseUpdate()
    {
        if (_isPlayerNoticed)
        {
            _navMeshAgent.destination = Player.transform.position;
        }
    }

    //public void AttackDamage()
    //{
    //    var enemyHealth = gameObject.GetComponent<EnemyHealth>();
    //    if (enemyHealth.Value <= 0)
    //    {
    //        enemyHealth.EnemyDeath();
    //        return;
    //    }
    //    if (!_isPlayerNoticed) return;
    //    if (_navMeshAgent.remainingDistance > _navMeshAgent.stoppingDistance) return;
    //    _skelHealth.DealDamage(Damage);
    //}
}


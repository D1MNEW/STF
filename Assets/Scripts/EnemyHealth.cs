using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyHealth : MonoBehaviour
{
    public float Value = 100;
    public Animator Animator;

    public void DealDamage(float damage)
    {
        Value -= damage;
        if (Value <= 0)
        {
            EnemyDeath();
        }
    }

    public void EnemyDeath()
    {;
        GetComponent<NavMeshAgent>().enabled = false;
        GetComponent<CapsuleCollider>().enabled = false;

        Destroy(gameObject);
    }
}

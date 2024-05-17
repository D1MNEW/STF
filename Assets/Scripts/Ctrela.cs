﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ctrela : MonoBehaviour
{

    public float Speed;
    public float LifeTime;
    public float Damage = 10;

    private void Start()
    {
        Invoke("DestroyCtrela", LifeTime);
    }
    void FixedUpdate()
    {
        MoveFixedUpdate();
    }

    void MoveFixedUpdate()
    {
        transform.position += transform.forward * Speed * Time.fixedDeltaTime;
    }

    private void OnCollisionEnter(Collision collision)
    {
        DamageEnemy(collision);
        DestroyCtrela();
    }

    private void DamageEnemy(Collision collision)
    {
        var enemyHealth = collision.gameObject.GetComponent<EnemyHealth>();
        if (enemyHealth != null)
        {
            enemyHealth.DealDamage(Damage);
        }
    }

    private void DestroyCtrela()
    {
        Destroy(gameObject);
    }
}

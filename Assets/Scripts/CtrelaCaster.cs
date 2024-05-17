using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CtrelaCaster : MonoBehaviour
{
    public float Damage = 10;

    public Ctrela CtrelaPrefab;
    public Transform CtrelaSourceTransform;
    //public Animator Animator;

    //public AudioSource AudioSource;

    private void Start()
    {

    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //AudioSource.Play();

            //Animator.SetTrigger("attack");

            var fireball = Instantiate(CtrelaPrefab, CtrelaSourceTransform.position, CtrelaSourceTransform.rotation);
            fireball.Damage = Damage;
            
            //Animator.SetTrigger("idle");

            //StartCoroutine(Wait());
        }
    }
}

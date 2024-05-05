using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    public float _speed = 0;

    void Start()
    {

    }
    void Update()
    {

        if (Input.GetKey(KeyCode.W))
        {
            transform.position += Vector3.forward * _speed;
            Vector3 rotate = transform.eulerAngles;
            rotate.y = 0;
            transform.rotation = Quaternion.Euler(rotate);
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.position += Vector3.back * _speed;
            Vector3 rotate = transform.eulerAngles;
            rotate.y = 180;
            transform.rotation = Quaternion.Euler(rotate);
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.position += Vector3.left * _speed;
            Vector3 rotate = transform.eulerAngles;
            rotate.y = 270;
            transform.rotation = Quaternion.Euler(rotate);
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.position += Vector3.right * _speed;
            Vector3 rotate = transform.eulerAngles;
            rotate.y = 90;
            transform.rotation = Quaternion.Euler(rotate);
        }
    }

}

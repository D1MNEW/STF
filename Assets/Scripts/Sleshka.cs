using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sleshka : MonoBehaviour
{
    public GameObject chto;
    private Vector3 poloshenie;
    void Start()
    {
        poloshenie = transform.position - chto.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = chto.transform.position + poloshenie;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    public GameObject Flok;
    void OnTriggerEnter(Collider other)
    {
        Flok.SetActive(true);
    }
}

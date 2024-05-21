using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockCAmer : MonoBehaviour
{
    // Start is called before the first frame update
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

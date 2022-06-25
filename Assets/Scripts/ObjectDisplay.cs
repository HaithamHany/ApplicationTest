using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDisplay : MonoBehaviour
{
    private Rigidbody rigidbody;
    private bool rotateObject = true;

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (!rotateObject) return;
        rigidbody.AddTorque(0.1f, -0.5f, 0.1f);
    }
}

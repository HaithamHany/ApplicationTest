using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDisplay : MonoBehaviour
{
    private Rigidbody rigidbody;
    private bool rotateObject = false;
    private int id;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    public void Init(int id)
    {
        this.id = id;
        EventsHandler.Instance.OnActivatingObject += OnObjectActivated;
    }

    private void OnObjectActivated(int id)
    {
        this.rotateObject = (this.id == id);   
        if(!rotateObject)
        {
            rigidbody.angularVelocity = Vector3.zero;
        }
    }

    private void Update()
    {
        if (!rotateObject) return;
        rigidbody.AddTorque(0.1f, -0.5f, 0.1f);
    }

    private void OnDestroy()
    {
        EventsHandler.Instance.OnActivatingObject -= OnObjectActivated;
    }
}

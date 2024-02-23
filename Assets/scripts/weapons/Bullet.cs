using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;



[RequireComponent(typeof(Rigidbody))]

public class Bullet : MonoBehaviour
{

    private float _speed = 100;
    private Action<Bullet> _OnKill;

    public void Init(Action<Bullet> actionKill)
    { 
        _OnKill = actionKill;

        Rigidbody rb = GetComponent<Rigidbody>();
        rb.velocity = transform.forward * _speed;
    }

    private void OnCollisionEnter(Collision collision)
    {

        _OnKill(this);
        
    }
}

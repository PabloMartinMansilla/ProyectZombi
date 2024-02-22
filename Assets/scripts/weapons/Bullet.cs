using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;



[RequireComponent(typeof(Rigidbody))]

public class Bullet : MonoBehaviour
{

    private float speed = 100;
    private Action<Bullet> OnKill;

    public void Init(Action<Bullet> actionKill)
    { 
        OnKill = actionKill;

        Rigidbody rb = GetComponent<Rigidbody>();
        rb.velocity = transform.forward * speed;
    }

    private void OnCollisionEnter(Collision collision)
    {

        OnKill(this);
        
    }
}

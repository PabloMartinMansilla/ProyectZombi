using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyZombi : Enemy
{
    private int _timer = 12;

    [Header("References")]
    private Animator _animator;
    private Rigidbody _rb;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _animator = GetComponent<Animator>();
        live = 100;
    }

    private void Update()
    {
        animations();

        if (!alive)
        {
            Invoke("Dead", _timer);
        }
    }

    private void Dead()
    {
        Destroy(this.gameObject);
    }

    private void animations()
    {
        if (alive)
        {
            switch (stateEnemy)
            {
                case StateEnemy.idel:
                    _animator.SetBool("walking", false);
                    break;
                case StateEnemy.walk:
                    _animator.SetBool("walking", true);
                    _animator.SetBool("attack", false);
                    break;
                case StateEnemy.attack:
                    _animator.SetBool("attack", true);
                    break;
                case StateEnemy.specialAttack:

                    break;
                case StateEnemy.dead:
                    _animator.SetBool("death", true);
                    alive = false;
                    break;

            }

        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet") && alive)
        {
            stateEnemy = StateEnemy.dead;
        }
    }
}


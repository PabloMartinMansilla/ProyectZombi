using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyZombi : Enemy
{
    private int timer = 12;

    [Header("References")]
    private Animator animator;
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        live = 100;
    }

    private void Update()
    {
        animations();

        if (!alive)
        {
            Invoke("Dead", timer);
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
                    animator.SetBool("walking", false);
                    break;
                case StateEnemy.walk:
                    animator.SetBool("walking", true);
                    animator.SetBool("attack", false);
                    break;
                case StateEnemy.attack:
                    animator.SetBool("attack", true);
                    break;
                case StateEnemy.specialAttack:

                    break;
                case StateEnemy.dead:
                    animator.SetBool("death", true);
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


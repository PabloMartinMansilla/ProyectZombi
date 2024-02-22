using GLTF.Schema;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("LIVE")]
    protected float live;
    protected bool alive = true;

    [Header("DAMAGE")]
    protected float damage;
    protected float specialDamage;
    protected float durationDamage;

    [Header("OTHER STADISTICS")]
    protected float speed = 0.5f;
    protected float detectionRadius;
    private string _nameEnemy;

    //estado del zombi
    public enum StateEnemy
    {
        idel,
        walk,
        attack,
        specialAttack,
        dead
    }
    protected StateEnemy stateEnemy;

    //no me acuerdo bien
    public string NameEnemy
    {
        get
        {
            return _nameEnemy;
        }

        set
        {
            _nameEnemy = value;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && alive)
        {
            stateEnemy = StateEnemy.walk;
            detected(other);
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player") && alive)
        {
            stateEnemy = StateEnemy.attack;
        }
    }

    public virtual void detected(Collider other)
    {

        if (alive)
        {

            Vector3 positionPlayer = new Vector3(other.gameObject.transform.
                                            position.x, transform.position.y,
                                            other.gameObject.transform.position.z);

            this.gameObject.transform.LookAt(positionPlayer);

            transform.position = Vector3.MoveTowards(transform.position,
                                                    other.gameObject.transform.position,
                                                    speed * Time.deltaTime);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && alive)
        {
            stateEnemy = StateEnemy.idel;
        }
    }

}

using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class EnemyZombi : Enemy, IPunObservable
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

        if (!photonView.IsMine && PhotonNetwork.IsConnected)
        {
            animations();
            if (!alive)
            {
                Invoke("Dead", _timer);
            }
            return;
        }


    }





    private void animations()
    {
        if (alive && _animator != null)
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





    [PunRPC]
    private void Dead()
    {
        Destroy(this.gameObject);
    }



    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet") && alive)
        {
            stateEnemy = StateEnemy.dead;
        }
    }





    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            stream.SendNext(transform.position);
            stream.SendNext(stateEnemy);
        }
        else
        { 
            transform.position = (Vector3)stream.ReceiveNext();
            stateEnemy = (StateEnemy)stream.ReceiveNext();
        }
    }
}


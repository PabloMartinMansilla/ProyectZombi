using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.Rendering.DebugUI;

public class stadistics : MonoBehaviourPunCallbacks
{
    [Header("General")]
    private float _inputX;
    private float _inputZ;

    [Header("reference")]
    public Animator animator;
    public Image lifeReference;
    public Image shieldReference;

    [Header("Live")]
    private float _life = 100;
    private float _shield;
    private bool _live;


    //start the variables
    private void Start()
    {
        //Live
        _life = 100;
        _live = true;
        _shield = 100;


        GameObject canvas = GameObject.Find("Canvas");
        Transform imageTransform = canvas.transform.Find("Life");
        lifeReference = imageTransform.GetComponent<Image>();
        
        Transform image2Transform = canvas.transform.Find("Shield");
        shieldReference = image2Transform.GetComponent<Image>();

    }



    private void Update()
    {

        if (photonView.IsMine)
        {

            MovePlayer();
        }
    }




    //controlled variables for animations
    private void MovePlayer()
    {
        _inputX = Input.GetAxis("Horizontal");
        _inputZ = Input.GetAxis("Vertical");


        animator.SetFloat("VelX", _inputX);
        animator.SetFloat("VelZ", _inputZ);
    }




    //if the enemy collides with the player, it takes his life if he does not have a shield.
    private void TakeLife()
    {
        if (_life <= 100)
        {

            _life = _life - 5;
            lifeReference.rectTransform.sizeDelta = new Vector2(_life, lifeReference.rectTransform.sizeDelta.y);
            if (_life < 0)
            {
                _live = false;
                //dead
            }
            else
            {
                _live = true;
            }
        }
    }




    //I take away his shield if he still has it.
    private void TakeShield()
    {
        _shield = _shield - 20;
        shieldReference.rectTransform.sizeDelta = new Vector2(_shield, shieldReference.rectTransform.sizeDelta.y); 
    }






    private void OnCollisionEnter(Collision collision)
    {

        if (photonView.IsMine)
        {

            if (collision.gameObject.CompareTag("Enemy"))
            {
                if (_shield <= 1)
                {
                    TakeLife();
                    return;
                }

                TakeShield();
            }

        }
    }
}

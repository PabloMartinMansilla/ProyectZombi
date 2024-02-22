using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.Rendering.DebugUI;

public class stadistics : MonoBehaviour
{
    [Header("General")]
    private float inputX;
    private float inputZ;

    [Header("reference")]
    public Animator animator;
    public Image lifeReference;
    public Image shieldReference;

    [Header("Live")]
    private float life = 100;
    private float shield;
    private bool live;


    //start the variables
    private void Start()
    {
        //Live
        life = 100;
        live = true;
        shield = 100;

    }




    private void Update()
    {

        MovePlayer();
    }




    //controlled variables for animations
    private void MovePlayer()
    {
        inputX = Input.GetAxis("Horizontal");
        inputZ = Input.GetAxis("Vertical");


        animator.SetFloat("VelX", inputX);
        animator.SetFloat("VelZ", inputZ);
    }




    //if the enemy collides with the player, it takes his life if he does not have a shield.
    private void TakeLife()
    {
        if (life <= 100)
        {

            life = life - 5;
            lifeReference.rectTransform.sizeDelta = new Vector2(life, lifeReference.rectTransform.sizeDelta.y);
            if (life < 0)
            {
                live = false;
                //dead
            }
            else
            {
                live = true;
            }
        }
    }




    //I take away his shield if he still has it.
    private void TakeShield()
    {
        shield = shield - 20;
        shieldReference.rectTransform.sizeDelta = new Vector2(shield , shieldReference.rectTransform.sizeDelta.y);
    }






    private void OnCollisionEnter(Collision collision)
    {
        if ( collision.gameObject.CompareTag("Enemy"))
        {
            if (shield <= 1)
            {
                TakeLife();
                return;
            }

            TakeShield();
        }
    }
}

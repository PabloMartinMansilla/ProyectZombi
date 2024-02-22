using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Door : MonoBehaviour, Interactable
{

    private Animator animator;

    private void Start()
    {
        BoxCollider colisionBox = gameObject.AddComponent<BoxCollider>();
        colisionBox.size = new Vector3(1, 2.098418f, 4);
        colisionBox.center = new Vector3(0, -0.9f, 0);
        colisionBox.isTrigger = true;
        animator = GetComponent<Animator>();
    }

    public void Interact()
    {
        animator.SetBool("openDoor", true);
    }

}

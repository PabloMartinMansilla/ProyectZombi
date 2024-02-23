using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drawer : MonoBehaviour, Interactable
{
    private Animator _anim;

    public void Interact()
    {
        _anim.SetBool("activate", true);
        Debug.Log("funciono");
    }

    private void Start()
    {
        _anim = gameObject.GetComponent<Animator>();
    }
}

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
        BoxCollider boxCollider = gameObject.AddComponent<BoxCollider>();
        boxCollider.size = new Vector3(0.3375741f, 0.294036f, 0.4404921f);
        boxCollider.center = new Vector3(0f, 0f, -0.27f);
        boxCollider.isTrigger = true;
        _anim = gameObject.GetComponent<Animator>();
    }
}

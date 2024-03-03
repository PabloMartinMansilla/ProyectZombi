using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drawer : MonoBehaviourPun, Interactable
{

    private Animator _anim;



    public void Interact()
    {
        photonView.RPC("Open", RpcTarget.All);
    }



    private void Start()
    {
        _anim = GetComponent<Animator>();
    }



    [PunRPC]
    private void Open()
    {
        _anim.SetBool("activate", true);
    }
}

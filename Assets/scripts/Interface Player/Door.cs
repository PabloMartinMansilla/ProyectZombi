using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Door : MonoBehaviourPun, Interactable
{

    private Animator _animator;

    
    public void Interact()
    {
        photonView.RPC("OpenDoor", RpcTarget.All);
    }




    private void Start()
    {
        _animator = GetComponent<Animator>();
    }


    [PunRPC]
    private void OpenDoor()
    {
        _animator.SetBool("openDoor", true);
    }

}

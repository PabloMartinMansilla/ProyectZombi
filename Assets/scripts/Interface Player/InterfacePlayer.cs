using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public interface Interactable
{
    void Interact();
}

public class InterfacePlayer : MonoBehaviourPunCallbacks
{

    private void OnTriggerStay(Collider other)
    {
        if (!photonView.IsMine)
            return;

        if (Input.GetKeyDown(KeyCode.F) && other.gameObject.CompareTag("Object"))
        {
            Interactable interact = other.gameObject.GetComponent<Interactable>();
            if (interact != null)
            { 
                interact.Interact();
            }

        }
    }
}

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
    public GameObject[] objects;

    private void Update()
    {
        if (!photonView.IsMine)
            return;

        if (Input.GetKeyDown(KeyCode.F))
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.forward, out hit, Mathf.Infinity))
            {
                Interactable interactable = hit.collider.GetComponent<Interactable>();
                if (interactable != null)
                {
                    interactable.Interact();
                }
            }
        }
    }


}

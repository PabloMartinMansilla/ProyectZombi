using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public interface Interactable
{
    void Interact();
}

public class InterfacePlayer : MonoBehaviour
{
    public GameObject[] objects;


    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Object") && Input.GetKeyDown(KeyCode.F))
        {
            Interactable myInteractable = other.gameObject.GetComponent<Interactable>();
            myInteractable?.Interact();
        }
    }


}

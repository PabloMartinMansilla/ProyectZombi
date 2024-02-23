using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Energy : MonoBehaviour, Interactable
{
    public GameObject Light;

    private void Start()
    {
        Light.SetActive(false);    
    }


    public void Interact()
    {
        Light.SetActive(true);
        Debug.Log("se prendieron");
    }
}

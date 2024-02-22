using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionsGuns : MonoBehaviour
{

    public GameObject positionGuns1;
    public GameObject positionGuns2;
    public GameObject guns;
    [SerializeField] private bool presioned;
    public Camera cam;

    private void LateUpdate()
    {
        if (Input.GetMouseButtonDown(1))
        {
            presioned = true;
        }
        
        if(Input.GetMouseButtonUp(1))
        {
            presioned = false;
        }

        if (presioned == true)
        {
            guns.transform.position = positionGuns2.transform.position;
            guns.transform.rotation = positionGuns2.transform.rotation;
            cam.fieldOfView = 20;
        }
        else
        {
            guns.transform.position = positionGuns1.transform.position;
            guns.transform.rotation = positionGuns1.transform.rotation;
            cam.fieldOfView = 60;
        }
    }
}

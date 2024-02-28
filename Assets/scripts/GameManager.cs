using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public Text textAmmo;

    public WeaponOne weaponOne;

    private void Update()
    {
        textAmmo.text = weaponOne.ammo.ToString();
    }
}

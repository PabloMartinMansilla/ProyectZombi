using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviourPunCallbacks
{
    public Text textAmmo;

    [Header("references")]

    public TMP_Dropdown dropdownGraphics;
    public int calidad;
    public TMP_Dropdown dropdownScreen;
    private WeaponOne weaponOne;
    [SerializeField] private Image brillo;
    [SerializeField] private Slider sliderBrillo;
    [SerializeField] private Slider sliderSonido;
    [SerializeField] private Slider sliderSensibilidad;

    [Header("Pause")]
    [SerializeField] private GameObject menuPause;
    [SerializeField] private GameObject menuInicio;
    [SerializeField] private GameObject menuGame;
    [SerializeField] private GameObject menuScreen;


    public PhotonView Player;
    public Transform spawn;

    private void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
        Cursor.visible = false;
        calidad = PlayerPrefs.GetInt("numeroDeCalidad" + PhotonNetwork.LocalPlayer.ActorNumber, dropdownGraphics.value);
        dropdownGraphics.value = calidad;
        cambiocalidad();

        //cambio de pantalla completa
        dropdownScreen.value = 0;
        cambiopantalla();
    }




    public override void OnConnectedToMaster()
    {
        PhotonNetwork.JoinRandomOrCreateRoom();

    }


    public override void OnJoinedRoom()
    {
        GameObject player = PhotonNetwork.Instantiate(Player.name, spawn.position, spawn.rotation);
        Debug.Log(player.name);
        player.tag = "Player";
        weaponOne = player.GetComponentInChildren<WeaponOne>();
    }



    private void Update()
    {


        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pausa();
        }


        if (photonView.IsMine)
        {
            photonView.RPC("UpdateAmmo", RpcTarget.All, weaponOne.ammo);
        }

        limitedcursor();
    }

    private void limitedcursor()
    {
        Cursor.lockState = CursorLockMode.Confined;
    }

    [PunRPC]
    private void UpdateAmmo(int ammoCount)
    {
        //Debug.Log("Received ammo count: " + ammoCount);
        textAmmo.text = ammoCount.ToString();

    }


    #region BUTTONS

    public void cambiocalidad()
    {
        QualitySettings.SetQualityLevel(dropdownGraphics.value);
        PlayerPrefs.SetInt("numeroDeCalidad" + PhotonNetwork.LocalPlayer.ActorNumber, dropdownGraphics.value);
        calidad = dropdownGraphics.value;
    }


    public void cambiopantalla()
    {
        if (dropdownScreen.value == 0)
        {
            Screen.fullScreenMode = FullScreenMode.ExclusiveFullScreen;
        }
        else
        { 
            Screen.fullScreenMode= FullScreenMode.Windowed;
        }
    }



    public void pausa()
    {
            Cursor.visible = true;
            menuPause.SetActive(true);
            menuInicio.SetActive(true);
            menuGame.SetActive(false);
            menuScreen.SetActive(false);
    }



    public void MenuInicio()
    {
        menuPause.SetActive(true);
        menuInicio.SetActive(true);
        menuGame.SetActive(false);
        menuScreen.SetActive(false);
    }



    public void MenuGame()
    {
        menuPause.SetActive(true);
        menuInicio.SetActive(false);
        menuGame.SetActive(true);
        menuScreen.SetActive(false);
    }



    public void MenuScreen()
    {
        menuPause.SetActive(true);
        menuInicio.SetActive(false);
        menuGame.SetActive(false);
        menuScreen.SetActive(true);
    }



    public void MenuResum()
    {
        menuPause.SetActive(false);
        menuInicio.SetActive(false);
        menuGame.SetActive(false);
        menuScreen.SetActive(false);
        Cursor.visible = false;
    }




    public void Menuquit()
    {
        Application.Quit();
    }

    #endregion
}

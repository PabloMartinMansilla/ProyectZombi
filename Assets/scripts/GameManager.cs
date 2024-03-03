using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Text textAmmo;

    [Header("references")]

    public TMP_Dropdown dropdown;
    public int calidad;
    public WeaponOne weaponOne;
    [SerializeField] private Image brillo;
    [SerializeField] private Slider sliderBrillo;
    [SerializeField] private Slider sliderSonido;
    [SerializeField] private Slider sliderSensibilidad;

    [Header("Pause")]
    [SerializeField] private GameObject menuPause;
    [SerializeField] private GameObject menuInicio;
    [SerializeField] private GameObject menuGame;
    [SerializeField] private GameObject menuScreen;



    private void Start()
    {
        Cursor.visible = false;
        calidad = PlayerPrefs.GetInt("numeroDeCalidad", 2);
        dropdown.value = calidad;
        cambiocalidad();
    }



    private void Update()
    {
        //textAmmo.text = weaponOne.ammo.ToString();

        if (Input.GetKeyDown(KeyCode.Escape))
            pausa();
    }



    public void cambiocalidad()
    {
        QualitySettings.SetQualityLevel(dropdown.value);
        PlayerPrefs.GetInt("numeroDeCalidad", dropdown.value);
        calidad = dropdown.value;
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
}

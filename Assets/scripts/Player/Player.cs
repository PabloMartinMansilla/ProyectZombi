using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("reference")]
    public Camera playerCam;
    public GameObject light;

    [Header("General")]
    [SerializeField] private float _speedRotation;
    private Vector3 _rotationInput;
    [SerializeField] private float _camVertical;
    public Animator animator;
    private bool lightbool = false;


    [Header("Speed")]
    [SerializeField] private float _speed;
    private bool _runing = true;

    [Header("Jump")]
    [SerializeField] private float _speedJump;
    private bool _jumping = true;

    private void Start()
    {
        InvokeRepeating("substractBattery", 1.0f, 1.0f);
    }


    private void Update()
    {

        walk();
        Jump();
        Run();
        Down();
        look();
        TurnOnLight();
    }

    private void walk()
    {
        float x = Input.GetAxis("Horizontal") * _speed * Time.deltaTime;
        float z = Input.GetAxis("Vertical") * _speed * Time.deltaTime;

        transform.Translate(new Vector3(x, 0.0f, z));
    }

    private void Jump()
    {
        if (_jumping == true)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                GetComponent<Rigidbody>().AddForce(Vector3.up * _speedJump, ForceMode.Impulse);
                _jumping = false;
            }
        }
    }

    private void Run()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            _speed = 6;
            _runing = true;
        }
        else
        {
            _runing = false;
        }
    }

    private void Down()
    {
        if (_runing == false)
        {
            if (Input.GetKey(KeyCode.LeftControl))
            {
                _speed = 1;
            }
            else
            {
                _speed = 3;
            }

        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("floor"))
        {
            _jumping = true;
        }
    }

    private void look()
    {
        _rotationInput.x = Input.GetAxis("Mouse X") * _speedRotation * Time.deltaTime;
        _rotationInput.y = Input.GetAxis("Mouse Y") * _speedRotation * Time.deltaTime;

        _camVertical += _rotationInput.y;
        _camVertical = Mathf.Clamp(_camVertical, -20, 70);

        transform.Rotate(Vector3.up * _rotationInput.x);
        playerCam.transform.localRotation = Quaternion.Euler(-_camVertical, 0f, 0f);
    }

    private void TurnOnLight()
    {

        if (Input.GetKeyDown(KeyCode.E) && lightbool == false )
        {
            lightbool = true;
            light.SetActive(lightbool);
            Debug.Log("se prendio");
            return;
        }

        if (Input.GetKeyDown(KeyCode.E) && lightbool == true )
        {
            lightbool = false;
            light.SetActive(lightbool);
            Debug.Log("se apago");
            return;
        }
    }
}

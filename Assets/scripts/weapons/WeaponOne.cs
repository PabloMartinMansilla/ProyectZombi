using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;
using TMPro;
using UnityEngine.UI;

public class WeaponOne : MonoBehaviour

{
    [Header("pooling")]
    private ObjectPool<Bullet> _pool;
    public bool usePool;
    private bool _collectionCheck = false;
    private int _defaultCapacity = 5;
    private int _maxCapacity = 5;

    [Header("References")]
    public GameObject bulletPrefab;
    public GameObject spawnBulletPosition;
    public TextMeshProUGUI textAmmo;

    [Header("other")]
    [SerializeField] private bool _pointing = false;
    [SerializeField] private bool _shootingUp = false;
    private bool _shooting = true;
    private int _ammo = 150;


    private void Start()
    {

        if (usePool)
        {
            _pool = new ObjectPool<Bullet>(
            CreatePoolItemObject,
            ReturnedToPool,
            OnTakefromPool,
            OnDestroyPoolObject,
            _collectionCheck,
            _defaultCapacity,
            _maxCapacity);
        }

        for (int i = 0; i < _maxCapacity; i++)
        {
            var bullet = Instantiate(bulletPrefab).GetComponent<Bullet>();
            _pool.Release(bullet);
            bullet.gameObject.SetActive(false);
        }
    }

    #region pooling

    private Bullet CreatePoolItemObject()
    {
        GameObject bulletobject = Instantiate(bulletPrefab);
        return bulletobject.GetComponent<Bullet>();
    }

    private void ReturnedToPool(Bullet obj)
    {
        obj.gameObject.SetActive(false);
    }

    private void OnTakefromPool(Bullet obj)
    {
        obj.gameObject.SetActive(true);
    }

    private void OnDestroyPoolObject(Bullet obj)
    {
        obj.gameObject.SetActive(false);
    }

    #endregion

    private void Update()
    {

        textAmmo.text = _ammo.ToString();

        if (Input.GetMouseButtonDown(1))
        {
            _pointing = true;
        }
        else if (Input.GetMouseButtonUp(1))
        {
            _pointing = false;
        }

        if (Input.GetMouseButtonDown(0))
        {
            _shootingUp = true;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            _shootingUp = false;
        }

        if (_pointing && _shootingUp && _shooting && _ammo > 0)
        {
            StartCoroutine(disparo());
        }
    }

    private IEnumerator disparo()
    {
        _shooting = false;

        Bullet bullet;
        if (usePool && _pool != null)
        {
            bullet = _pool.Get();
            bullet.gameObject.SetActive(true);
            bullet.transform.position = spawnBulletPosition.transform.position;
            bullet.transform.rotation = spawnBulletPosition.transform.rotation;
            bullet.Init(kill);
        }
        else
        {
            bullet = Instantiate(bulletPrefab).GetComponent<Bullet>();
        }

        _ammo--;

        yield return new WaitForSeconds(0.01f);

        _shooting = true;
    }

    private void kill(Bullet bullet)
    {
        if (usePool)
        {
            _pool.Release(bullet);
        }
        else
        {
            Destroy(bullet.gameObject);
        }

    }
}

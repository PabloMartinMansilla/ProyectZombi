using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;
using TMPro;
using UnityEngine.UI;

public class WeaponOne : MonoBehaviour

{
    [Header("pooling")]
    private ObjectPool<Bullet> pool;
    public bool usePool;
    private bool collectionCheck = false;
    private int defaultCapacity = 5;
    private int maxCapacity = 5;

    [Header("References")]
    public GameObject bulletPrefab;
    public GameObject spawnBulletPosition;
    public TextMeshProUGUI textAmmo;

    [Header("other")]
    [SerializeField] private bool pointing = false;
    [SerializeField] private bool shootingUp = false;
    private bool shooting = true;
    private int ammo = 150;


    private void Start()
    {

        if (usePool)
        {
            pool = new ObjectPool<Bullet>(
            CreatePoolItemObject,
            ReturnedToPool,
            OnTakefromPool,
            OnDestroyPoolObject,
            collectionCheck,
            defaultCapacity,
            maxCapacity);
        }

        for (int i = 0; i < maxCapacity; i++)
        {
            var bullet = Instantiate(bulletPrefab).GetComponent<Bullet>();
            pool.Release(bullet);
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

        textAmmo.text = ammo.ToString();

        if (Input.GetMouseButtonDown(1))
        {
            pointing = true;
        }
        else if (Input.GetMouseButtonUp(1))
        {
            pointing = false;
        }

        if (Input.GetMouseButtonDown(0))
        {
            shootingUp = true;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            shootingUp = false;
        }

        if (pointing && shootingUp && shooting && ammo > 0)
        {
            StartCoroutine(disparo());
        }
    }

    private IEnumerator disparo()
    {
        shooting = false;

        Bullet bullet;
        if (usePool && pool != null)
        {
            bullet = pool.Get();
            bullet.gameObject.SetActive(true);
            bullet.transform.position = spawnBulletPosition.transform.position;
            bullet.transform.rotation = spawnBulletPosition.transform.rotation;
            bullet.Init(kill);
        }
        else
        {
            bullet = Instantiate(bulletPrefab).GetComponent<Bullet>();
        }

        ammo--;

        yield return new WaitForSeconds(0.01f);

        shooting = true;
    }

    private void kill(Bullet bullet)
    {
        if (usePool)
        {
            pool.Release(bullet);
        }
        else
        {
            Destroy(bullet.gameObject);
        }

    }
}

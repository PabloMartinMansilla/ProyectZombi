using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{

    public GameObject enemy;
    private float timer = 0f;
    private int maxEnemy = 1;


    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && timer == 0 && maxEnemy < 6)
        {
            Instantiate(enemy);
            enemy.transform.position = this.gameObject.transform.position;
            maxEnemy++;
            StartCoroutine(Spawn());
        }
        
    }

    private IEnumerator Spawn()
    {
        while (timer < 3)
        {
            timer++;
            yield return new WaitForSeconds(3);
        }
        timer = 0f;
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    public GameObject bulletPrefab;
    IEnumerator BulletSpawning()
    {
        for(; ; )
        {
            GameObject g = Instantiate(bulletPrefab);
            g.transform.position = transform.position;
            yield return new WaitForSeconds(1f);
        }
    }

    void Start()
    {
        StartCoroutine("BulletSpawning");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestSpawner : MonoBehaviour
{
    public GameObject chestPrefab;
    IEnumerator ChestSpawning()
    {
        for(; ; )
        {
            GameObject g = Instantiate(chestPrefab);
            g.transform.position = new Vector3(transform.position.x,transform.position.y,0);
            yield return new WaitForSeconds(3f);
        }
    }

    void Start()
    {
        StartCoroutine("ChestSpawning");
    }
}

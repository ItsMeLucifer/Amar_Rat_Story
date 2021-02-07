using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdditionalEffectsAmar : MonoBehaviour
{
    public GameObject waterPrefab;
    public GameObject waterPrefab2;
    GameObject player;
    void Start()
    {
        player = GameObject.Find("Amar");
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "water")
        {
            StartCoroutine("Particles");
        }
        if(col.tag == "floor")
        {
            StopCoroutine("Particles");
        }
    }
    IEnumerator Particles()
    {
        for (; ; )
        {
            GameObject water = Instantiate(waterPrefab);
            water.transform.position = player.transform.position;
            water.transform.position += new Vector3(0,-0.6f,0);
            water.transform.Rotate(0f, 0f, 47f);
            GameObject water2 = Instantiate(waterPrefab2);
            water2.transform.position = player.transform.position;
            water2.transform.position += new Vector3(0, -0.6f, 0);
            water2.transform.Rotate(0f, 0f, -47f);
            yield return new WaitForSeconds(1.4f);
        }
    }
}

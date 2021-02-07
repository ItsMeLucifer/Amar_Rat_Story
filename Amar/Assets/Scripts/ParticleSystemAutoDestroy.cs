using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleSystemAutoDestroy : MonoBehaviour
{
    private ParticleSystem ps;


    public void Start()
    {
        ps = GetComponent<ParticleSystem>();
    }

    public void Update()
    {
        if (ps)
        {
            if (!ps.IsAlive())
            {
                Destroy(gameObject);
            }
            else
            {
                gameObject.transform.position = GameObject.Find("Amar").transform.position;
                gameObject.transform.position += new Vector3(0, -1f, 0);
            }
        }
    }
}

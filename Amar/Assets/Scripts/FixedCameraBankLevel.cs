using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixedCameraBankLevel : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(gameObject.transform.position.y < 0)
        {
            gameObject.transform.position = new Vector3(0, 0, -10);
        }
        if (gameObject.transform.position.y > 130)
        {
            gameObject.transform.position = new Vector3(0, 130, -10);
        }
        if (gameObject.transform.position.x < 0 || gameObject.transform.position.x > 0)
        {
            gameObject.transform.position = new Vector3(0, gameObject.transform.position.y, -10);
        }
    }
}

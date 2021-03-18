using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLerp : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private GameObject player;
    // Start is called before the first frame update
    private float folSpd = 8f;
    public Vector3 offset;
    private float defZ;
    void Start()

    {
        defZ = transform.position.z;
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        
        transform.position = Vector3.Lerp( transform.position-offset, player.transform.position, folSpd * Time.fixedDeltaTime)+offset;
        // transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, -6.4216f);
        transform.position = new Vector3(transform.position.x, transform.position.y, defZ);

    }
}

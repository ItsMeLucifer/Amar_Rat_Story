using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletscript : MonoBehaviour
{
    public float speed = 200f;
    GameObject player;
    Vector3 playerPosition;
    // Start is called before the first frame updates
    void Start()
    {
        player = GameObject.Find("Amar");
        playerPosition = new Vector3(player.transform.position.x, player.transform.position.y-5f, 0);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, playerPosition, (speed *Time.deltaTime )*18);
        if(transform.position == playerPosition)
        {
            Destroy(gameObject);
        }
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "wall")
        {
            Destroy(gameObject);
        }
    }
}

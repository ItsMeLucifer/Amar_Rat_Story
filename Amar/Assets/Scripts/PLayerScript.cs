using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PLayerScript : MonoBehaviour
{
    int health = 100;
    [SerializeField]
    private GameObject msgBox;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D col){
        if(col.name == "kanaly"){
            GameManager.Instance.LoadSewers();
        }
        if (col.name == "bank")
        {
            msgBox.SetActive(true);
        }
        if (col.name == "tpKanaly1"){
            gameObject.transform.position = new Vector3(108.85f,-38.11f,0);
            Destroy(GameObject.Find("czern"));
            GameObject.Find("wall2").GetComponent<SpriteRenderer>().color = new Color(255f, 255f, 255f);
        }
        if(col.name == "tpKanaly2"){
            
            GameManager.Instance.LoadSzczurzyDom();
            
        }
        if(col.tag == "bullet")
        {
            GetDmg();
            Destroy(col.gameObject);
        }
    }

    public void GetDmg()
    {
        health -= 10;
    }
}

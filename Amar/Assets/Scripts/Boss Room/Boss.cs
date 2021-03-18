using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss : MonoBehaviour
{
    private float health = 1000f;
    public GameObject hpBar;
    public Text hpText;
    [SerializeField]
    private GameObject GameManager;
    void Update()
    {
        if (health >= 0)
        {
            hpBar.transform.localScale = new Vector3(health / 1000f, hpBar.transform.localScale.y, hpBar.transform.localScale.z);
            hpText.GetComponent<Text>().text = health.ToString() + "/1000";
        }
        if(health<=0){
            GameManager.GetComponent<GameManager>().LoadEndScene();
        }
    }
    public void GetDmg()
    {
        health -= GameManager.GetComponent<GameManager>().GetStrength()/5;
    }
}

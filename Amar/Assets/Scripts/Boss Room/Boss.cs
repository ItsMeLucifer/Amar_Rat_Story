using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss : MonoBehaviour
{
    private float health = 1000f;
    public GameObject hpBar;
    public Text hpText;
    void Update()
    {
        if (health >= 0)
        {
            hpBar.transform.localScale = new Vector3(health / 1000f, hpBar.transform.localScale.y, hpBar.transform.localScale.z);
            hpText.GetComponent<Text>().text = health.ToString() + "/1000";
        }
    }
    public void GetDmg(int playerStrength)
    {
        health -= playerStrength;
    }
}

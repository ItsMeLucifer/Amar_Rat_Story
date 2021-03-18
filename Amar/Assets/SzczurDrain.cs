using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SzczurDrain : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject hpBar, hpText;
    [SerializeField] private int DamagePerTick = 5;
    private float health, startingHealth;

    void Start()
    {
        startingHealth= health = GameManager.Instance.GetHealth();
        hpText.GetComponent<Text>().text = health+ "/ "+health;
        DrainujSzczura();
    }

    // Update is called once per frame
    void Update()
    {
        hpBar.transform.localScale = new Vector3(health / startingHealth, hpBar.transform.localScale.y, hpBar.transform.localScale.z);
        hpText.GetComponent<Text>().text = health.ToString() + "/"+startingHealth;

    }

    public void DrainujSzczura()
    {
        StartCoroutine(Drain());
    }

    IEnumerator Drain()
    {
        while (health > 0)
        {
            
            yield return new WaitForSeconds(1);
            health -= DamagePerTick;
        }

        health = 0;
        GameOver();
    }

    void GameOver()
    {
       GameManager.Instance.LoadEndScene();
    }
}

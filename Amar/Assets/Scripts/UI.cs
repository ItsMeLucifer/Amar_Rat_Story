using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI : MonoBehaviour
{
    public GameObject healthBar;
    public GameObject powerBar;
    public GameObject speedBar;
    public GameObject foodBar;
    public float Health = 10f;
    public float MaxHP = 10f;
    public int Power = 10;
    public int Speed = 10;
    public int Food = 0;
    public int FoodNeeded = 10;
    public int SkillPoints = 0;
    private GameObject gameManager;
    void Start()
    {
        gameManager = GameObject.Find("GameManager");
    }
    void Awake(){
        DontDestroyOnLoad(gameObject);
    }
    void Update()
    {
        Power = gameManager.GetComponent<GameManager>().GetStrength();
        Health = (float)gameManager.GetComponent<GameManager>().GetHealth();        
        Speed = gameManager.GetComponent<GameManager>().GetSpeed();
        Food = gameManager.GetComponent<GameManager>().GetFood();
        FoodNeeded = gameManager.GetComponent<GameManager>().GetFoodNeeded();
        powerBar.transform.localScale = new Vector3(Power/100f, 1f, 1f);
        speedBar.transform.localScale = new Vector3(Speed / 100f, 1f, 1f);
        foodBar.transform.localScale = new Vector3(Food / FoodNeeded, 1f, 1f);
        /*healthBar.transform.localScale = new Vector3(1f, Health / MaxHP, 1f);*/
        healthBar.transform.localScale = new Vector3(1f, -(MaxHP - Health) / MaxHP, 1f);
        if (Speed > 100) Speed = 100;
        if (Power > 100) Power = 100;
        if (MaxHP < Health) MaxHP = Health;
        if (FoodNeeded < Food) Food = FoodNeeded;
    }
}
//108.85 -38.11
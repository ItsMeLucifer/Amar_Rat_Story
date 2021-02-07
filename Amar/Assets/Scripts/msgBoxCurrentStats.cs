using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class msgBoxCurrentStats : MonoBehaviour
{
    [SerializeField]
    private Text healthText;
    [SerializeField]
    private Text speedText;
    [SerializeField]
    private Text strengthText;
    void Start()
    {
        
    }
    void Update()
    {
        int health = GameObject.Find("GameManager").GetComponent<GameManager>().GetHealth();
        int speed =GameObject.Find("GameManager").GetComponent<GameManager>().GetSpeed();
        int strength = GameObject.Find("GameManager").GetComponent<GameManager>().GetStrength();
        healthText.text = "Recommended Health: 200 (Current: "+health.ToString()+")";
        speedText.text = "Recommended Speed: 40 (Current: "+speed.ToString()+")";
        strengthText.text = "Recommended Strength: 40 (Current: "+strength.ToString()+")";
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class SaveButtonScript : MonoBehaviour
{
    GameObject gameManager;
    public GameObject msgBoxBackground;
    [SerializeField]
    private Text healthPoints;
    [SerializeField]
    private Text speedPoints;
    [SerializeField]
    private Text strengthPoints;
    void Start() { gameManager = GameObject.Find("GameManager"); }
    public void SaveChanges()
    {
        gameManager.GetComponent<GameManager>().AddHealth(Int32.Parse(healthPoints.text));
        gameManager.GetComponent<GameManager>().AddSpeed(Int32.Parse(speedPoints.text));
        gameManager.GetComponent<GameManager>().AddStrength(Int32.Parse(strengthPoints.text));
        msgBoxBackground.SetActive(false);
    }
}

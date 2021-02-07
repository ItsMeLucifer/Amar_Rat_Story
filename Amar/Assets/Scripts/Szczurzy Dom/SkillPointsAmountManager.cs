using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillPointsAmountManager : MonoBehaviour
{
    public GameObject gameManager;
    public int freeSkillPoints;
    void Start()
    {
        gameManager = GameObject.Find("GameManager");
        TextAssignment();
    }
    void Update()
    {
        gameObject.GetComponent<Text>().text ="Your Current Skill Points: "+ freeSkillPoints.ToString();
    }

    void TextAssignment()
    {
        freeSkillPoints = 10;
        freeSkillPoints = gameManager.GetComponent<GameManager>().GetSkillPoints();
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillPointsManagement : MonoBehaviour
{
    public GameObject msgBoxBackground;
    public GameObject gameManager;
    public Text availableSkillPointsText;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager");
    }
    void Update()
    {
        TextAssignment();
    }

    void OnMouseDown()
    {
        msgBoxBackground.active = true;
    }

    void TextAssignment()
    {
        // availableSkillPointsText.text = "Your Current Skill Points: " + gameManager.GetComponent<GameManager>().skillPoints;
    }
    
}

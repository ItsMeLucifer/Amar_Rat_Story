using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class IncreaseAndDecreaseSkillPoints : MonoBehaviour
{
    public Text skillPointsAmountDisplayer;
    GameObject skillPointsAmountManager;
    int skillPointsAmount;
    void Start()
    {
        skillPointsAmountManager = GameObject.Find("SubTitle");
    }
    public void Increase()
    {
        int skillPoint = int.Parse(skillPointsAmountDisplayer.GetComponent<Text>().text);
        if (skillPointsAmountManager.GetComponent<SkillPointsAmountManager>().freeSkillPoints != 0)
        {
            skillPointsAmountDisplayer.GetComponent<Text>().text = (++skillPoint).ToString();
            skillPointsAmountManager.GetComponent<SkillPointsAmountManager>().freeSkillPoints--;
        }
    }

    public void Decrease()
    {
        int skillPoint = int.Parse(skillPointsAmountDisplayer.GetComponent<Text>().text);
        if (skillPoint != 0)
        {
            skillPointsAmountDisplayer.GetComponent<Text>().text = (--skillPoint).ToString();
            skillPointsAmountManager.GetComponent<SkillPointsAmountManager>().freeSkillPoints++;
        }
    }
}

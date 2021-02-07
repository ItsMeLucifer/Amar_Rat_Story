using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour
{
    public void ParentIncrease()
    {
        gameObject.transform.parent.gameObject.GetComponent<IncreaseAndDecreaseSkillPoints>().Increase();
    }
    public void ParentDecrease()
    {
        gameObject.transform.parent.gameObject.GetComponent<IncreaseAndDecreaseSkillPoints>().Decrease();
    }
}

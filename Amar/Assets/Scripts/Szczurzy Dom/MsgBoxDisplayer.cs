using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MsgBoxDisplayer: MonoBehaviour
{
    public GameObject msgBoxBackground;

    void OnMouseDown()
    {
        msgBoxBackground.SetActive(true);
    }

}

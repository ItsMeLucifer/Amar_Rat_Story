﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SignScript : MonoBehaviour
{
    void OnMouseDown()
    {
        SceneManager.LoadScene("Knoxville");
    }
}
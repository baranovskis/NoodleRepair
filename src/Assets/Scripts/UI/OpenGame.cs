﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpenGame : MonoBehaviour
{
    public void OpenGameOnClick()
    {
        SceneManager.LoadScene("IntroScene");
    }
}

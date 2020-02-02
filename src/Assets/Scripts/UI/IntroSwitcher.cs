using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroSwitcher : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(Timer(5f, Method));
    }
    void Method()
    {
        SceneManager.LoadScene("lvl1");
    }

    IEnumerator Timer(float timer, Action action)
    {
        float time = timer;

        while (time > 0)   // Wait
        {
            time -= Time.deltaTime;
            yield return null;
        }

        action(); // Do something
    }
}

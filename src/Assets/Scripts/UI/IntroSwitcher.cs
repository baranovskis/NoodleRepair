using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroSwitcher : MonoBehaviour
{
    [SerializeField]
    private GameObject BallObject;

    void Start()
    {
        StartCoroutine(Timer(11f, Method));
    }
    void Method()
    {
        SceneManager.LoadScene("lvl1");
    }

    IEnumerator Timer(float timer, Action action)
    {
        float time = timer;

        bool needsBall = false;

        while (time > 0)   // Wait
        {
            time -= Time.deltaTime;

            if (time <= 6 && !needsBall)
            {
                needsBall = true;
                BallObject.SetActive(true);
                var animator = BallObject.GetComponent<SpriteAnimator>();
                animator.Activate();
            }

            yield return null;
        }

        action(); // Do something
    }
}

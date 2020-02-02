using System;
using UnityEngine;

public class pause : MonoBehaviour
{
    bool paused = false;

    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
            paused = togglePause();
    }

    void OnGUI()
    {
        for (int i = 0; i < gameObject.transform.childCount; i++)
        {
            Transform t = gameObject.transform.GetChild(i);

            if (t.tag == "PauseCanvas")
            {
                t.gameObject.SetActive(paused);
            }
        }
    }

    bool togglePause()
    {
        if (Time.timeScale == 0f)
        {
            Time.timeScale = 1f;
            return (false);
        }
        else
        {
            Time.timeScale = 0f;
            return (true);
        }
    }
}
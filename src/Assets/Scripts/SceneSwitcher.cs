using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    public static SceneSwitcher instance = null;

    private int _currentSceneIndex = 0;

    private string[] _scenes = new[]
    {
        "lvl1",
        "lvl2",
        "lvl3",
        "lvl4"
    };

    void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }

    public void LoadNextScene()
    {
        if (_currentSceneIndex < _scenes.Length - 1)
        {
            string sceneToLoad = _scenes[_currentSceneIndex + 1];
            _currentSceneIndex++;

            SceneManager.LoadScene(sceneToLoad);
        }
        else
        {
            SceneManager.LoadScene("EndingScene");
        }
    }
}
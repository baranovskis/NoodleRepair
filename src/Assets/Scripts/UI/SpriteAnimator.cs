using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpriteAnimator : MonoBehaviour
{

    [SerializeField]
    Sprite[] frames;

    [SerializeField]
    int framesPerSecond = 1;
    void Update()
    {
        int index = (int)Time.time * framesPerSecond;
        index = index % frames.Length;
        GetComponent<Image>().sprite = frames[index];
    }
}

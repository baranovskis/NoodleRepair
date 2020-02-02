using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpriteAnimator : MonoBehaviour
{
    [SerializeField]
    bool active = false;


    [SerializeField]
    Sprite[] frames;

    [SerializeField]
    int framesPerSecond = 1;

    float previousTime = 0;

    int index = 0;

    void Update()
    {
        if (active)
        {
            float time = Time.time;
            if (time - previousTime > 1f)
            {
                previousTime = time;
                GetComponent<Image>().sprite = frames[index];

                index = (index >= frames.Length-1 ? 0 : index + 1);
            }
        }
    }

    public void Activate()
    {
        active = true;

    }
}
